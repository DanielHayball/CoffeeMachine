var gulp = require("gulp"),
    less = require("gulp-less"),
    cleanCss = require("gulp-clean-css");

async function buildCss() {
    return promisifyStream(gulp.src(['./styles/**/*.less'])
        .pipe(less())
        .pipe(gulp.dest('./wwwroot/css'))
    );
}

//async function minifyCss() {
//    return promisifyStream(gulp.src(['./wwwroot/**/*.css'])
//        .pipe(less())
//        .pipe(cleanCss({ compatibility: 'ie11' }))
//        .pipe(gulp.dest('./wwwroot/**/*.min.css'))
//    );
//}

function promisifyStream(stream) {
    return new Promise(resolve => stream.on('end', resolve));
}

exports.buildCss = buildCss;

//exports.minifyCss = minifyCss;

exports.watch = gulp.parallel(
    function () {
        gulp.watch(['./styles/**/*.less'],
            { delay: 1000 },
            gulp.series(
                gulp.parallel(
                    buildCss,
                )
            )
        )
    }
)

