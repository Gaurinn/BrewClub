angular.module('brewApp').controller('RecipesController', ['$scope', 'Recipes', '$location', 'Account', 'Hops', 'Grains', 'Yeasts', 'otherIngredients', function ($scope, Recipes, $location, Account, Hops, Grains, Yeasts, otherIngredients) {

    // The Recipes factory gets all the posts from the API.
    // and sets it to $scope.recipes variable.
    Recipes.GetAllRecipes().success(function (data) {
        $scope.recipes = data;
        //console.log("all recipes",data);
    }).error(function (data, error) {
        if (error == 401) {
            $location.path('/login');
        }
    });

    // Get all the hops and set it to $scope variable.
    Hops.GetAllHops().success(function (data) {
        $scope.hops = data;
    }).error(function (data) {
        //console.log('Error Unable to get hops:', data);
    });

    // Get all the grains and set it to $scope variable.
    Grains.GetAllGrains().success(function (data) {
        $scope.grains = data;
    }).error(function (data) {
        //console.log('Error Unable to get grains:', data);
    });

    // Get all the yeasts and set it to $scope variable.
    Yeasts.GetAllYeasts().success(function (data) {
        $scope.yeasts = data;
    }).error(function (data) {
        //console.log('Error Unable to get yeasts:', data);
    });

    // Get all the otherIngredients and set it to $scope variable.
    otherIngredients.GetAllOtherIngredients().success(function (data) {
        $scope.otherIngredients = data;
    }).error(function (data) {
        //console.log('Error Unable to get otherIngredients:', data);
    });

    // Warning function if user wants to clear the recipe object.
    $scope.ClearRecipe = function () {
        var a = alert('Are you sure you want to clear you data!');
        if (!a) {
            $scope.newRecipe = {};
            $scope.showAddRecipeForm = false;
        }
    }

    // Submit a new recipe
    $scope.Submit = function (recipe) {
        //author id for recipe
        recipe.authorId = Account.UserInfo().AuthorId;
        //hops
        //console.log($scope.selectedHops);
        recipe.hopsId = $scope.selectedHops.Id;
        recipe.hopsName = $scope.selectedHops.name;
        //grains
       // console.log($scope.selectedGrains);
        recipe.grainsId = $scope.selectedGrains.Id;
        recipe.grainsName = $scope.selectedGrains.name;
        //yeasts
        //console.log($scope.selectedYeasts);
        recipe.yeastsId = $scope.selectedYeasts.Id;
        recipe.yeastName = $scope.selectedYeasts.name;
        //otherIngredients
        //console.log($scope.selectedOtherIngredients);
        recipe.otherIngredientsId = $scope.selectedOtherIngredients.Id;
        recipe.otherIngName = $scope.selectedOtherIngredients.name;
        Recipes.Post(recipe).success(function (data) {
            $scope.recipes.push(data);
        }).error(function (data) {
        });
    }

    // Edit a selected recipe.
    $scope.Edit = function (recipe) {
        //edit hops
        recipe.hopsName = $scope.selectedHops.name;
        recipe.hopsId = $scope.selectedHops.id;
        //edit grains
        recipe.grainsName = $scope.selectedGrains.name;
        recipe.grainsId = $scope.selectedGrains.id;
        //edit yeasts
        recipe.yeastName = $scope.selectedYeasts.name;
        recipe.yeastsId = $scope.selectedYeasts.id;
        //edit otherIngredients
        recipe.otherIngName = $scope.selectedOtherIngredients.name;
        recipe.otherIngredientsId = $scope.selectedOtherIngredients.id;
        Recipes.Edit(recipe).success(function (data) {
            //console.log('Successfully edited recipe:', data);
        }).error(function (data) {
            //console.log('Error while editing recipe:', data);
        });
    }

    // Show/Hide edit-add form
    $scope.ShowEditForm = function (recipe) {
        $scope.newRecipe = recipe;
        // Find the hops and set it as the selected hop
        for (var i = 0; i < $scope.hops.length; i++) {
            if (recipe.hopsId == $scope.hops[i].id) {
                $scope.selectedHops = $scope.hops[i];
            };
        };
        // Find the grains and set it as the selected grains
        for (var i = 0; i < $scope.grains.length; i++) {
            if (recipe.grainsId == $scope.grains[i].id) {
                $scope.selectedGrains = $scope.grains[i];
            };
        };
        // Find the yeast and set it as the selected yeast
        for (var i = 0; i < $scope.yeasts.length; i++) {
            if (recipe.yeastsId == $scope.yeasts[i].id) {
                $scope.selectedYeasts = $scope.yeasts[i];
            };
        };
        // Find the otherIngredients and set it as the selected otherIngredient
        for (var i = 0; i < $scope.otherIngredients.length; i++) {
            if (recipe.otherIngredientsId == $scope.otherIngredients[i].id) {
                $scope.selectedOtherIngredients = $scope.otherIngredients[i];
            };
        };
        $scope.showAddRecipeForm = true;
        $scope.showEditRecipe = true;
        $scope.showAddNewRecipe = false;
    }

    $scope.ShowAddForm = function () {
        $scope.showAddRecipeForm = true;
        $scope.showEditRecipe = false;
        $scope.showAddNewRecipe = true;
    }

    // Delete recipe
    $scope.DeleteRecipe = function (recipe) {
        Recipes.Delete(recipe.id).success(function (data) {
            // Searcing for the recipe in the recipe list, and removing it.
            for (var i = $scope.recipes.length - 1; i >= 0; i--) {
                if ($scope.recipes[i].id == recipe.id) {
                    $scope.recipes.splice(i, 1);
                }
            }
            //console.log('Removed recipe:', recipe);
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