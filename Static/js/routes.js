angular.module('brewApp')
    .config(function ($routeProvider) {
        $routeProvider.when('/posts', {
            templateUrl: 'templates/posts/posts.html',
            controller: 'PostsController'
        })
        .when('/register', {
            templateUrl: 'templates/account/register.html',
            controller: 'RegisterController'
        })
        .when('/login', {
            templateUrl: 'templates/account/login.html',
            controller: 'LoginController'
        })
        .when('/comments', {
            templateUrl: 'templates/posts/comments.html',
            controller: 'CommentsController'
        })
        .when('/clubcomments', {
            templateUrl: 'templates/clubs/clubcomments.html',
            controller: 'ClubCommentsController'
        })
        .when('/clubposts', {
            templateUrl: 'templates/clubs/myClub.html',
            controller: 'ClubPostsController'
        })
        .when('/brewtypes', {
            templateUrl: 'templates/recipes/brewtypes.html',
            controller: 'BrewTypeController'
        })
        .when('/category', {
            templateUrl: 'templates/recipes/categories.html',
            controller: 'CategoryController'
        })
        .when('/grains', {
            templateUrl: 'templates/recipes/grains.html',
            controller: 'GrainsController'
        })
        .when('/hops', {
            templateUrl: 'templates/recipes/hops.html',
            controller: 'HopsController'
        })
        .when('/otheringredients', {
            templateUrl: 'templates/recipes/otheringredients.html',
            controller: 'otherIngredientsController'
        })
        .when('/recipes', {
            templateUrl: 'templates/recipes/recipes.html',
            controller: 'RecipesController'
        })
        .when('/yeasts', {
            templateUrl: 'templates/recipes/yeasts.html',
            controller: 'YeastsController'
        })
        .when('/clubs', {
            templateUrl: 'templates/clubs/clubs.html',
            controller: 'ClubsController'
        })
        .when('/clubmembers', {
            templateUrl: 'templates/clubs/clubs.html',
            controller: 'ClubMembersController'
        })
        .when('/myclub/:clubId', {
            templateUrl: 'templates/clubs/myClub.html',
            controller: 'MyClubController'
        })
        .when('/', {
            templateUrl: 'templates/posts/posts.html',
            controller: 'PostsController'
        })
        .otherwise({ redirectTo: '/' });
    });