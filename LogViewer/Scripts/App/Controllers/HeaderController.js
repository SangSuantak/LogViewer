var LogApp = angular.module("LogApp");
LogApp.controller("HeaderController", ["$scope", "$location", function ($scope, $location) {

    $scope.isActive = function (viewLocation) {
        return viewLocation == $location.path();
    };

}]);