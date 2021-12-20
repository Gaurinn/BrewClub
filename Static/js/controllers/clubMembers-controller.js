angular.module('brewApp').controller('ClubMembersController', ['$scope', 'ClubMembers', '$location', 'Account', function ($scope, Posts, $location, Account) {

    //set $scope.clubMembers variable.
    ClubMembers.GetAll(id).success(function (data) {
        $scope.clubMembers = data;
        //console.log("all clubMembers: ", data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    // Delete a clubMember
    $scope.DeleteClubMember = function (cm) {
        ClubMembers.Delete(cm.Id).success(function (data) {
            // Searcing for the clubmember and removing it.
            for (var i = $scope.clubMembers.length - 1; i >= 0; i--) {
                if ($scope.clubMembers[i].Id == cm.Id) {
                    $scope.clubMembers.splice(i, 1);
                }
            }
            //console.log('Removed clubmember:', cm);
        }).error(function (data) { });
    }
}]);