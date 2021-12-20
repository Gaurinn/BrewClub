angular.module('brewApp').factory('Clubs', function ClubsFactory($http, Account) {
    return {
        GetAll: function () {
            return $http({
                method: 'get',
                url: '/api/clubs',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/clubs/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Post: function (obj) {
            obj.leaderName = Account.UserInfo().AuthorId;
            //console.log(obj);
            return $http({
                method: 'post',
                url: '/api/clubs',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Edit: function (obj) {
            return $http({
                method: 'put',
                url: '/api/clubs',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Delete: function (id) {
            return $http({
                method: 'delete',
                url: '/api/clubs/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});