var LogApp = angular.module("LogApp");

LogApp.config(["$routeProvider", function ($routeProvider) {

    var _tabs = null;
    function checkUrl($location, dataFactory, prop) {
        if (_tabs) {
            if (!_tabs.Tabs[prop]) {
                $location.path("/Home");
            }        
        }
        else {
            dataFactory.getTabConfiguration().success(function (data) {
                _tabs = data;
                if (!_tabs.Tabs[prop]) {
                    $location.path("/Home");
                }
            });
        }
    }

    $routeProvider.when("/AppLog", {
        controller: "AppLogController",
        templateUrl: "Templates/Partials/ApplicationLog.html",
        resolve: {
            check: function ($location, dataFactory) {
                checkUrl($location, dataFactory, "ShowApplicationLogs");                
            }
        }
    })
    .when("/GDSLog", {
        controller: "GDSLogController",
        templateUrl: "Templates/Partials/GDSLog.html",
        resolve: {
            check: function ($location, dataFactory) {
                checkUrl($location, dataFactory, "ShowGDSLogs");                
            }
        }
    })
    .when("/LCCLog", {
        controller: "LCCLogController",
        templateUrl: "Templates/Partials/LCCLog.html",
        resolve: {
            check: function ($location, dataFactory) {
                checkUrl($location, dataFactory, "ShowLCCLogs");
            }
        }
    })
    .when("/EncryptionDecryption", {
        controller: "EncryptDecryptController",
        templateUrl: "Templates/Partials/EncryptDecrypt.html",
        resolve: {
            check: function ($location, dataFactory) {
                checkUrl($location, dataFactory, "ShowEncryptionDecryption");                
            }
        }
    })
    .when("/Home", {
        templateUrl: "Templates/Partials/Home.html"
    })
    .otherwise({ redirectTo: "/Home" });

}]);