angular.module('brewApp').controller('GrainsController', ['$scope', 'Grains', '$location', function ($scope, Grains, $location) {
    $scope.showAddType = true;
    // Get all grains
    Grains.GetAllGrains().success(function (data) {
        $scope.Grains = data;
        //console.log('Get All grains', data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });
}]);