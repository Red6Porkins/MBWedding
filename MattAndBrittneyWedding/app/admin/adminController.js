(function () {
    angular.module("mbsite")
    .controller("adminController", ['$scope', '$location', 'adminService', 'authService', function ($scope, $location, adminService, authService) {
        var OnSuccess = function (data) {
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
        $scope.userName = authService.userData.userName;

        $scope.logout = function () {
            authService.logout();
            $location.path('/login');
        }

        $scope.approve = function (ID, Index) {
            $scope.serverInteraction = true;
            adminService.approveEntry(ID)
                .success(function (data) {
                    $scope.posts[Index].IsVisible = 1;
                    $scope.serverInteraction = false;
                    $scope.crError = false;
                })
                .error(function (data) {
                    $scope.serverInteraction = false;
                    $scope.crError = "An error occured approving this post";
                });
        };

        $scope.remove = function (ID, Index) {
            $scope.serverInteraction = true;
            adminService.removeEntry(ID)
                .success(function (data) {
                    $scope.posts[Index].IsDeleted = 1;
                    $scope.serverInteraction = false;
                    $scope.crError = false;
                })
                .error(function (data) {
                    $scope.serverInteraction = false;
                    $scope.crError = "An error occured deleting this post";
                });
        };
    }]);
})();