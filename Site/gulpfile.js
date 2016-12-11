'use strict';
var gulp = require("gulp");
var debug = require("gulp-debug");
var del = require("del");

// Custom tasks modules
var tasksConfig = require("./tools/tasks/gulp-config");
require("./tools/tasks/gulp-thirdparty");
require("./tools/tasks/gulp-typescript");
require("./tools/tasks/gulp-html");
require("./tools/tasks/gulp-css");
require("./tools/tasks/gulp-mocks");
require("./tools/tasks/gulp-img");



/**
 * Build all project in output directory
 */
gulp.task("build-debug", ["publish-thirdparty", "build-ts-debug", "build-html", "build-mocks", "build-css", "build-img" , "configure-debug"]);

/**
 * Build all project in output directory
 */
gulp.task("build-release", ["publish-thirdparty", "build-ts-release", "build-html", "build-mocks", "build-css", "build-img" , "configure-release"]);

/**
 * Build all test project
 */
gulp.task("build-tests", ["build-ts-tests", "configure-debug"]);


/**
 * watch source files
 */
gulp.task("watch-source", function() {
        gulp.watch([tasksConfig.sourceScriptFiles], ["build-ts-debug", "configure-debug"]);
        gulp.watch([tasksConfig.sourceHtmlFiles], ["build-html"]);
        gulp.watch([tasksConfig.sourceCssFiles], ["build-css"]);
      //  gulp.watch([tasksConfig.sourceCssFiles], ["postcss"]);
         gulp.watch([tasksConfig.sourceImgFiles], ["build-img"]);
        gulp.watch([tasksConfig.sourceTestsScriptFiles], ["build-ts-tests", "configure-debug"]);
});

/**
 * clean output files
 */
gulp.task("clean-output", function() {

    // delete output
    del.sync([
        tasksConfig.outputAppFolder,
        tasksConfig.outputLibFolder,
        tasksConfig.outputContentFolder,
        tasksConfig.outputTestsFolder,
        tasksConfig.outputCssFolder,
        tasksConfig.outputImgFolder,
        tasksConfig.outputFolder + "index.html"
        ]);
});
