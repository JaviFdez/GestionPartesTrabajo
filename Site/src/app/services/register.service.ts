import { app } from "app/main";

import { IUserModelRegister } from "app/models/users";

export interface IRegisterUserService {
    register(userModel: IUserModelRegister): ng.IPromise<void>;
}

class RegisterUserService implements IRegisterUserService {

    private _http: ng.IHttpService;
    private _q: ng.IQService;

    constructor($http: ng.IHttpService, $q: ng.IQService) {
        this._http = $http;
        this._q = $q;
    }

    public register(userModel: IUserModelRegister): ng.IPromise<void> {
        return this._http({
            data: userModel,
            headers: { "Content-Type": "application/json" },
            method: "POST",
            url: "http://localhost:60571/api/Account/Register"
        }).then((successCallback: ng.IHttpPromiseCallbackArg<IUserModelRegister>): IUserModelRegister => {

            return successCallback.data;

        }).catch((reason: any) => {
            app.LogService.error(`register error:${angular.toJson(reason)}`);
            return this._q.reject(reason);

        });
    }
}

RegisterUserService.$inject = ["$http", "$q"];

app.registerService("registerUserService", RegisterUserService);
