'use strict';
define(['js/common/service'],function(mod){
    mod.factory('newEventService',['$http',"$q", function($http, $q){
        return new NewEventService($http, $q);
    }]);

    function NewEventService($http,$q) {
        this.$http = $http;
        this.event = {};
        this.listRef = [];
        this.$q= $q;
    }
    NewEventService.prototype.newEvent = function(){
        var self = this;
        self.event = {
            m_ID : null,
            m_Title : Null,
            m_Description : Null,
            m_Address : Null,
            m_Reference : Null,
            m_StartDate: null,
            m_EndDate: null,
            m_Images : Null,
            m_Banner : Null,
            m_Status : null,
            m_Amount : null,
            m_FeeJoin : null,
            m_NUMBER : null
        }
        this.listRef = [];
    }
    NewEventService.prototype.addNewEvent = function() {
        var self =this;
        var url = "api/Events";
        self.event.m_Reference = self.listRef;
        if(self.event.m_ID != null) {
            url="api/Events/fff";
        }

        var result = self.$http.post(url, self.event).then(function(response) {
            return response.data;
        });
        return result;
    }
})