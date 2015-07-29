(function () {
    angular.module("mbsite")
    .controller("galleryController", ['$scope', 'galleryService', '$timeout', function ($scope, gallery, $timeout) {
        var onSuccess = function (data) {
            var Images = [];
            for (var i = 0; i < data.length; i++) {
                Images.push({ source: data[i], loaded: false });
            }
            $scope.images = Images;
        }
        var onError = function () {
            $scope.imagesError = "Unable to fetch gallery at this time";
        }
        gallery.getGallery().then(onSuccess, onError);

        $scope.isLoaded = false;

        $scope.imageLoaded = function (index) {
            // use timeout to simulate some time passing
            $timeout(function () {
                console.log('loaded ', $scope.images[index]);
                $scope.images[index].loaded = true;

                $scope.isLoaded = ($scope.images.filter(function (obj, i) {
                    return obj.loaded === true;
                }).length == $scope.images.length);

                if ($scope.isLoaded) {
                    console.log("everything loaded");
                }
            }, index * 100);
        }
    }]);
})();