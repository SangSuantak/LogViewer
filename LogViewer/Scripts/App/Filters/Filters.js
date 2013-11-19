angular.module("LogApp")
.filter("unsafeHtml", function ($sce) {
    return function (input) {
        return $sce.trustAsHtml(input); 
    };
});