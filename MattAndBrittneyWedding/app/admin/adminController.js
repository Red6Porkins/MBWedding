(function () {
    angular.module("mbsite")
    .controller("adminController", ['$scope', 'adminService', function ($scope, adminService) {
        var OnSuccess = function (data) {
            console.log(data);
            $scope.posts = data;
            $scope.loadingPosts = false;
        }
        var OnError = function () {            
            $scope.postsError = "Unable to retreive posts at this time";
            $scope.loadingPosts = false;
        }
        adminService.getGuestbook().then(OnSuccess, OnError);
  
        $scope.serverInteraction = false;
        $scope.loadingPosts = true;

        $scope.approve = function (ID, Index) {
            $scope.serverInteraction = true;
            adminService.approveEntry(ID)
                .success(function (data) {
                    console.log(data);
                    $scope.posts[Index].IsVisible = 1;
                    $scope.serverInteraction = false;
                });
        };

        $scope.remove = function (ID, Index) {
            $scope.serverInteraction = true;
            adminService.removeEntry(ID)
                .success(function (data) {
                    console.log(data);
                    $scope.posts[Index].IsDeleted = 1;
                    $scope.serverInteraction = false;
                });            
        };
    }]);
})();