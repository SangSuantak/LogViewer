var LogApp = angular.module("LogApp");
LogApp.controller("AppLogController", ["$scope", "dataFactory", function ($scope, dataFactory) {

    $scope.Modules = [];
    $scope.Applications = [];
    $scope.QueryInput = {};
    $scope.MasterQueryData;

    function getMasterData() {
        dataFactory.getMasterData().success(function (data) {
            $scope.Modules = data.Modules;
        });
    }

    $scope.getApplicationLog = function () {
        var QueryInput = {
            ReferenceId: $scope.ReferenceId,
            Module: $scope.Module.Name,
            Application: $scope.Application
        };

        $scope.MasterQueryData = null;
        $scope.Error = null;

        dataFactory.getMasterQueryData(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            }
            else {
                $scope.MasterQueryData = data.MasterQueryData;
            }
        });
    };

    $scope.$watch("Module", function (newModule) {
        if (newModule) {
            $scope.Applications = newModule.Applications;
        }
    });

    getMasterData();
    
}]);