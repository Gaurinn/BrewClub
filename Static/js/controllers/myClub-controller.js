angular.module('brewApp').controller('MyClubController', ['$scope', 'ClubMembers', '$location', 'Account', '$routeParams', '$http', 'Clubs', 'ClubPosts', 'ClubComments', 'Category', function ($scope, ClubMembers, $location, Account, $routeParams, $http, Clubs, ClubPosts, ClubComments, Category) {

    //console.log('Ég er með clubb nr: ', $routeParams.clubId);
    //set $scope.clubMembers variable.
    ClubMembers.GetAll($routeParams.clubId).success(function (data) {
        $scope.clubMembers = data;
        //console.log("all clubMembers: ", data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    //join a club
    $scope.JoinClub = function (club) {
        //console.log(club);
        club.clubId = $routeParams.clubId;
        //add logged in user to selected club
        club.memberId = Account.UserInfo().AuthorId;
        ClubMembers.Post(club).success(function (data) {
            $scope.clubMembers.push(data);
        }).error(function (data) {
        });
    }

    // remove member from club
    $scope.RemoveMember = function (m) {
        ClubMembers.Delete(m).success(function (data) {
            // Searcing for the member, and removing it.
            for (var i = $scope.clubMembers.length - 1; i >= 0; i--) {
                if ($scope.clubMembers[i].Id == m.Id) {
                    $scope.clubMembers.splice(i, 1);
                }
            }
            //console.log('Removed member:', m);
        }).error(function (data) { });
    }

    //get all clubs
    Clubs.GetAll().success(function (data) {
        $scope.clubs = data;
        //console.log("all clubs: ", data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    //get one club
    Clubs.GetSingle($routeParams.clubId).success(function (data) {
        $scope.club = data;
    });

    //get all club members
    $http.get('/api/clubmembers/' + $routeParams.clubId).success(function (data) {
        //console.log('Allir members', data);
    });

    //ClubPosts=============================

    // The ClubPosts factory gets all the posts from the API.
    // and sets it to our $scope.clubPosts variable.
    ClubPosts.GetAll($routeParams.clubId).success(function (data) {
        $scope.clubPosts = data;
        //console.log("all clubPosts: ", data);
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

    // Submit a new post.
    $scope.Submit = function (post) {
        //console.log(post);
        post.categoryId = $scope.selectedCategory.Id;
        post.authorId = Account.UserInfo().AuthorId;
        //set the posts clubId to the selected club
        post.clubId = $routeParams.clubId;
        ClubPosts.Post(post).success(function (data) {
            $scope.clubPosts.push(data);
        }).error(function (data) {
        });
    }

    // Edit a selected post.
    $scope.Edit = function (post) {
        post.categoryId = $scope.selectedCategory.id;
        ClubPosts.Edit(post).success(function (data) {
            //console.log('Successfully edited post:', data);
        }).error(function (data) {
            //console.log('Error while editing post:', data);
        });
    }

    // Warning function if user wants to clear the post object.
    $scope.ClearPost = function () {
        var a = alert('Are you sure you want to clear you data!');
        if (!a) {
            $scope.newPost = {};
            $scope.showAddPostForm = false;
        }
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
        ClubPosts.Delete(post.Id).success(function (data) {
            // Searcing for the post in the postlist, and removing it.
            for (var i = $scope.clubPosts.length - 1; i >= 0; i--) {
                if ($scope.clubPosts[i].Id == post.Id) {
                    $scope.clubPosts.splice(i, 1);
                }
            }
            //console.log('Removed post:', post);
        }).error(function (data) { });
    }

    //ClubComments--------------------------

    // The comments factory gets all the comments from the API.
    // and sets it to $scope.clubComments variable.
    ClubComments.GetAll().success(function (data) {
        $scope.clubComments = data;
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
        ClubComments.Post(comment).success(function (data) {
            //console.log(data);
            post.clubComments.push(data);
        }).error(function (data) {
        });
    }

    // Edit a selected comment.
    $scope.EditComment = function (comment) {
        ClubComments.Edit(comment).success(function (data) {
            //console.log('Successfully edited comment:', data);
        }).error(function (data) {
            //console.log('Error while editing comment:', data);
        });
    }

    // Show/Hide edit-add form
    $scope.showEditCommentForm = function (comment) {
        $scope.newComment = comment;
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
        ClubComments.Delete(comment.id).success(function (data) {
            // Searcing for the comment in the comments list, and removing it.
            for (var i = $scope.clubComments.length - 1; i >= 0; i--) {
                if ($scope.clubComments[i].id == post.id) {
                    $scope.clubComments.splice(i, 1);
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