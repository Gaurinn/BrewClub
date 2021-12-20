angular.module('brewApp').controller('otherIngredientsController', ['$scope', 'otherIngredients', '$location', function ($scope, otherIngredients, $location) {

    // Get all otherIngredients
    otherIngredients.GetAllOtherIngredients().success(function (data) {
        $scope.otherIngredients = data;
        //console.log('Get All otherIngredients', data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });
}]);