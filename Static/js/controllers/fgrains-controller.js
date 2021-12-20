angular.module('brewApp').controller('FGrainsController', ['$scope', '$http', 'Account', function ($scope, $http, Account) {
    $http({
        method: 'GET',
        url: '/api/grains',
        headers: {
            'Authorization': 'Bearer ' + Account.GetToken()
        }
    }).success(function (data) {
        //console.log('All of the grains!: ', data);
    }).error(function (data, error) {
        //console.log('Error retriving grains: ', data, error);
    });
    //End of controller
}]);