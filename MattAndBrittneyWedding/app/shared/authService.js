(function () {
    angular.module('mbsite')
    .factory('authService', ['$http', '$q', function ($http, $q) {

        var login = function (loginData) {

            var deffered = $q.defer();
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password; 

            $http.post('/token', data,
                { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
            .success(function (response) {
                var storeageObject = { token: response.access_token, userName: loginData.userName };
                localStorage.setItem('authorizationData', JSON.stringify(storeageObject));
                
                userData.userName = loginData.userName;
                userData.isAuth = true;

                deffered.resolve(response);
            }).error(function (response) {
                logout();
                deffered.reject(response);
            });
            return deffered.promise;
        };

        var logout = function () {
            localStorage.removeItem('authorizationData');
            userData.userName = "";
            userData.isAuth = false;
        };
        
        var fillAuthData = function () {
            var authData = JSON.parse(localStorage.getItem('authorizationData'));
            if (authData) {
                userData.userName = authData.userName;
                userData.isAuth = true; 
            }
        };

        var userData = {
            userName: "", 
            isAuth: false
        }

        return {
            login: login,
            logout: logout,
            userData: userData,
            fillAuthData: fillAuthData
        };
    }]);
})();