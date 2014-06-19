var LogApp = angular.module("LogApp");
LogApp.controller("HeaderController", ["$scope", "$location", "dataFactory", function ($scope, $location, dataFactory) {

    $scope.showAppLogs = false;
    $scope.showGDSLogs = false;
    $scope.showLCCLogs = false;
    $scope.showEncryptionDecryption = false;

    $scope.isActive = function (viewLocation) {
        return viewLocation == $location.path();
    };

    function getTabConfiguration() {
        dataFactory.getTabConfiguration().success(function (data) {
            $scope.showAppLogs = data.Tabs.ShowApplicationLogs;
            $scope.showGDSLogs = data.Tabs.ShowGDSLogs;
            $scope.showLCCLogs = data.Tabs.ShowLCCLogs;
            $scope.showEncryptionDecryption = data.Tabs.ShowEncryptionDecryption;
        });
    }

    getTabConfiguration();

}]);