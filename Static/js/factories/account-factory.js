angular.module('brewApp').factory('Account', function AccountFactory($http) {

    // Create a variable that stores our login Token.
    var token = ''; 
    var user = {};

    // Private function
    function GetUserData() {
        $http({
            method: 'GET',
            url: '/api/account/userinfo',
            headers: {
                'Authorization': 'Bearer ' + token
            }
        }).success(function (data) {
            //console.log('Userdata:', data);
            user = data;
        }).error(function (data) {
            //console.log('Unable to get userdata:', data);
        });
    };

    return {
        Register: function (obj) {
            return $http({
                method: 'POST',
                url: '/api/account/register',
                data: obj
            });
        }, // The login function
        Login: function (user) {

            // Create the login object
            var loginData = {
                grant_type: 'password', // This is needed to pass to let the API know that we are using a password to get the access token
                username: user.username, // username is provided from the user in login.html
                password: user.password // password is provided from the user in login.html
            };

            // The Http call.
            return $http({
                method: 'POST',
                url: '/Token', // /Token is the default url for token validations in asp.NET projects.
                headers: { // You need to set your headers as x-www-form-urlencoded so the Api understands the request.
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                data: $.param(loginData) // $.param forms the data correctly for you.
            }).success(function (data) {
                token = data.access_token;
                user = GetUserData();
                //console.log("Success: Account API: ", data);
            }).error(function (data, error) {
                //console.log(data, error);
            });
        },
        UserInfo: function () {
            return user;
        },
        GetToken: function () {
            return token;
        }
        // end of the factory
    }
});