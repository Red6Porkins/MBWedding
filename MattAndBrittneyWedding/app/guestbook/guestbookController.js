(function () {
    angular.module("mbsite")
    .controller("guestbookController", ['$scope', 'guestbookService', '$modal', function ($scope, guestBook, $modal) {
        //Load Posts
        ////////////////////////////////////////////////////////////////////////
        var OnSuccess = function(data) {
            $scope.posts = data;
        }

        var OnError = function () {
            $scope.postsError = "Unable to retreive posts at this time";
        }

        guestBook.getGuestbook().then(OnSuccess, OnError);
        ////////////////////////////////////////////////////////////////////////

        //Open Picture
        ////////////////////////////////////////////////////////////////////////        
        $scope.open = function () {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'myModalContent.html',
                controller: 'guestbookModalController',
                size: 'lg',
                resolve: {
                    
                }
            });
        };
        ////////////////////////////////////////////////////////////////////////
    }]);

    angular.module("mbsite")
   .controller("guestbookModalController", ['$scope', '$modalInstance',  function ($scope, $modalInstance) {
       $scope.cancel = function () {
           $modalInstance.dismiss('cancel');
       };

       
    
   }]);
})();