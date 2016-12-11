import { IFiltrosProjectModel } from "app/models/comons";

import { app } from "app/main";
import { IProjectModel } from "app/models/projects";
import { IProjectModelAmp } from "app/models/projects";
import { ICount } from "app/models/comons";
import { IPagerModel } from "app/models/comons";

export interface IProjectService {

    /**
     * Funcion para obtener los usuarios desde el servidor
     * @return Array de modelos de usuarios obtenidos
     */
    getProjectsPage(filtros: IFiltrosProjectModel, pagerModel: IPagerModel): ng.IPromise<IProjectModelAmp[]>;
    getProjects(): ng.IPromise<IProjectModelAmp[]>;
    getProject(idProject: number): ng.IPromise<IProjectModelAmp>;
    saveProject(project: IProjectModel): ng.IPromise<IProjectModel>;
    modifyProject(project: IProjectModel): ng.IPromise<IProjectModel>;
    deleteProjects(idProject: number): ng.IPromise<void>;
    countProjects(): ng.IPromise<ICount>;
}

class ProjectService implements IProjectService {

    private _http: ng.IHttpService;
    private _q: ng.IQService;

    constructor($http: ng.IHttpService, $q: ng.IQService) {
        this._http = $http;
        this._q = $q;
    }

    public getProjectsPage(filtros: IFiltrosProjectModel, pagerModel: IPagerModel): ng.IPromise<IProjectModelAmp[]> {
        app.LogService.log("inicio getProjectPage ...");

        return this._http({
            data: filtros,
            headers: { "Content-Type": "application/json" },
            method: "POST",
            params: { sizePage: pagerModel.pageElemnts, actualPage: pagerModel.currentPage},
            url: "http://localhost:60571/api/Projects1/ProjectPage"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectModelAmp[]>): IProjectModelAmp[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getProjectPage error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public getProjects(): ng.IPromise<IProjectModelAmp[]> {
        app.LogService.log("inicio getProjects ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/Projects1"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectModelAmp[]>): IProjectModelAmp[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getProjects error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public getProject(idProject: number): ng.IPromise<IProjectModelAmp> {
        app.LogService.log("inicio getProject ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            params: { id: idProject },
            url: API_BASE_URL + "api/Projects1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectModelAmp>): IProjectModelAmp => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getProject error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public saveProject(project: IProjectModel): ng.IPromise<IProjectModel> {
        app.LogService.log("inicio saveProject ...");

        return this._http({
            data: project,
            headers: { "Content-Type": "application/json" },
            method: "POST",
            url: API_BASE_URL + "api/Projects1/saveProject"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectModel>): IProjectModel => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getProject error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public modifyProject(project: IProjectModel): ng.IPromise<IProjectModel> {
        app.LogService.log("inicio modifyProject ...");

        return this._http({
            data: project,
            headers: { "Content-Type": "application/json" },
            method: "PUT",
            url: API_BASE_URL + "api/Projects1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectModel>): IProjectModel => {
            return successCallback.data;
        }).catch((reason: any) => {
            app.LogService.error(`modifyProject error:${angular.toJson(reason)}`);
            return this._q.reject(reason);
        });
    }

    public deleteProjects(idProject: number): ng.IPromise<void> {
        app.LogService.log("inicio deleteProjects ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "DELETE",
            params: { id: idProject },
            url: API_BASE_URL + "api/Projects1/removeProject"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IProjectModel>): IProjectModel => {

            return successCallback.data;

        }).catch((reason: any) => {

            app.LogService.error(`deleteProjects error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public countProjects(): ng.IPromise<ICount> {
        app.LogService.log("inicio countProjects ...");

        return this._http({
            //headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/Projects1/countProjects"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICount>): ICount => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`countProjects error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }
}

ProjectService.$inject = ["$http", "$q"];

app.registerService("projectService", ProjectService);
