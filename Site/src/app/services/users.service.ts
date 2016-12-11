import { app } from "app/main";


import { IAuthService, EVT_LOGIN, EVT_LOGOUT } from "app/services/auth.service";

import { IUserModel } from "app/models/users";

/**
 * Servicio para la gestion de usuarios
 */
export interface IUsersService {



    getUsers(): ng.IPromise<IUserModel[]>;
    saveUser(user: IUserModel): ng.IPromise<void>;
    //getCurrentUser(): ng.IPromise<IUserModel>;
}

class UsersService implements IUsersService {

    // servicios
    private _rootScope: ng.IRootScopeService;
    private _http: ng.IHttpService;
    private _q: ng.IQService;
    private _authService: IAuthService;
 
    // variables miembro
    private _currentUser: IUserModel;

    constructor($rootScope: ng.IRootScopeService, $http: ng.IHttpService, $q: ng.IQService, authService: IAuthService) {
        this._http = $http;
        this._q = $q;

        this._authService = authService;

        //this._init();

    }


    public getUsers(): ng.IPromise<IUserModel[]> {
        app.LogService.log("inicio getUsers ...");

        return this._http({
                headers: { "Content-Type": "application/json" },
                method: "GET",
                url: "http://localhost:60571/api/Users1"
            }).then((successCallback: ng.IHttpPromiseCallbackArg<IUserModel[]>): IUserModel[] => {

                return successCallback.data;

            }).catch((reason: any) => {

                return this._q.reject(reason);

            });

    }

    public saveUser(user: IUserModel): ng.IPromise<void> {

        return this._http({
                headers: { "Content-Type": "application/json" },
                method: "POST",
                url: "http://localhost:60571/api/Users1"
            }).then((successCallback: ng.IHttpPromiseCallbackArg<IUserModel>): IUserModel => {

                return successCallback.data;

            }).catch((reason: any) => {

                return this._q.reject(reason);

            });

    }

    public getCurrentUser(): ng.IPromise<IUserModel> {
 
        let deferred: angular.IDeferred<IUserModel> = this._q.defer();
 
        // si existen datos de autenticacion y no del usuario conectado, es por que aun no se a invocado el servicio, de modo que
        // se suscribe al evento ocurrido al obtenerse los datos de usuario
        if (this._authService.getAuthData() !== undefined && this._currentUser == undefined) {
 
            let unwatchEvt: Function = this._rootScope.$on(EVT_USERINFO_LOADED, () => {
 
                // eliminar el registro del evento
                unwatchEvt();
                deferred.resolve(this._currentUser);
            });
 
        } else {
            deferred.resolve(this._currentUser);
        }
 
        return deferred.promise;
    }

    private _init(): void {
 
        if (this._authService.getAuthData() !== undefined) {
            this._getCurrentUser();
        }
 
        this._rootScope.$on(EVT_LOGIN, () => {
 
            this._getCurrentUser();
        });
 
        this._rootScope.$on(EVT_LOGOUT, () => {
            this._currentUser = undefined;
        });
    }

   private _getCurrentUser(): ng.IPromise<void> {
 
        app.LogService.log("usuario.service - _getCurrentUser: ...");
 
        return this._http({
            method: "GET",
            url: API_BASE_URL + "api/Account"
        })
        .then((resultCallback: ng.IHttpPromiseCallbackArg<IUserModel>): void => {
            app.LogService.log("usuario.service - _getCurrentUser: " + angular.toJson(resultCallback.data));
            this._currentUser = resultCallback.data;
 
            this._rootScope.$emit(EVT_USERINFO_LOADED);
        })
        .catch((reason: any) => {
            app.LogService.error("Error: usuario.service - _getCurrentUser: " + angular.toJson(reason.data));
        });
    }

}

// establecer variables a inyectar en el viewmodel
// NOTA: (Deben seguir el mismo orden que el constructor del viewmodel)
UsersService.$inject = ["$rootScope", "$http", "$q", "authService"];

// registrar el servicio en la aplicacion
app.registerService("usersService", UsersService);
