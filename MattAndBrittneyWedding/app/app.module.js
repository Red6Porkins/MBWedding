(function () {
    angular.module('mbsite', [
        'ngRoute',
        'ui.bootstrap'
    ])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/app/home/home.html",
                controller: "homeController"
            });
    });
})();