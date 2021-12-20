angular.module('brewApp').controller('FpostsController', ['$scope', '$http', 'Account', function ($scope, $http, Account) {
    $http({
        method: 'GET',
        url: '/api/posts',
        headers: {
            'Authorization': 'Bearer ' + Account.GetToken()
        }
    }).success(function (data) {
        //console.log('All of the posts!: ', data);
    }).error(function (data, error) {
        //console.log('Error retriving posts: ', data, error);
    });
    //End of controller
}]);