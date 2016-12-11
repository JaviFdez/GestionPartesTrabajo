import { app } from "app/main";

import "app/services/auth.service";

import { IAuthService } from "app/services/auth.service";

import { ITokenResponseModel } from "app/models/users.d";
import { ILoginModel } from "app/models/users";

export interface ILoginController {
    User: ILoginModel;
}

class LoginController implements ILoginController {

    private _scope: ng.IScope;
    private _q: ng.IQService;

    private _authService: IAuthService;

    private _user: ILoginModel;
    private _token: ITokenResponseModel;

    constructor($scope: ng.IScope, $q: ng.IQService, authService: IAuthService) {
        this._q = $q;
        this._scope = $scope;

        this._user = {} as ILoginModel;
        this._token = {} as ITokenResponseModel;

        this._authService = authService;

    }

    public get User(): ILoginModel {
        return this._user;
    }

    public get Token(): ITokenResponseModel {
        return this._token;
    }

    private _login(): ng.IPromise<void> {
        return this._authService.login(this._user)
            .then((resultCallback: ITokenResponseModel) => {
                this._token = resultCallback;
                alert(this._token);
            });
    }
}

LoginController.$inject = ["$scope", "$q", "authService"];

app.registerController("loginController", LoginController);
