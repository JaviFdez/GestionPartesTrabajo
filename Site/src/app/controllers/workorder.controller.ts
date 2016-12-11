import { app } from "app/main";

import "app/services/projects.service";
import "app/services/workOrders.service";
import "app/services/users.service";
import "app/models/Infraestructure";
import "app/services/projecttask.service";

import { IProjectService } from "app/services/projects.service";
import { IWorkOrdersService } from "app/services/workorders.service";
import { IUsersService } from "app/services/users.service";
import { IProjectTasksService } from "app/services/projecttask.service";

import { IProjectModel } from "app/models/projects";
import { IWOModelAmp } from "app/models/workOrders";
import { IUserModel } from "app/models/users";
import { IProjectTasksModelAmp } from "app/models/projecttasks";


interface ICustomRouteParams extends ng.route.IRouteParamsService {
    idWO: number;
}

export interface IWOrderController {
    WOrder: IWOModelAmp;
    Projects: IProjectModel[];
    Users: IUserModel[];
    ProjectTasks: IProjectTasksModelAmp[];
}

export interface ICustomScope extends ng.IScope {
    wOForm: ng.IFormController;
}

class WokrOrderController implements IWOrderController {

    private _scope: ICustomScope;

    private _workOrderService: IWorkOrdersService;
    private _projectService: IProjectService;
    private _usersService: IUsersService;
    private _projectTasksService: IProjectTasksService;

    private _wOrder: IWOModelAmp;
    private _projects: IProjectModel[];
    private _users: IUserModel[];
    private _projectTasks: IProjectTasksModelAmp[];

    private _status: IKeyValueMap<Infraestructure.Status>[];
    private _location: ng.ILocationService;
    private _activeRequest: boolean;
    private _isNewWO: boolean;

    constructor($scope: ICustomScope, workOrderService: IWorkOrdersService,
                $routeParams: ICustomRouteParams, $location: ng.ILocationService,
                projectService: IProjectService, usersService: IUsersService,
                projectTasksService: IProjectTasksService) {
        this._scope = $scope;
        this._workOrderService = workOrderService;
        this._projectService = projectService;
        this._usersService = usersService;
        this._projectTasksService = projectTasksService;

        this._wOrder = {} as IWOModelAmp;
        this._isNewWO = $routeParams.idWO ? false : true;
        this._wOrder.Id = $routeParams.idWO;

        this._location = $location;


        this._activeRequest = false;
        this._init();
    }

    public get WOrder(): IWOModelAmp {
        return this._wOrder;
    }

    public get EnumStatus(): IKeyValueMap<Infraestructure.Status>[]{
        return this._status;
    }

    private _getProjectTasks(): ng.IPromise<void> {
        return this._projectTasksService.getProjectTaskByNameProject(this.WOrder.projectName)
               .then((resultCallBack: IProjectTasksModelAmp[]) => {
                   this._projectTasks = resultCallBack;
               }).catch((reason: any) => {
                    alert("No se puede obtener projectTasks");
               });
    }

    public get ProjectTasks(): IProjectTasksModelAmp[] {
        return this._projectTasks;
    }

    private _getProjects(): ng.IPromise<void> {

        return this._projectService.getProjects().then((resultCallback: IProjectModel[]) => {
            this._projects = resultCallback;
        }).catch((reason: any) => {
            alert("No se puede obtener projects");
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

    public get isNewWO(): boolean {
        return this._isNewWO;
    }

    private _saveClickCmd(): void {

        this._activeRequest = true;

        let service: ng.IPromise<IWOModelAmp> = undefined;

        service = this.isNewWO ?
                this._workOrderService.saveWorkOrder(this._wOrder) :
                this._workOrderService.modifyWorkOrder(this._wOrder);

        service.then((resultCallback: IWOModelAmp) => {
            this.WOrder = resultCallback;
        })
        .catch((reason: any) => {
            alert("No se se pueden guardar la orden de trabajo");
        })
        .finally(() => { this._activeRequest = false; });
    }

    private _saveClickCanCmd(): boolean {
        return !this._activeRequest && this._scope.wOForm.$valid;
    }

    private _init(): void {

        if (!this.isNewWO) {
            this._getWO();
        }
        this._getProjects();
        this._getUsers();
    }

    private _getWO(): ng.IPromise<void> {

        return this._workOrderService.getWorkOrder(this._wOrder.Id).then((resultCallback: IWOModelAmp) => {
            this._wOrder = resultCallback;
        }).catch((reason: any) => {
            alert("No se se pueden obtener la orden de trabajo");
        });
    }
}

WokrOrderController.$inject = ["$scope", "workOrdersService", "$routeParams", "$location",
                                "projectService", "usersService", "projectTasksService" ];

app.registerController("workorderController", WokrOrderController);
