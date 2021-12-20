angular.module('brewApp').factory('Comments', function CommentsFactory($http, Account) {
    return {
        GetAll: function () {
            return $http({
                method: 'get',
                url: '/api/comments',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/comments/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Post: function (obj) {
            obj.authorId = Account.UserInfo().AuthorId;
            //console.log(obj);
            return $http({
                method: 'post',
                url: '/api/comments',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Edit: function (obj) {
            return $http({
                method: 'put',
                url: '/api/comments',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Delete: function (id) {
            return $http({
                method: 'delete',
                url: '/api/comments/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});