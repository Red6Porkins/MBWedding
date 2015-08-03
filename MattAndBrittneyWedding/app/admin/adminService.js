(function () {
    angular.module("mbsite")
    .factory("adminService", ['$http', function ($http) {

        var getGuestbook = function () {
            return $http.get('/api/guestbook/getall', {
                headers: { 'Accept': 'application/json' }
            }).then(function (response) {
                return response.data;
            });
        }

        var approveEntry = function (ID) {
            return $http.put('api/guestbook/' + ID);
        }
        
        var removeEntry = function (ID) {
            return $http.delete('api/guestbook/' + ID);               
        }
        
        return {
            getGuestbook: getGuestbook,
            removeEntry: removeEntry,
            approveEntry: approveEntry
        }
    }]);
})();