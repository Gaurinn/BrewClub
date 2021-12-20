angular.module('brewApp').controller('CategoryController', ['$scope', 'Category', '$location', function ($scope, Category, $location) {
    $scope.showAddType = true;

    // Get all categories
    Category.GetAll().success(function (data) {
        $scope.categories = data;
        //console.log('Get All Categories', data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

}]);