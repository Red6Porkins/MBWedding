(function () {
    angular.module('mbsite').directive('sidebar', function () {
        return {
            restrict: 'E',
            templateUrl: '/app/shared/sidebar/sidebar.html',
            replace: false,           
            controller: ['$scope', function ($scope) {
                function BuildSlides() {
                    var slides = [];
                    for (var i = 1; i < 4; i++) {
                        slides.push({ image: '/app/assets/img/slide' + i + '.jpg' })
                    }
                    $scope.slides = slides;
                }
                BuildSlides();
            }]
        }
    });
})();