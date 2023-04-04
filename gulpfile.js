var gulp = require('gulp'),
    sevenBin = require('7zip-bin'),
    sevenZip = require('node-7z'),
    less = require('gulp-less');

var app = 'Screenshot';
var release = 'bin/Release/net6.0/win-x64/publish/';
var publish = 'bin/Publish/';

function publishToPlatform() {
    //include selenium-manager from publish folder
    gulp.src([
        release + 'selenium-manager/**'
    ]).pipe(gulp.dest(publish + '/' + app + "/selenium-manager", { overwrite: true }));

    return gulp.src([
        //include files from published folder
        release + 'chromedriver.exe',
        release + 'LICENSE',
        release + 'Newtonsoft.Json.dll',
        release + 'README.md',
        release + 'Saber.Vendors.Screenshot.dll',
        release + 'Saber.Vendors.Screenshot.pdb',
        release + 'WebDriver.dll',
        release + 'WebDriver.Support.dll',
    ]).pipe(gulp.dest(publish + '/' + app, { overwrite: true }));
}

gulp.task('publish:x64', () => {
    return publishToPlatform();
});

gulp.task('zip', () => {
    setTimeout(() => {
        //wait 500ms before creating zip to ensure no files are locked
        process.chdir(publish);
        sevenZip.add(app + '.7z', app, {
            $bin: sevenBin.path7za,
            recursive: true
        });
        process.chdir('../..');
    }, 500);
    return gulp.src('.');
});

gulp.task('publish', gulp.series('publish:x64', 'zip'));