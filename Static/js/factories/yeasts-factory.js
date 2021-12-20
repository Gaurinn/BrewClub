angular.module('brewApp').factory('Yeasts', function YeastsFactory($http, Account) {
    return {
        GetAllYeasts: function () {
            return $http({
                method: 'get',
                url: '/api/yeasts',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/yeasts/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});