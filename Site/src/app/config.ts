/* tslint:disable no-reference */
/// <reference path="../../typings/browser.d.ts" />


// base url for website/virtual directory/platform (Ended with'/')
const BASE_URL: string = "<%= BASE_URL %>";

const API_BASE_URL: string = "<%= API_BASE_URL %>";

// application name
const APP_NAME: string = "<%= APP_NAME %>";
// flag for configure app for running tests execution
const IS_RUNNING_TESTS: boolean = false;

// requirejs configuration
requirejs.config({
    baseUrl: BASE_URL,
    // urlArgs: "bust=" + (new Date()).getTime(),
    paths: {

        "angular": ["//cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.8/angular.min", "lib/angular.min"],
        "angular-animate": ["//cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.8/angular-animate.min", "lib/angular-animate.min"],
        "angular-cookies": ["//cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.8/angular-cookies.min", "lib/angular-cookies.min"],
        "angular-route": ["//cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.8/angular-route.min", "lib/angular-route.min"],
        "angular-sanitize": ["//cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.8/angular-sanitize.min", "lib/angular-sanitize.min"],
        "angular-translate": ["//cdnjs.cloudflare.com/ajax/libs/angular-translate/2.12.1/angular-translate.min", "lib/angular-translate.min"],
        "angular-local-storage": "lib/angular-local-storage.min",
        //"angular-bootstrap": ["//cdnjs.cloudflare.com/ajax/libs/angular-bootstrap/2.0.1/angular-bootstrap.min", "lib/angular-bootstrap.min"],

        "bootstrap": ["//ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/bootstrap.min", "lib/bootstrap.min"],
        "jquery": ["//ajax.aspnetcdn.com/ajax/jQuery/jquery-2.2.3.min", "lib/jquery.min"],
        "modernizr": "lib/modernizr",
        "domReady": "lib/domReady"

    },
    shim: {

        "angular": {
            deps: ["jquery"],
            exports: "angular"
        },
        "angular-animate": ["angular"],
        "angular-cookies": ["angular"],
        "angular-route": ["angular"],
        "angular-sanitize": ["angular"],
        "angular-translate": ["angular"],
        "angular-local-storage": ["angular"],
        //"angular-bootstrap": ["angular"],

        "bootstrap": {
            deps: ["jquery"]
        }
    }

});


// start app when dom is loaded
requirejs(["lib/domReady!",
            "angular",
            "angular-animate",
            "angular-cookies",
            "angular-route",
            "angular-sanitize",
            "angular-translate",
            //"angular-bootstrap",
            "bootstrap"],
            (_document: Document) => {

	        // start app when dom is loaded
            requirejs(["app/main"], (_main: any) =>
                {

                });

            }
);
