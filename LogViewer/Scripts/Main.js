angular.module("LogApp", ["ngSanitize", "ui.bootstrap"])
    .config(["$routeProvider", function ($routeProvider) {

        $routeProvider.when("/AppLog", {
            controller: "AppLogController",
            templateUrl: "Templates/Partials/ApplicationLog.html"
        })
        .when("/WBSLog", {
            controller: "WBSLogController",
            templateUrl: "Templates/Partials/WBSLog.html"
        })
        .otherwise({ redirectTo: "/AppLog" });

    }]);