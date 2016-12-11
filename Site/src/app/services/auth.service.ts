import { app } from "app/main";
 
import { ILoginModel, ITokenResponseModel } from "app/models/users";
 
const LOCAL_STORAGE_AUTH_KEY: string = "authorizationData";
const CLIENT_ID: string = "ngAuthApp";
 
/** Evento en rootscope para registrarse que sera invocado al realizarse un login */
export const EVT_LOGIN: string = "auth.service.evt.login";
/** Evento en rootscope para registrarse que sera invocado al realizarse un logout */
export const EVT_LOGOUT: string = "auth.service.evt.logout";

export interface  IAuthService {

    tryAddAuthToHttpHeader(headerObj: any): boolean;
    getAuthData(): ITokenResponseModel;

    login(loginData: ILoginModel): ng.IPromise<ITokenResponseModel | any>;
    logOut(): void;

    refreshToken(): ng.IPromise<ITokenResponseModel>;
}

class AuthService implements IAuthService {

    private _rootScope: ng.IRootScopeService;
    private _http: ng.IHttpService;
    private _q: ng.IQService;
    private _localStorageService: ng.local.storage.ILocalStorageService;

    private _autoRefreshTokenHandler: number;

    constructor($rootScope: ng.IRootScopeService, $http: ng.IHttpService, $q: ng.IQService, localStorageService: ng.local.storage.ILocalStorageService) {

        this._rootScope = $rootScope;
        this._http = $http;
        this._q = $q;
        this._localStorageService = localStorageService;

        if (this.getAuthData()) {
            this._enableAutoRefreshToken();
        }
    }

    public tryAddAuthToHttpHeader(headerObj: any): boolean {
        let result: boolean = false;

        let authData: ITokenResponseModel = this.getAuthData();
        if (undefined != authData && headerObj) {
            headerObj.Authorization = `Bearer ${authData.Token}`;
            result = true;
        }

        return result;
    }

    public getAuthData(): ITokenResponseModel {
        return this._localStorageService.get(LOCAL_STORAGE_AUTH_KEY) as ITokenResponseModel || undefined;
    }


    public login(loginData: ILoginModel): ng.IPromise<ITokenResponseModel | any>  {

        app.LogService.debug("auth.service - login ...");

        // eliminar datos de logon si ya se esta logueado
        if (this.getAuthData()) {
            this.logOut();
        }

        let params: any = {
            grant_type: "password",
            password: loginData.Password,
            username: loginData.Username
        };

        if (loginData.UseRefreshTokens) {
            params.client_id = CLIENT_ID;
        }

        return this._http({
            data: $.param(params),
            headers: { "Content-Type": "application/x-www-form-urlencoded" },
            method: "POST",
            url: API_BASE_URL + "token"
        })
        .then((resultCallback: ng.IHttpPromiseCallbackArg<any>): ITokenResponseModel => {
            app.LogService.debug("auth.service - login: " + angular.toJson(resultCallback.data));

            let loginResponse: ITokenResponseModel = {
                RefreshToken: loginData.UseRefreshTokens ? resultCallback.data.refresh_token : "",
                Token: resultCallback.data.access_token,
                UseRefreshTokens: loginData.UseRefreshTokens ? true : false,
                UserName: loginData.Username
            };

            this._localStorageService.set(LOCAL_STORAGE_AUTH_KEY, loginResponse);

            this._enableAutoRefreshToken();

            this._rootScope.$emit(EVT_LOGIN);

            return loginResponse;
        })
        .catch((reason: any) => {
            app.LogService.error("Error: auth.service - login: " + angular.toJson(reason.data));
            this.logOut();
            return this._q.reject(reason);
        });

    }

    public logOut(): void {
        this._localStorageService.remove(LOCAL_STORAGE_AUTH_KEY);

        this._disableAutoRefreshToken();

        this._rootScope.$emit(EVT_LOGOUT);
        app.LogService.debug("auth.service - logOut");
    }

    public refreshToken(): ng.IPromise<ITokenResponseModel | any> {

        app.LogService.debug("auth.service - refreshToken ...");

        let authData: ITokenResponseModel = this._localStorageService.get(LOCAL_STORAGE_AUTH_KEY) as ITokenResponseModel;

        if (authData && authData.UseRefreshTokens) {

            let params: any = {
                client_id: CLIENT_ID,
                grant_type: "refresh_token",
                refresh_token: authData.RefreshToken
            };

            this._localStorageService.remove(LOCAL_STORAGE_AUTH_KEY);

            return this._http({
                data: $.param(params),
                headers: {"Content-Type": "application/x-www-form-urlencoded"},
                method: "POST",
                url: API_BASE_URL + "token"
            })
            .then((resultCallback: ng.IHttpPromiseCallbackArg<any>): ITokenResponseModel => {
                app.LogService.debug("auth.service - refreshToken: " + angular.toJson(resultCallback.data));

                let loginResponse: ITokenResponseModel = {
                    RefreshToken: resultCallback.data.refresh_token,
                    Token: resultCallback.data.access_token,
                    UseRefreshTokens: true,
                    UserName: resultCallback.data.userName
                };

                this._localStorageService.set(LOCAL_STORAGE_AUTH_KEY, loginResponse);

                this._rootScope.$emit(EVT_LOGIN);

                return loginResponse;
            })
            .catch((reason: any) => {
                app.LogService.error("Error: auth.service - refreshToken: " + angular.toJson(reason.data));
                this.logOut();
                return this._q.reject(reason);
            });

        } else {
            return this._q.reject("Operacion invalida");
        }
    }

    private getCurrentUser(): void //ng.IPromise<void> 
    {
        /*return this._http(({
            method: "GET",
            url: API_BASE_URL + "api/Account"
        }).then((resultCallBack: ng.IHttpPromiseCallbackArg<IUserModel>): void = {
            this._c
        })*/
    }

    private _enableAutoRefreshToken(): void {
 
        // establecer la funcion para realizar un refreshtoken automaticamente cada 15 minutos (antes de que expire la sesion)
        let authData: ITokenResponseModel = this.getAuthData();
 
        if (authData && authData.UseRefreshTokens) {
            this._autoRefreshTokenHandler = window.setInterval(() => {
 
                this.refreshToken().then((resultCallback: ITokenResponseModel) => {
                    app.LogService.log(`autoRefreshToken, new token: ${resultCallback.Token}`);
                })
                .catch((reason: any) => {
                    app.LogService.error("Error: autoRefreshToken: " + angular.toJson(reason.data));
                });
 
            }, 15 * 60 * 1000);
        }
    }
 
    private _disableAutoRefreshToken(): void {
        window.clearInterval(this._autoRefreshTokenHandler);
    }
 
};
 
 
// NOTA: (Deben seguir el mismo orden que el constructor del viewmodel)
AuthService.$inject = ["$rootScope", "$http", "$q", "localStorageService"];
app.registerService("authService", AuthService);