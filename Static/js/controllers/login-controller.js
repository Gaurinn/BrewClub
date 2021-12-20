angular.module('brewApp').controller('LoginController', ['$scope', 'Account', '$location', function ($scope, Account, $location) {
    //login user
    $scope.Login = function (user) {
        if (user === undefined ||
            user.username === undefined ||
            user.password === undefined) {
            $scope.vError = true;
            $scope.error = 'Missing login data!';
            return
        }
        //account login
        Account.Login(user).then(function (data) {
            //console.log('User Logged In:', data);
            $location.path("/");
        }).catch(function (error) {
            //console.log('Error login', error);
            $scope.vError = true;
            $scope.error = error.data.error_description;
        });
    }
    // Controller end
}]);