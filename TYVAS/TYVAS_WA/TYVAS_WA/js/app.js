'use strict';
define(['angular',
    'ngRoute',
    'oc.lazyLoad',
    'jquery',
    'bootstrap',
    'ngTouch',
    'ngAnimate',
    'ui.bootstrap',
    'summernote',
    'angular.summernote',
    'js/common/directive',
    'js/common/service',
    'js/common/controller',
    'js/directives/lnsBanner',
    'js/directives/lnsMenuTop',
    'js/directives/lnsFooter'
], function(angular){

    var app = angular.module('lnsApp',
        ['ngRoute', 'ngTouch', 'oc.lazyLoad', 'ui.bootstrap', 'ngAnimate', 'summernote',
            'lnsApp.directive','lnsApp.service','lnsApp.controllers'
        ]);

    return app;
});