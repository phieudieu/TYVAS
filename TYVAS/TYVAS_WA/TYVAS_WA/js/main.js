require.config({
    baseUrl: ".",

    paths: {
        // Aliases and paths of modules
        'angular': 'lib/angular/angular',
        ngRoute:"lib/angular/angular-route",
        'jquery' : 'lib/jquery/jquery-2.1.0.min',
        'oc.lazyLoad' : 'lib/ocLazyLoad/ocLazyLoad.min',
        ngTouch:"lib/angular/angular-touch.min",
        ngAnimate:"lib/angular/angular-animate.min",
        bootstrap: "lib/bootstrap/js/bootstrap.min",
        summernote: 'lib/angular-summernote/summernote',
        "angular.summernote": 'lib/angular-summernote/angular-summernote',
        "ui.bootstrap":"lib/bootstrap/js/ui-bootstrap-tpls-0.13.0.min",
        'lnsApp.directive' : 'js/common/directive',
        'lnsApp.service' : 'js/common/service',
        'lnsApp.controllers' : 'js/common/controller',
        

    },

    shim: {
        //Modules and their dependent modules
        angular: {
            exports: "angular"
        },
        ngRoute:["angular"],
        'jquery':'jquery',
        'oc.lazyLoad' : ['angular', 'jquery'],
        bootstrap : ['jquery'],
        ngTouch:["angular"],
        ngAnimate:["angular"],
        "ui.bootstrap": ["angular", 'bootstrap', 'ngTouch', 'ngAnimate'],
        summernote: ['jquery', "angular", 'bootstrap'],
        "angular.summernote": ['ui.bootstrap', 'summernote'],
        'lnsApp.directive' : ['js/common/directive'],
        'lnsApp.service' : ['js/common/service'],
        'lnsApp.controllers' : ['angular','lnsApp.directive','lnsApp.service']
    }
});