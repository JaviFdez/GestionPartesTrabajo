import {app} from "app/main";
import "angular";


let mainHeaderComponent: ng.IComponentOptions = {
    controller: "MainHeaderComponentController",
    templateUrl: "app/components/mainHeader.component.html"
};

app.registerComponent("mainHeader", mainHeaderComponent);

class MainHeaderComponentController {

    constructor() {
    }
}

MainHeaderComponentController.$inject = [];
app.registerController("mainHeaderComponentController", MainHeaderComponentController);
