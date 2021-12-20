angular.module('brewApp').factory('BrewType', function BrewTypeFactory($http, Account) {
    return {
        GetAll: function () {
            return $http({
                method: 'get',
                url: '/api/brewtypes',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/brewtypes/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }

    }
});