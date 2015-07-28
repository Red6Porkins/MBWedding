(function () {
    angular.module('mbsite', [
        'ngRoute',
        'ui.bootstrap',
        'ngAnimate',
        'timer'
    ])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/app/home/home.html',
                controller: 'homeController'
            })
            .otherwise({ redirectTo: '/' });
    });
})();