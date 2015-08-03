(function () {
    angular.module('mbsite', [
        'ngRoute',
        'ui.bootstrap',
        'ngAnimate',
        'timer',
        'sticky'
    ])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/app/home/home.html',
                controller: 'homeController'
            })
            .when('/ourstory', {
                templateUrl: '/app/our-story/ourStory.html',
                controller: 'ourStoryController'
            })
            .when('/gallery', {
                templateUrl: '/app/gallery/gallery.html',
                controller: 'galleryController'
            })
            .when('/guestbook', {
                templateUrl: '/app/guestbook/guestbook.html',
                controller: 'guestbookController'
            })
            .otherwise({ redirectTo: '/' });
    });
})();