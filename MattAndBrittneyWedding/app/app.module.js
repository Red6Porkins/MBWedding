(function () {
    angular.module('mbsite', [
        'ngRoute',
        'ui.bootstrap',
        'ngAnimate',
        'timer',  
        'sticky', //side bar
        'masonry' //guestbook
    ])
    .config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {
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
            .when('/admin', {
                templateUrl: '/app/admin/admin.html',
                controller: 'adminController',
                access: {
                    requiresLogin: true
                }
            })
            .when('/login', {
                templateUrl: '/app/login/login.html',
                controller: 'loginController'
            })
            .otherwise({ redirectTo: '/' });
        
        $httpProvider
            .interceptors.push('authInterceptorService');
    }])
    .run(['$rootScope', '$location', 'authService', function ($rootScope, $location, authService) {
        authService.fillAuthData();

        $rootScope.$on('$routeChangeStart', function (event, next) {
            if (next.access !== undefined) {
               console.log("auth required") 
                if (!authService.userData.isAuth) {
                    $location.path('/login');
                }                
            }
        });

        console.log("For any of my developer friends poking around, I really like Hochstaders Slow and Low Rye Whiskey");
    }]);

    //woo easter eggs
    $(window).konami({
        cheat: function () {
            console.log("KONAMI ACTIVATED! ALL YOUR ELEMENTS ARE BELONG TO US");
            var s = document.createElement('script'); s.setAttribute('src', 'https://nthitz.github.io/turndownforwhatjs/tdfw.js');
            document.body.appendChild(s);
        }
    });
})();