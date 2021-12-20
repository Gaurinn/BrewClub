angular.module('brewApp').controller('FBrewTypeController', ['$scope', '$http', 'Account', function ($scope, $http, Account) {
    $http({
        method: 'GET',
        url: '/api/brewtypes',
        headers: {
            'Authorization': 'Bearer ' + Account.GetToken()
        }
    }).success(function (data) {
        //console.log('All of the brewtypes!: ', data);
    }).error(function (data, error) {
        //console.log('Error retriving brewtypes: ', data, error);
    });
    //End of controller
}]);