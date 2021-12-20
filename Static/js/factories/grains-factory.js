angular.module('brewApp').factory('Grains', function GrainsFactory($http, Account) {
    return {
        GetAllGrains: function () {
            return $http({
                method: 'get',
                url: '/api/grains',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/grains/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});