import { app } from "app/main";

import "app/services/projects.service";
import "app/services/workOrders.service";
import "app/services/users.service";

import { IUsersService } from "app/services/users.service";
import { IProjectService } from "app/services/projects.service";
import { IWorkOrdersService } from "app/services/workOrders.service";

import { IUserModel } from "app/models/users";
import { IProjectModel } from "app/models/projects";

import { ICount, IPagerModel, IFiltrosWOModel } from "app/models/comons";

import { IWOModelAmp } from "app/models/workOrders";
import "app/directives/dialog.directive";

export interface IWOrdersController {
    WorkOrders: IWOModelAmp[];
    Filtros: IFiltrosWOModel;
    Projects: IProjectModel[];
    Users: IUserModel[];
}

class WorkordersController implements IWOrdersController {

    private _scope: ng.IScope;
    private _workOrdersService: IWorkOrdersService;
    private _projectService: IProjectService;
    private _usersService: IUsersService;

    private _q: ng.IQService;

    private _workOrders: IWOModelAmp[];
    private _projects: IProjectModel[];
    private _users: IUserModel[];

    private _filtros: IFiltrosWOModel;
    private _woPageModel: IPagerModel;

    private _slectedWO: number;

    private _location: ng.ILocationService;

    private _showDeleteModal: boolean;

    constructor($scope: ng.IScope, $q: ng.IQService, workOrdersService: IWorkOrdersService,
                projectService: IProjectService, usersService: IUsersService,
                $location: ng.ILocationService) {
        this._scope = $scope;
        this._workOrdersService = workOrdersService;
        this._projectService = projectService;
        this._usersService = usersService;

        this._woPageModel = {pageElemnts: 10, currentPage: 0} as IPagerModel;
        this._filtros = {} as IFiltrosWOModel;

        this._showDeleteModal = false;

        this._q = $q;

        this._workOrders = [];

        this._init();
    }

    private _getProjects(): ng.IPromise<void> {

        return this._projectService.getProjects().then((resultCallback: IProjectModel[]) => {
            this._projects = resultCallback;
        }).catch((reason: any) => {
            alert("No se se pueden obtener projects");
        });
    }

    public get Projects(): IProjectModel[] {
        return this._projects;
    }

    private _getUsers(): ng.IPromise<void> {

         return this._usersService.getUsers().then((resultCallback: IUserModel[]) => {
            this._users = resultCallback;
        }).catch((reason: any) => {
            alert("No se se pueden obtener usuarios");
        });
    }

    public get Users(): IUserModel[] {
        return this._users;
    }

    public get ShowDeleteModal(): boolean {
        return this._showDeleteModal;
    }

    public set ShowDeleteModal(valor: boolean) {

        this._showDeleteModal = valor;
    }

    public deleteModal(idWO: number): void {
        this._slectedWO = idWO;
        this._showDeleteModal = true;
    }

    public deleteClickCmd(): void {

        this._workOrdersService.deleteWorkOrders(this._slectedWO)
            .then((resultCallback: void) => {
                this.ShowDeleteModal = false;
                this.obtenerPageWO();
            });
    }

    public get DataPickerOptions(): any {
        return {
            dataDisabled: "disabled",
            formatYear: "yy",
            maxDate: new Date(2020, 5, 22),
            minDate: new Date(),
            startingDay: 1
        };
    }

    public get WorkOrders(): IWOModelAmp[]{
        return this._workOrders;
    }
    public get Filtros(): IFiltrosWOModel {
        return this._filtros;
    }

    public _canAdvance(): Boolean {
        return (this._woPageModel.currentPage < this._woPageModel.totalPages);
    }

    public _canGoBack(): Boolean {
        return (this._woPageModel.currentPage > 0);
    }

    public _clickAdvanced(): void {
        this._woPageModel.currentPage += this._woPageModel.currentPage;
    }

    public _clickGoBack(): void {
        this._woPageModel.currentPage -= this._woPageModel.currentPage;
    }

    public reiniciarPage(): ng.IPromise<void> {
        return this._workOrdersService.countWorkOrders()
            .then((resultCallback: ICount) => {
                this._woPageModel.currentPage = 0;
                this._woPageModel.totalItems = resultCallback.total;
                this._woPageModel.totalPages = Math
                    .floor((resultCallback.total - 1) / this._woPageModel.pageElemnts);
            });
    }

    public obtenerPageWO(): ng.IPromise<void> {

        return this._workOrdersService.getWOPage(this._filtros, this._woPageModel)
            .then((resultCallback: IWOModelAmp[]) => {
                this._workOrders = resultCallback;
            });
    }

    public resetFiltros(): void {

        this._filtros.Description = null;
        this._filtros.PlannedDate1 = null;
        this._filtros.PlannedDate2 = null;
        this._filtros.projectName = null;
        this._filtros.Username = null;
        this._filtros.WorkOrderStatus = null;

        this.obtenerPageWO();
    }

    private _init(): void {

        this._q.all([
            this.reiniciarPage(),
            this.obtenerPageWO(),
            this._getProjects(),
            this._getUsers()
        ]);
    }
}

WorkordersController.$inject = ["$scope", "$q", "workOrdersService",
                                "projectService", "usersService", "$location"];
app.registerController("workordersController", WorkordersController);
