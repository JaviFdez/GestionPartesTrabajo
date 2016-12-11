import { IRouteResolverProvider } from "app/services/routeResolver.provider";

export class RoutesConfig {

    /** Function for initialize app routes */
    public static initialize(routeProvider: ng.route.IRouteProvider, routeResolverProvider: IRouteResolverProvider): void {

        // DEFAULT
        routeProvider.otherwise({ redirectTo: "/home" });

        // MAIN ROUTES
        routeProvider.when("/about", routeResolverProvider.resolve({ controllerAs: "vm", path: "about" }));
        routeProvider.when("/contact", routeResolverProvider.resolve({ controllerAs: "vm", path: "contact" }));
        routeProvider.when("/home", routeResolverProvider.resolve({ controllerAs: "vm", path: "home" }));
        routeProvider.when("/users", routeResolverProvider.resolve({ controllerAs: "vm", path: "users" }));
        routeProvider.when("/customers", routeResolverProvider.resolve({ controllerAs: "vm", path: "customers" }));
        routeProvider.when("/projects", routeResolverProvider.resolve({ controllerAs: "vm", path: "projects" }));
        routeProvider.when("/workorders", routeResolverProvider.resolve({ controllerAs: "vm", path: "workorders" }));
        routeProvider.when("/login", routeResolverProvider.resolve({ controllerAs: "vm", path: "login" }));
        routeProvider.when("/register", routeResolverProvider.resolve({ controllerAs: "vm", path: "register" }));
        // routeProvider.when("/customers/:idCustomer?", routeResolverProvider.resolve({ controllerAs: "vm", path: "customers" }));

        routeProvider.when("/customer/:idCustomer?", routeResolverProvider.resolve({ controllerAs: "vm", path: "customer" }));
        routeProvider.when("/customer/", routeResolverProvider.resolve({ controllerAs: "vm", path: "customer" }));
        routeProvider.when("/project/:idProject?", routeResolverProvider.resolve({ controllerAs: "vm", path: "project" }));
        routeProvider.when("/project/", routeResolverProvider.resolve({ controllerAs: "vm", path: "project" }));
        routeProvider.when("/workorder/:idWO?", routeResolverProvider.resolve({ controllerAs: "vm", path: "workorder" }));
        routeProvider.when("/workorder/", routeResolverProvider.resolve({ controllerAs: "vm", path: "workorder" }));
    }
}
