import { app } from "app/main";

import "app/services/register.service";

import { IUserModelRegister } from "app/models/users";
import { IRegisterUserService } from "app/services/register.service";

export interface IRegisterController {
    User: IUserModelRegister;
}

class RegisterController implements IRegisterController {

    private _scope: ng.IScope;
    private _q: ng.IQService;

    private _registerUserService: IRegisterUserService;
    private _user: IUserModelRegister;

    constructor($scope: ng.IScope, $q: ng.IQService , registerUserService: IRegisterUserService) {
        this._q = $q;
        this._scope = $scope;

        this._registerUserService = registerUserService;
        this._user = {} as IUserModelRegister;

    }

    public get User(): IUserModelRegister {
        return this._user;
    }

     private _register(): void {
        this._registerUserService.register(this._user);
    }
}

RegisterController.$inject = ["$scope", "$q", "registerUserService"];

app.registerController("registerController", RegisterController);
