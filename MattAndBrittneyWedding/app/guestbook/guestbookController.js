(function () {
    angular.module("mbsite")
    .controller("guestbookController", ['$scope', 'guestbookService', '$modal', function ($scope, guestBook, $modal) {
        //Load Posts
        ////////////////////////////////////////////////////////////////////////
        var OnSuccess = function(data) {
            $scope.posts = data;
            $scope.loadingPosts = false;
            console.log(data);
        }
        var OnError = function () {
            $scope.postsError = "Unable to retreive posts at this time";
        }
        $scope.loadingPosts = true;
        guestBook.getGuestbook().then(OnSuccess, OnError);
        ////////////////////////////////////////////////////////////////////////

        //Open Sign Form
        ////////////////////////////////////////////////////////////////////////        
        $scope.open = function () {
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: 'myModalContent.html',
                controller: 'guestbookModalController',
                size: 'lg',
                resolve: {
                    guestbook: function () { return guestBook; }
                }
            });
        };
        ////////////////////////////////////////////////////////////////////////
    }]);

    angular.module("mbsite")
   .controller("guestbookModalController", ['$scope', '$modalInstance', '$http', 'guestbook',  function ($scope, $modalInstance, $http, guestbook) {
       $scope.cancel = function () {
           $modalInstance.dismiss('cancel');
       };

       $scope.messageGood = false;
       $scope.formSubmitting = false;

       $scope.formData = {};
       function resetForm() {
           $scope.formError = false;
           $scope.formData.Name = undefined;
           $scope.formData.Email = undefined;
           $scope.formData.Message = undefined;
       }
       resetForm();

       $scope.postError = false;

       var onSuccess = function (response) {
           console.log(response);
           $scope.messageGood = true;
           resetForm();
           $scope.formSubmitting = false;
       }
       var onError = function (response) {
           console.log(response);
           $scope.postError = "An error occured adding your message to our guestbook. Please try again later."
           $scope.formSubmitting = false;
       }
       $scope.sendMessage = function () {
           if ($scope.formData.Name != null && $scope.formData.Name != "" && $scope.formData.Email               
                != null && $scope.formData.Email != "" && $scope.formData.Message
               != null && $scope.formData.Message != "") {
                   $scope.formSubmitting = true;
                   console.log("Submitting");
                   guestbook.addEntry($scope.formData).then(onSuccess, onError);
           } else {
               console.log("Errors Present");
               $scope.formError = true;
           }
       };    
   }]);
})();