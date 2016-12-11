// -----------------------------------------------
// Task for manage img project files
'use strict';

var gulp = require("gulp");


var tasksConfig = require("./gulp-config");

/**
 * lint and build img files
 */
gulp.task("build-img", function () {
    return build();
});

/**
 * lint img source code
 */
gulp.task("lint-img", function () {
    return lint();
});

function build()
{
    // send img to output folder
    gulp.src(tasksConfig.sourceImgFiles)
    .pipe(gulp.dest(tasksConfig.outputImgFolder));
 
}

function lint()
{

};
