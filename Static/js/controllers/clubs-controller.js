angular.module('brewApp').controller('ClubsController', ['$scope', 'Clubs', 'ClubMembers', '$location', 'Account', function ($scope, Clubs, ClubMembers, $location, Account, ClubMembers) {

    // The Clbs factory gets all the clubs from the API.
    // and sets it to $scope.clubs variable.
    Clubs.GetAll().success(function (data) {
        $scope.clubs = data;
        //console.log("all clubs: ", data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    // Warning function if user wants to clear the post object.
    $scope.ClearClub = function () {
        var a = alert('Are you sure you want to clear you data!');
        if (!a) {
            $scope.newClub = {};
            $scope.showAddClubForm = false;
        }
    }

    // Submit a new club
    $scope.Submit = function (club) {
        //console.log(club);
        club.memberId = Account.UserInfo().AuthorId;
        Clubs.Post(club).success(function (data) {
            $scope.clubs.push(data);
        }).error(function (data) {
        });
    }

    // Edit a selected club
    $scope.Edit = function (club) {
        Clubs.Edit(club).success(function (data) {
            //console.log('Successfully edited club:', data);
        }).error(function (data) {
            //console.log('Error while editing club:', data);
        });
    }

    // Show/Hide edit-add form
    $scope.ShowEditForm = function (club) {
        $scope.newClub = club;
        $scope.showAddClubForm = true;
        $scope.showEditClub = true;
        $scope.showAddNewClub = false;
    }
    //show hide add form
    $scope.ShowAddForm = function () {
        $scope.showAddClubForm = true;
        $scope.showEditClub = false;
        $scope.showAddNewClub = true;
    }

    // Delete club
    $scope.DeleteClub = function (club) {
        Clubs.Delete(club.Id).success(function (data) {
            // Searcing for the club in the list, and removing it.
            for (var i = $scope.clubs.length - 1; i >= 0; i--) {
                if ($scope.clubs[i].Id == club.Id) {
                    $scope.clubs.splice(i, 1);
                }
            }
            //console.log('Removed club:', club);
        }).error(function (data) { });
    }

    // Check author
    $scope.CheckAuthor = function (author) {
        var currentUser = Account.UserInfo();
        if (currentUser.AuthorId === author) {
            return true;
        }
        return false;
    }
}]);