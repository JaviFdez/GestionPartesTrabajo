import { ICount } from "./../models/comons";
import { IPagerModel } from "app/models/comons";
import { app } from "app/main";

import "app/services/customers.service";

import { ICustomerModel } from "app/models/customers";
import { ICustomersService } from "app/services/customers.service";

export interface ICustomersController {
    Customers: ICustomerModel[];
}

/** Customerss Controller */
class CustomersController implements ICustomersController {

    // services
    private _scope: ng.IScope;
    private _customersService: ICustomersService;

    private _q: ng.IQService;

    private _page: number;

    private _totalPage: number;

    // variables miembro
    private _customers: ICustomerModel[];

    private _cutomersPageModel: IPagerModel;

    private _location: ng.ILocationService;

    constructor($scope: ng.IScope, $q: ng.IQService, customersService: ICustomersService, $location: ng.ILocationService) {
        this._scope = $scope;
        this._customersService = customersService;

        this._cutomersPageModel = {pageElemnts: 10, currentPage: 0} as IPagerModel;

        this._page = 0;

        this._q = $q;

        this._customers = [];

        this._init();
    }

    /** Customers */
    public get Customers(): ICustomerModel[] {
        return this._customers;
    }

    public get SizePage(): number {
        return this._page;
    }

    public set SizePage(i: number) {
        this._page = i;
    }

    public deleteCmd(idCustomer: number): void {

        this._customersService.deleteCustomer(idCustomer)
            .then((resultCallback: void) => {
                this._location.path("/customers/");
            });
    }

    public _canAdvance(): Boolean {
        return (this._page < this._totalPage);
    }

    public _canGoBack(): Boolean {
        return (this._page > 0);
    }

    public _clickAdvanced(): void {
        var i: number;
        i = this._page + 1;
        this.SizePage = i;
    }

    public _clickGoBack(): void {
        var i: number;
        i = this._page - 1;
        this.SizePage = i;
    }

    public _pageTotal(): ng.IPromise<void> {
        return this._customersService.countCustomers()
            .then((resultCallback: ICount) => {
                this._totalPage = Math
                    .floor((resultCallback.total - 1) / 1);
            });
    }

    public _reiniciarPage(): ng.IPromise<void> {
        return this._customersService.countCustomers()
            .then((resultCallback: ICount) => {
                this._cutomersPageModel.currentPage = 0;
                this._cutomersPageModel.totalItems = resultCallback.total;
                this._cutomersPageModel.totalPages = Math
                    .floor((resultCallback.total - 1) / this._cutomersPageModel.pageElemnts);
            });
    }

    public _obtenerPageCustomers(): ng.IPromise<void> {
        return this._customersService.getCustomers()
            .then((resultCallback: ICustomerModel[]) => {
                this._customers = resultCallback;
            });
    }

    private _init(): void {

        this._q.all([
            this._pageTotal(),
            this._reiniciarPage(),
            this._obtenerPageCustomers()
        ]);

    }




}

// establecer variables a inyectar en el controlador
// NOTA: (Deben seguir el mismo orden que el constructor del controlador)
CustomersController.$inject = ["$scope", "$q", "customersService", "$location"];

// registrar el controlador en la aplicacion
app.registerController("customersController", CustomersController);
