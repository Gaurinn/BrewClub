angular.module('brewApp').factory('Hops', function HopsFactory($http, Account) {
    return {
        GetAllHops: function () {
            return $http({
                method: 'get',
                url: '/api/hops',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/hops/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});