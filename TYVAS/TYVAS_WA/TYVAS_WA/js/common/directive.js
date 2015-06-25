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
    lnsAppDirective.directive('zUploadview', ['$http', function ($http) {
        return {
            scope: {
                attachments: '=zUploadview',
            },
            templateUrl: 'views/partials/common/upload.html',
            replace: true,
            link: function (scope, element, attrs) {
                scope.dataUrl = "file/upload";
                var dropZone = element.closest(".dropzone");
                var opts = { autoUpload: true, url: scope.dataUrl };
                var defaultOpts = {
                    dataType: 'json',
                    dropZone: dropZone,
                    add: function (e, data) {
                        /* if (scope.filter != undefined) {
                             for (var index in data.files) {
                                 if (getFileType(data.files[index].name) != scope.filter) {
                                     return;
                                 }
                             }
                         }*/
                        if (opts.autoUpload) {
                            scope.percentage = 0;//to show progress bar
                            data.submit();
                            scope.$apply();
                        }
                    },
                    progress: function (e, data) {
                        var progress = parseInt(data.loaded / data.total * 100, 10);
                        scope.percentage = progress;
                        scope.$apply();
                    },
                    done: function (e, data) {
                        var files = data.result && data.result.files;
                        if (files) {
                            if (scope.attachments == null || scope.attachments == undefined)
                                scope.attachments = [];
                            for (var i = 0; i < files.length; i++) {
                                if ($.inArray(files[i], scope.attachments) == -1)
                                    scope.attachments.push(files[i]);
                                if (scope.onUploadDone != undefined) {
                                    scope.onUploadDone({ "file": files[i] });
                                }
                            }
                            scope.files = [];
                        }
                        scope.percentage = -1;
                        scope.$apply();
                    }
                };
                var inputFile = element.find("input[type='file']");
                opts = angular.extend(defaultOpts, opts);
                inputFile.fileupload(opts);
                scope.percentage = -1;
                scope.files = [];
                scope.getFileType = function (filename) {
                    return getFileType(filename);
                };

                scope.removeUploadedFile = function (file) {
                   
                };
            }
        };
    }]);
    return lnsAppDirective;
});