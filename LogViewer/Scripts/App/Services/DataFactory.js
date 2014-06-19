var LogApp = angular.module("LogApp");

LogApp.factory("dataFactory", ["$http", function ($http) {
    var _urlBase = "/api/Log/",
        _datFactory = {};

    _datFactory.getApplicationLog = function (QueryInput) {        
        return $http.post(_urlBase + "GetApplicationLog", QueryInput);
    };

    _datFactory.getGDSLog = function (QueryInput) {
        return $http.post(_urlBase + "GetGDSLog", QueryInput);
    };

    _datFactory.getLCCLogDirectory = function (QueryInput) {
        return $http.post(_urlBase + "GetLCCLogDirectory", QueryInput);
    };

    _datFactory.getLCCLogFileContent = function (QueryInput) {
        return $http.post(_urlBase + "GetLCCLogFileContent", QueryInput);
    };

    _datFactory.getMasterQueryData = function (QueryInput) {
        return $http.post(_urlBase + "GetMasterQueryData", QueryInput);
    };

    _datFactory.getMasterData = function () {
        return $http.get(_urlBase + "GetMasterData", { cache: false });
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

    _datFactory.encryptXML = function (QueryInput) {
        return $http.post(_urlBase + "EncryptXML", QueryInput);
    };

    _datFactory.decryptXML = function (QueryInput) {
        return $http.post(_urlBase + "DecryptXML", QueryInput);
    };

    _datFactory.getTabConfiguration = function () {
        return $http.get(_urlBase + "GetTabConfiguration", { cache: false });
    };

    _datFactory.getMasterDataForLCC = function () {
        return $http.get(_urlBase + "GetMasterDataForLCC", { cache: false });
    };

    return _datFactory;

}]);