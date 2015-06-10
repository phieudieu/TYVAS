'use strict';
define(['js/common/service'],function(mod){
    mod.factory('newEventService',['$http', function($http){
        return
            new NewEventService($http);
    }]);
    function NewEventService($http) {
        this.$http = $http;
    }
})