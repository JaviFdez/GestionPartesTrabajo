import { IProjectModelAmp } from "./../models/projects.d";
import { ICount } from "./../models/comons";
import { IPagerModel } from "app/models/comons";
import { IFiltrosProjectModel } from "app/models/comons";
import { app } from "app/main";

import "app/services/projects.service";

import { IProjectModel } from "app/models/projects";
import { IProjectService } from "app/services/projects.service";
import "app/directives/dialog.directive";

export interface IProjectsController {
    Projects: IProjectModelAmp[];
    Filtros: IFiltrosProjectModel;
}

class ProjectsController implements IProjectsController {
    private _scope: ng.IScope;
    private _projectService: IProjectService;

    private _q: ng.IQService;

    // variables miembro
    private _projects: IProjectModelAmp[];
    private _filtros: IFiltrosProjectModel;

    //rivate _filtroList: IFiltrosCustomerModel;

    private _projectsPageModel: IPagerModel;

    private _selectProject: number;

    private _location: ng.ILocationService;

    private _showDeleteModal: boolean;

     constructor($scope: ng.IScope, $q: ng.IQService, projectService: IProjectService, $location: ng.ILocationService) {
        this._scope = $scope;
        this._projectService = projectService;

        this._projectsPageModel = {pageElemnts: 10, currentPage: 0} as IPagerModel;
        this._filtros = {} as IFiltrosProjectModel;

        this._showDeleteModal = false;

        this._q = $q;

        this._projects = [];

        this._init();
    }

    public get ShowDeleteModal(): boolean {
        return this._showDeleteModal;
    }

    public set ShowDeleteModal(valor: boolean) {

        this._showDeleteModal = valor;
    }

    public deleteModal(idProject: number): void {
        this._selectProject = idProject;
        this._showDeleteModal = true;
    }

    public deleteClickCmd(): void {

        this._projectService.deleteProjects(this._selectProject)
            .then((resultCallback: void) => {
                this.ShowDeleteModal = false;
                this.obtenerPageProjects();
            });
    }

    public get Projects(): IProjectModelAmp[] {
        return this._projects;
    }

    public get Filtros(): IFiltrosProjectModel {
        return this._filtros;
    }

    public _canAdvance(): Boolean {
        return (this._projectsPageModel.currentPage < this._projectsPageModel.totalPages);
    }

    public _canGoBack(): Boolean {
        return (this._projectsPageModel.currentPage > 0);
    }

    public _clickAdvanced(): void {
        this._projectsPageModel.currentPage += this._projectsPageModel.currentPage;
    }

    public _clickGoBack(): void {
        this._projectsPageModel.currentPage -= this._projectsPageModel.currentPage;
    }

    public _reiniciarPage(): ng.IPromise<void> {
        return this._projectService.countProjects()
            .then((resultCallback: ICount) => {
                this._projectsPageModel.currentPage = 0;
                this._projectsPageModel.totalItems = resultCallback.total;
                this._projectsPageModel.totalPages = Math
                    .floor((resultCallback.total - 1) / this._projectsPageModel.pageElemnts);
            });
    }

    public obtenerPageProjects(): ng.IPromise<void> {
        //console.log(this._filtros);
        return this._projectService.getProjectsPage(this._filtros, this._projectsPageModel)
            .then((resultCallback: IProjectModelAmp[]) => {
                this._projects = resultCallback;
            });
    }

    public resetFiltros(): void {
        this._filtros.Description = null;
        this._filtros.ProjectCode = null;
        this._filtros.NameCustomer = null;
        this.obtenerPageProjects();
    }

    private _init(): void {

        this._q.all([
            this._reiniciarPage(),
            this.obtenerPageProjects()
        ]);

    }
}

ProjectsController.$inject = ["$scope", "$q", "projectService", "$location"];

// registrar el controlador en la aplicacion
app.registerController("projectsController", ProjectsController);