import { app } from "app/main";

import { IWOModel, IWOModelAmp  } from "app/models/workOrders";
import { ICount, IPagerModel, IFiltrosWOModel } from "app/models/comons";

export interface IWorkOrdersService {

    getWOPage(filtros: IFiltrosWOModel, pagerModel: IPagerModel): ng.IPromise<IWOModelAmp[]>;
    getWorkOrders(): ng.IPromise<IWOModelAmp[]>;
    getWorkOrder(idProject: number): ng.IPromise<IWOModelAmp>;
    saveWorkOrder(project: IWOModel): ng.IPromise<IWOModel>;
    modifyWorkOrder(project: IWOModel): ng.IPromise<IWOModel>;
    deleteWorkOrders(idProject: number): ng.IPromise<void>;
    countWorkOrders(): ng.IPromise<ICount>;
}

class WorkOrdersService implements IWorkOrdersService {

    private _http: ng.IHttpService;
    private _q: ng.IQService;

    constructor($http: ng.IHttpService, $q: ng.IQService) {
        this._http = $http;
        this._q = $q;
    }

    public getWOPage(filtros: IFiltrosWOModel, pagerModel: IPagerModel): ng.IPromise<IWOModelAmp[]> {
        app.LogService.log("inicio getWOPage...");

        return this._http({
            data: filtros,
            headers: { "Content-Type": "application/json" },
            method: "POST",
            params: { sizePage: pagerModel.pageElemnts, actualPage: pagerModel.currentPage},
            url: "http://localhost:60571/api/WorkOrders1/WorkOrderPage"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IWOModelAmp[]>): IWOModelAmp[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getWOPage error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public getWorkOrders(): ng.IPromise<IWOModelAmp[]> {

        app.LogService.log("inicio getWorkOrders ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/WorkOrders1"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IWOModel[]>): IWOModel[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getWorkOrders error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public getWorkOrder(idWorkOrder: number): ng.IPromise<IWOModelAmp> {

        app.LogService.log("inicio getWorkOrder ...");

        return this._http({
            params: {id: idWorkOrder},
            headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/WorkOrders1"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IWOModelAmp>): IWOModelAmp => {
            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getWorkOrder error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public saveWorkOrder(project: IWOModel): ng.IPromise<IWOModel> {

        app.LogService.log("inicio saveWorkOrder ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "POST",
            url: API_BASE_URL + "api/WorkOrders1/saveWorkOrder"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IWOModel>): IWOModel => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`saveWorkOrder error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public modifyWorkOrder(project: IWOModel): ng.IPromise<IWOModel> {
        app.LogService.log("inicio modifyWorkOrder ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "PUT",
            url: API_BASE_URL + "api/WorkOrders1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IWOModel>): IWOModel => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`modifyWorkOrder error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public deleteWorkOrders(idProject: number): ng.IPromise<void> {

        app.LogService.log("inicio deleteWorkOrders ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "PUT",
            url: API_BASE_URL + "api/WorkOrders1/removeWorkOrder"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IWOModel>): IWOModel => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`deleteWorkOrders error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public countWorkOrders(): ng.IPromise<ICount> {

        app.LogService.log("inicio countWorkOrders ...");

        return this._http({
            // headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/WorkOrders1/countWorkOrders"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICount>): ICount => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`countProjects error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

}

WorkOrdersService.$inject = ["$http", "$q"];
app.registerService("workOrdersService", WorkOrdersService);
