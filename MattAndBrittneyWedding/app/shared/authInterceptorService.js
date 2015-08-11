(function () {
    angular.module('mbsite')
    .factory('authInterceptorService', ['$q', '$location', function ($q, $location, authService) {

        var request = function (config) {
            config.headers = config.headers || {};

            var authData = JSON.parse(localStorage.getItem('authorizationData'));
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData.token;
            }

            return config;
        };

        var responseError = function (rejection) {
            if (rejection.status === 401) {
                $location.path('/login');
            }
            return $q.reject(rejection);
        };

        return {
            request: request,
            responseError: responseError
        }       
    }]);
})();