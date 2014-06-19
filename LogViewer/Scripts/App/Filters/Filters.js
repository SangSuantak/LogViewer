//All filters go here
angular.module("LogApp")
.filter("trustAsHtml", ["$sce", function ($sce) {
    return function (input) {
        return $sce.trustAsHtml(input); 
    };
}]);