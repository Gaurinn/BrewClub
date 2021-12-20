angular.module('brewApp').controller('PostsController', ['$scope', 'Posts', '$location', 'Account', 'Category', 'Comments', function ($scope, Posts, $location, Account, Category, Comments) {

    // The Posts factory gets all the posts from the API.
    // and sets it to our $scope.posts variable.
    Posts.GetAll().success(function (data) {
        $scope.posts = data;
        //console.log("all posts: ", data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    // Get all the categories and set it to $scope variable.
    Category.GetAll().success(function (data) {
        $scope.categories = data;
    }).error(function (data) {
        //console.log('Error Unable to get categories:', data);
    });

    // Warning function if user wants to clear the post object.
    $scope.ClearPost = function () {
        var a = alert('Are you sure you want to clear you data!');
        if (!a) {
            $scope.newPost = {};
            $scope.showAddPostForm = false;
        }
    }

    // Submit a new post.
    $scope.Submit = function (post) {
        //console.log(post);
        post.categoryId = $scope.selectedCategory.Id;
        //get authorId from whoever is logged in
        post.authorId = Account.UserInfo().AuthorId;
        //make post form disappear
        $scope.showAddPostForm = false;
        Posts.Post(post).success(function (data) {
            $scope.posts.push(data);
        }).error(function (data) {
        });
    }

    // Edit a selected post.
    $scope.Edit = function (post) {
        post.categoryId = $scope.selectedCategory.id;
        //make post form disappear
        $scope.showAddPostForm = false;
        Posts.Edit(post).success(function (data) {
            //console.log('Successfully edited post:', data);
        }).error(function (data) {
            //console.log('Error while editing post:', data);
        });
    }

    // Show/Hide edit-add form
    $scope.ShowEditForm = function (post) {
        $scope.newPost = post;
        // Find the category and set it as the selected category
        for (var i = 0; i < $scope.categories.length; i++) {
            if (post.categoryId == $scope.categories[i].id) {
                $scope.selectedCategory = $scope.categories[i];
            };
        };
        $scope.showAddPostForm = true;
        $scope.showEditPost = true;
        $scope.showAddNewPost = false;
    }

    $scope.ShowAddForm = function () {
        $scope.showAddPostForm = true;
        $scope.showEditPost = false;
        $scope.showAddNewPost = true;
    }

    // Delete the post
    $scope.DeletePost = function (post) {
        Posts.Delete(post.Id).success(function (data) {
            // Searcing for the post in the postlist, and removing it.
            for (var i = $scope.posts.length - 1; i >= 0; i--) {
                if ($scope.posts[i].Id == post.Id) {
                    $scope.posts.splice(i, 1);
                }
            }
            //console.log('Removed post:', post);
        }).error(function (data) { });
    }

    //Comments--------------------------

    // The comments factory gets all the comments from the API.
    // and sets it to $scope.comments variable.
    Comments.GetAll().success(function (data) {
        $scope.comments = data;
        //console.log(data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    // Warning function if user wants to clear the comment object.
    $scope.ClearComment = function () {
        var a = alert('Are you sure you want to clear you data!');
        if (!a) {
            $scope.newComment = {};
            $scope.showAddCommentForm = false;
        }
    }

    // Submit a new comment.
    $scope.SubmitComment = function (comment, post) {
        //console.log(comment);
        comment.authorId = Account.UserInfo().AuthorId;
        comment.postId = post.Id;
        Comments.Post(comment).success(function (data) {
            //console.log(data);
            post.comments.push(data);
        }).error(function (data) {
        });
    }

    // Edit a selected comment.
    $scope.EditComment = function (comment) {
        Comments.Edit(comment).success(function (data) {
            //console.log('Successfully edited comment:', data);
        }).error(function (data) {
            //console.log('Error while editing comment:', data);
        });
    }

    // Show/Hide edit-add form
    $scope.showEditCommentForm = function (comment) {
        $scope.newComment = comment;
        //console.log(comment);
        $scope.showAddCommentForm = true;
        $scope.showEditComment = true;
        $scope.showAddNewComment = false;
    }

    $scope.displayAddComment = function (c) {
        c.showAddCommentForm = true;
        c.showAddNewComment = true;
        c.showEditComment = false;
    }

    // Delete the comment
    $scope.DeleteComment = function (comment) {
        Comments.Delete(comment.id).success(function (data) {
            // Searcing for the comment in the comments list, and removing it.
            for (var i = $scope.comments.length - 1; i >= 0; i--) {
                if ($scope.comments[i].id == post.id) {
                    $scope.comments.splice(i, 1);
                }
            }
            //console.log('Removed comment:', post);
        }).error(function (data) { });
    }

    // Check author
    $scope.CheckAuthor = function (author) {
        var currentUser = Account.UserInfo();
        if (currentUser.AuthorId === author) {
            return true;
        }
        return false;
    }
}]);