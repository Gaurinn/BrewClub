angular.module('brewApp').factory('ClubPosts', function ClubPostsFactory($http, Account) {
    return {
        GetAll: function (clubId) {
            return $http({
                method: 'get',
                url: '/api/clubposts/' + clubId,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        GetSingle: function (id) {
            return $http({
                method: 'get', url: '/api/clubposts/' + id,
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
                url: '/api/clubposts',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Edit: function (obj) {
            return $http({
                method: 'put',
                url: '/api/clubposts',
                data: obj,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        },
        Delete: function (id) {
            return $http({
                method: 'delete',
                url: '/api/clubposts/' + id,
                headers: {
                    'Authorization': 'Bearer ' + Account.GetToken()
                }
            });
        }
    }
});