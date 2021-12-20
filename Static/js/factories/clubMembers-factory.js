angular.module('brewApp').factory('ClubMembers', function CommentsFactory($http, Account) {
    return {
        GetAll: function (id) {
            return $http({
                method: 'get',
                url: '/api/clubmembers/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/clubmembers/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Post: function (obj) {
            //console.log(obj);
            return $http({
                method: 'post',
                url: '/api/clubmembers',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },

        Delete: function (id) {
            return $http({
                method: 'post',
                url: '/api/clubmembers/removemember',
                data: id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});