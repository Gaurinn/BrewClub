angular.module('brewApp').factory('Posts', function PostsFactory($http, Account) {
    return {
        GetAll: function () {
            return $http({
                method: 'get',
                url: '/api/posts',
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/posts/' + id,
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
                url: '/api/posts',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Edit: function (obj) {
            return $http({
                method: 'put',
                url: '/api/posts',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Delete: function (id) {
            return $http({
                method: 'delete',
                url: '/api/posts/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});