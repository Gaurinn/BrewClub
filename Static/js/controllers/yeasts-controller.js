angular.module('brewApp').controller('YeastsController', ['$scope', 'Yeasts', '$location', function ($scope, Yeasts, $location) {
    $scope.showAddYeast = true;

    // Get all yeasts
    Yeasts.GetAllYeasts().success(function (data) {
        $scope.Yeasts = data;
        //console.log('Get All yeasts', data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });
}]);