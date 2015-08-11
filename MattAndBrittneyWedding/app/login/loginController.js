(function () {
    angular.module("mbsite")
    .controller("loginController", ['$scope', '$location', 'authService', function ($scope, $location, authService) {
       
        $scope.loggingIn = false;
        $scope.loginData = { userName: "", password: "" };

        $scope.login = function () {
            $scope.loggingIn = true;
            authService.login($scope.loginData).then(
                function (response) {
                    $location.path('/admin');
                    $scope.loggingIn = false;
                    $scope.invalidAuth = false;
                },
                function (response) {
                    $scope.errorMessage = response.error_description;
                    $scope.loggingIn = false;
                    $scope.invalidAuth = true;
                });
        }
    }]);
})();