import {app} from "app/main";
import "angular";


let mainFooterComponent: ng.IComponentOptions = {
    controller: "MainFooterComponentController",
    templateUrl: "app/components/mainFooter.component.html"
};

app.registerComponent("mainFooter", mainFooterComponent);

class MainFooterComponentController {

    constructor() {
    }
}

MainFooterComponentController.$inject = [];
app.registerController("mainFooterComponentController", MainFooterComponentController);
