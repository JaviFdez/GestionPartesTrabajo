import { ICustomersService } from "./../services/customers.service";
import { ICustomerModel } from "app/models/customers";

import { app } from "app/main";
import "app/services/customers.service";
import { IProjectModel } from "app/models/projects";
import { IProjectService } from "app/services/projects.service";

// Indica que cuando lo llamemos tiene que recuperar
// el parametro tiene el nombre del route config
interface ICustomRouteParams extends ng.route.IRouteParamsService {
    idProject: number;
}

export interface IProjectController {
    Project: IProjectModel;
    Customers: ICustomerModel[];
}

export interface ICustomScope extends ng.IScope {
    projectForm: ng.IFormController;
}

class ProjectController implements IProjectController {
    private _scope: ICustomScope;
    private _projectService: IProjectService;
    private _customersService: ICustomersService;

    // variables miembro
    private _project: IProjectModel;
    private _isNewProject: boolean;
    private _location: ng.ILocationService;

    private _customers: ICustomerModel[];

    private _activeRequest: boolean;

    constructor($scope: ICustomScope, projectService: IProjectService,
    $routeParams: ICustomRouteParams, $location: ng.ILocationService,
    customersService: ICustomersService) {
        this._scope = $scope;
        this._projectService = projectService;
        this._customersService = customersService;

        this._project = {} as IProjectModel;
        this._isNewProject = $routeParams.idProject ? false : true;
        this._project.Id = $routeParams.idProject;
        this._location = $location;


        this._activeRequest = false;
        this._init();
    }


    private _getCustomers(): ng.IPromise<void> {

        return this._customersService.getCustomers().then((resultCallback: ICustomerModel[]) => {
            this._customers = resultCallback;
        }).catch((reason: any) => {
            alert("No se se pueden obtener customers");
        });
    }

    public get Project(): IProjectModel {
        return this._project;
    }

    public get Customers(): ICustomerModel[] {
        return this._customers;
    }

    public get isNewProject(): boolean {
        return this._isNewProject;
    }

    private saveClickCmd(): void {

        this._activeRequest = true;

        let service: ng.IPromise<IProjectModel> = undefined;

        service = this._isNewProject ?
            this._projectService.saveProject(this._project) :
            this._projectService.modifyProject(this._project);

        service.then((resultCallback: IProjectModel) => {
            this._project = resultCallback;
        })
        .catch((reason: any) => {
            alert("No se se pueden guardar projects");
        })
        .finally(() => { this._activeRequest = false; });
    }

    private saveClickCanCmd(): boolean {
        return !this._activeRequest && this._scope.projectForm.$valid;
    }

    private _init(): void {

        if (!this._isNewProject) {
            this._getProject();
        }
        this._getCustomers();
    }

    private _getProject(): ng.IPromise<void> {

        return this._projectService.getProject(this._project.Id).then((resultCallback: IProjectModel) => {
            this._project = resultCallback;
        }).catch((reason: any) => {
            alert("No se se pueden obtener projects");
        });
    }
}

ProjectController.$inject = ["$scope", "projectService", "$routeParams", "$location", 
                                "customersService"];

// registrar el controlador en la aplicacion
app.registerController("projectController", ProjectController);
