var LogApp = angular.module("LogApp");

LogApp.factory("dataFactory", ["$http", function ($http) {
    var _urlBase = "/api/Log/",
        _datFactory = {};

    _datFactory.getApplicationLog = function (QueryInput) {        
        return $http.post(_urlBase + "GetApplicationLog", QueryInput);
    };

    _datFactory.getWBSLog = function (QueryInput) {
        return $http.post(_urlBase + "GetWBSLog", QueryInput);
    };

    _datFactory.getMasterQueryData = function (QueryInput) {
        return $http.post(_urlBase + "GetMasterQueryData", QueryInput);
    };

    _datFactory.getMasterData = function () {
        return $http.get(_urlBase + "GetMasterData");
    };

    _datFactory.getWBSApplications = function () {
        return $http.get(_urlBase + "GetWBSApplications");
    };

    _datFactory.encryptPlainText = function (QueryInput) {
        return $http.post(_urlBase + "EncryptPlainText", QueryInput);
    };

    _datFactory.decryptText = function (QueryInput) {
        return $http.post(_urlBase + "DecryptText", QueryInput);
    };

    return _datFactory;

}]);