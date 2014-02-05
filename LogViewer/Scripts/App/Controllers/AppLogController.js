var LogApp = angular.module("LogApp");
LogApp.controller("AppLogController", ["$scope", "$timeout", "dataFactory", function ($scope, $timeout, dataFactory) {

    $scope.Modules = [];
    $scope.Applications = [];
    $scope.QueryInput = {};
    $scope.Log = [];

    var TempLog = [],
        LogChunkAppendCount = 0,
        LogChunkCount = 0,
        _objTimeout;

    function getMasterData() {
        dataFactory.getMasterData().success(function (data) {
            $scope.Modules = data.Modules;
        });
    }

    //split logs into chunks of 3000 character each
    function splitLog(log) {
        var _tArr = log.match(/[\s\S]{1,3000}/g) || [],
            _arrLength = _tArr.length,
            _iLoop = 0;

        for (; _iLoop < _arrLength; _iLoop++) {
            _tArr[_iLoop] = _tArr[_iLoop].replaceAll("ƀ", "<br />", true);
        }        
        return _tArr;
    }

    //append log every 30ms to stop the browser from become non-responsive when the log is large
    function appendLog() {
        LogChunkAppendCount++;
        $scope.Log.push(TempLog[LogChunkAppendCount - 1]);        
        if (LogChunkAppendCount <= LogChunkCount) {
            _objTimeout = $timeout(appendLog, 30);
        }
        else {
            $timeout.cancel(_objTimeout);
            $scope.showLoader = false;
        }
    }

    $scope.getApplicationLog = function () {
        $scope.showLoader = true;
        var QueryInput = {
            LogDateString: $scope.LogDateString,
            Module: $scope.Module.Name,
            Application: $scope.Application
        };

        TempLog = [];
        $scope.Log = [];

        LogChunkAppendCount = 0;
        LogChunkCount = 0;

        dataFactory.getApplicationLog(QueryInput).success(function (data) {            
            TempLog = splitLog(data.Log);            
            LogChunkCount = TempLog.length;            
            appendLog();
        }).error(function (data) {
            $scope.Log = ["There was a problem while fetching the Application Log"];
            $scope.showLoader = false;
        });
    };

    $scope.$watch("Module", function (newModule) {
        if (newModule) {
            $scope.Applications = newModule.Applications;
        }
    });

    $scope.showAppendInfo = function () {
        return $scope.showLoader && LogChunkCount > 50;
    };

    getMasterData();
        
    $scope.today = function () {
        $scope.LogDateString = new Date();
    };
    $scope.today();

    $scope.clear = function () {
        $scope.dt = null;
    };

    $scope.dateOptions = {
        'year-format': "'yy'",
        'starting-day': 1
    };

    $scope.maxDate = new Date();
    $scope.showLoader = false;
        
}]);