angular.module('brewApp').controller('HopsController', ['$scope', 'Hops', '$location', function ($scope, Hops, $location) {
    $scope.showAddHop = true;
    // Get all hops
    Hops.GetAllHops().success(function (data) {
        $scope.Hops = data;
        //console.log('Get All hops', data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });
}]);