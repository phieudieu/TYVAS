'use strict';
define([
    //Dependencies (by requirejs) ex: paths service to inject
    'js/common/controller',
    'js/controllers/topEventCtrl',
    'js/directives/lnsTopEvent',
    'js/directives/lnsBlockRight',
    'js/directives/lnsMainEvent'
], function(app){
    app.controller('HomePage',['$scope', '$http','$sce',function($scope, $http, $sce) {

        $scope.mainContent = [
            {'name': '<div lns-top-event></div>'},
            {'name': '<div lns-main-event></div>'}
        ];
        $scope.rightContent = [
            {'name' : '<div lns-block-right> </div>'}
        ];
    }]);
})