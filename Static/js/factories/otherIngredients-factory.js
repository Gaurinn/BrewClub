angular.module('brewApp').factory('otherIngredients', function otherIngredientsFactory($http, Account) {
    return {
        GetAllOtherIngredients: function () {
            return $http({
                method: 'get',
                url: '/api/otheringredients',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/otheringredients/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});