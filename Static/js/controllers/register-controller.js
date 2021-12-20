angular.module('brewApp').controller('RegisterController', ['$scope', 'Account', function ($scope, Account) {

    //register a new user
    $scope.Register = function (newUser) {
        Account.Register(newUser).success(function (data) {
            //console.log('User created: ', data);
        }).error(function (data, error) {
            //console.log('ERROR Registering User:', data, error);
        });
    }
    // controller end
}]);