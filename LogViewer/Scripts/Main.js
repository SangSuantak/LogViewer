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
        .when("/EncryptionDecryption", {
            controller: "EncryptDecryptController",
            templateUrl: "Templates/Partials/EncryptDecrypt.html"
        })
        .otherwise({ redirectTo: "/AppLog" });

    }]);