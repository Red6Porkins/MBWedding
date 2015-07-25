angular.module('mbsite', [
    'ngRoute'
])
.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
          templateUrl: "/app/home/home.html",
          controller: "homeController"  
      });
});