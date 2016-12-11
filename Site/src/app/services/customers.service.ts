import { app } from "app/main";
import { ICustomerModel } from "app/models/customers";
import { ICount } from "app/models/comons";
import { IPagerModel } from "app/models/comons";

/**
 * Servicio para la gestion de usuarios
 */
export interface ICustomersService {

    /**
     * Funcion para obtener los usuarios desde el servidor
     * @return Array de modelos de usuarios obtenidos
     */
    getCustomersPage(pagerModel: IPagerModel): ng.IPromise<ICustomerModel[]>;
    getCustomers(): ng.IPromise<ICustomerModel[]>;
    getCustomer(idCustomer: number): ng.IPromise<ICustomerModel>;
    saveCustomer(customer: ICustomerModel): ng.IPromise<ICustomerModel>;
    modifyCustomer(customer: ICustomerModel): ng.IPromise<ICustomerModel>;
    deleteCustomer(idCustomer: number): ng.IPromise<void>;
    countCustomers(): ng.IPromise<ICount>;
}

class CustomersService implements ICustomersService {

    // servicios
    private _http: ng.IHttpService;
    private _q: ng.IQService;

    constructor($http: ng.IHttpService, $q: ng.IQService) {
        this._http = $http;
        this._q = $q;
    }

    public countCustomers(): ng.IPromise<ICount> {
        app.LogService.log("inicio countCustomers ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/Customers1/countCustomers"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICount>): ICount => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`countCustomers error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }

    public getCustomersPage(pagerModel: IPagerModel): ng.IPromise<ICustomerModel[]> {

        app.LogService.log("inicio getCustomersPage ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            params: { sizePage: pagerModel.pageElemnts, actualPage: pagerModel.currentPage},
            url: "http://localhost:60571/api/Customers1/getCustomerPage"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICustomerModel[]>): ICustomerModel[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getCustomersPage error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });

    }

    public getCustomers(): ng.IPromise<ICustomerModel[]> {

        app.LogService.log("inicio getCustomers ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            url: API_BASE_URL + "api/Customers1"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICustomerModel[]>): ICustomerModel[] => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getCustomers error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });

    }


    public getCustomer(idcustomer: number): ng.IPromise<ICustomerModel> {

        app.LogService.log("inicio getCustomer ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "GET",
            params: { id: idcustomer },
            url: API_BASE_URL + "api/Customers1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICustomerModel>): ICustomerModel => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`getCustomer error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });

    }

    // Se le quita el params y se añade el data
    public saveCustomer(customer: ICustomerModel): ng.IPromise<ICustomerModel> {

        app.LogService.log("inicio saveCustomer ...");

        return this._http({
            data: customer,
            headers: { "Content-Type": "application/json" },
            method: "POST",
            url: API_BASE_URL + "api/Customers1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICustomerModel>): ICustomerModel => {
            return successCallback.data;
        }).catch((reason: any) => {
            app.LogService.error(`saveCustomer error:${angular.toJson(reason)}`);
            return this._q.reject(reason);
        });
    }

    // Se le quita el params y se añade el data
    public modifyCustomer(customer: ICustomerModel): ng.IPromise<ICustomerModel> {

        app.LogService.log("inicio modifyCustomer ...");

        return this._http({
            data: customer,
            headers: { "Content-Type": "application/json" },
            method: "PUT",
            url: API_BASE_URL + "api/Customers1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICustomerModel>): ICustomerModel => {
            return successCallback.data;
        }).catch((reason: any) => {
            app.LogService.error(`modifyCustomer error:${angular.toJson(reason)}`);
            return this._q.reject(reason);
        });
    }

    public deleteCustomer(idcustomer: number): ng.IPromise<void> {
        app.LogService.log("inicio deleteCustomer ...");

        return this._http({
            headers: { "Content-Type": "application/json" },
            method: "DELETE",
            params: { id: idcustomer },
            url: API_BASE_URL + "api/Customers1/"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<ICustomerModel>): ICustomerModel => {

            return successCallback.data;

        }).catch((reason: any) => {

            app.LogService.error(`deleteCustomer error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });

    }

}

// establecer variables a inyectar en el viewmodel
// NOTA: (Deben seguir el mismo orden que el constructor del viewmodel)
CustomersService.$inject = ["$http", "$q"];

// registrar el servicio en la aplicacion
app.registerService("customersService", CustomersService);
