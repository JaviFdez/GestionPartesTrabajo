import { app } from "app/main";
import "app/services/customers.service";
import { ICustomerModel } from "app/models/customers";
import { ICustomersService } from "app/services/customers.service";

// Indica que cuando lo llamemos tiene que recuperar
// el parametro tiene el nombre del route config
interface ICustomRouteParams extends ng.route.IRouteParamsService {
    idCustomer: number;
}

export interface ICustomerController {
    Customer: ICustomerModel;
}

export interface ICustomScope extends ng.IScope {
    customerForm: ng.IFormController;
}



/** Customer Controller */
class CustomerController implements ICustomerController {

    // services
    private _scope: ICustomScope;
    private _customersService: ICustomersService;

    // variables miembro
    private _customer: ICustomerModel;
    private _isNewCustomer: boolean;
    private _location: ng.ILocationService;

    private _activeRequest: boolean;

    constructor($scope: ICustomScope, customersService: ICustomersService, $routeParams: ICustomRouteParams, $location: ng.ILocationService) {
        this._scope = $scope;
        this._customersService = customersService;
        this._customer = {} as ICustomerModel;
        this._isNewCustomer = $routeParams.idCustomer ? false : true;
        this._customer.Id = $routeParams.idCustomer;
        this._location = $location;


        this._activeRequest = false;
        this._init();
    }

    /** Customers */
    public get Customer(): ICustomerModel {
        return this._customer;
    }

    // Como la api tiene el guardar en el mismo metodo esto no hace falta

    public get IsNewCustomer(): boolean {
        return this._isNewCustomer;
    }

    public saveClickCmd(): void {

        this._activeRequest = true;

        let service: ng.IPromise<ICustomerModel> = undefined;

        service = this._isNewCustomer ?
            this._customersService.saveCustomer(this._customer) :
            this._customersService.modifyCustomer(this._customer);

        service.then((resultCallback: ICustomerModel) => {
            this._customer = resultCallback;
        })
        .catch((reason: any) => {
            alert("No se se pueden obtener customers");
        })
        .finally(() => { this._activeRequest = false; });
    }

    public saveClickCanCmd(): boolean {
        return !this._activeRequest && this._scope.customerForm.$valid;
    }




    private _init(): void {

        if (!this._isNewCustomer) {
            this._getCustomer();
        }
    }

    private _getCustomer(): ng.IPromise<void> {

        return this._customersService.getCustomer(this._customer.Id).then((resultCallback: ICustomerModel) => {
            this._customer = resultCallback;
        }).catch((reason: any) => {
            alert("No se se pueden obtener customers");
        });
    }


}

// establecer variables a inyectar en el controlador
// NOTA: (Deben seguir el mismo orden que el constructor del controlador)
CustomerController.$inject = ["$scope", "customersService", "$routeParams", "$location"];

// registrar el controlador en la aplicacion
app.registerController("customerController", CustomerController);
