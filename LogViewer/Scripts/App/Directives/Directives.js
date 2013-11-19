var LogApp = angular.module("LogApp");

LogApp.directive("selectOnClick", function () {
    
    return function (scope, element, attrs) {
        element.bind("click", function () {
            this.select();
        });
    };

});