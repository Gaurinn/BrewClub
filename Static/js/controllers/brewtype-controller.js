angular.module('brewApp').controller('BrewTypeController', ['$scope', 'BrewType', '$location', function ($scope, BrewType, $location) {
    $scope.showAddType = true;

    // Get all brewtypes
    BrewType.GetAll().success(function (data) {
        $scope.brewTypes = data;
        //console.log('Get All Brew Types', data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

}]);