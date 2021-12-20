angular.module('brewApp').factory('Category', function CategoryFactory($http, Account) {
    return {
        GetAll: function () {
            return $http({
                method: 'get', url: '/api/category',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/category/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});