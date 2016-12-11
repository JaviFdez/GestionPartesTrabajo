import { app } from "app/main";

import { IProjectTasksModelAmp } from "app/models/projecttasks";

export interface IProjectTasksService {
    getProjectTaskByNameProject(name: string): ng.IPromise<IProjectTasksModelAmp[]>;
}

class ProjectTasksService implements IProjectTasksService {
    
    private _http: ng.IHttpService;
    private _q: ng.IQService;

    constructor($http: ng.IHttpService, $q: ng.IQService) {
        this._http = $http;
        this._q = $q;
    }

    public getProjectTaskByNameProject(name: string): ng.IPromise<IProjectTasksModelAmp[]> {

        app.LogService.log("inicio getProjectTasks ...");

        return this._http({
            params: {name: name},
            headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/ProjectTasks1/ProjectTasksByName"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectTasksModelAmp[]>): IProjectTasksModelAmp[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getWorkOrders error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }
}

ProjectTasksService.$inject = ["$http", "$q"];

app.registerService("projectTasksService", ProjectTasksService);