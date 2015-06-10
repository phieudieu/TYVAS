'use strict';
define(['angular'
], function(angular){

    var lnsAppDirective = angular.module('lnsApp.directive',
        []);
        lnsAppDirective.config(function ($controllerProvider, $compileProvider, $filterProvider, $provide) {
        lnsAppDirective.controller = $controllerProvider.register;
        lnsAppDirective.directive  = $compileProvider.directive;
        lnsAppDirective.filter     = $filterProvider.register;
        lnsAppDirective.factory    = $provide.factory;
        lnsAppDirective.service    = $provide.service;

    });
    lnsAppDirective.directive('bindCompiledHtml', bindCompiledHtml);
    function bindCompiledHtml($compile) {
        return {
            restrict: 'A',
            link: function($scope, $element, $attrs) {
                var html = $scope.$eval($attrs.bindCompiledHtml),
                    toCompile = angular.element(html);
                $element.append($compile(toCompile)($scope));
            }
        };
    }
    return lnsAppDirective;
});