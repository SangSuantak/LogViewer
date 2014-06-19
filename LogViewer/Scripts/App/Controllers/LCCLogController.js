var LogApp = angular.module("LogApp");
LogApp.controller("LCCLogController", ["$scope", "dataFactory", function ($scope, dataFactory) {

    $scope.Modules = [];
    $scope.Applications = [];
    $scope.QueryInput = {};
    $scope.LCCLog;
    $scope.Error;
    $scope.directories = [];

    //Fetch all lcc modules and applications
    function getMasterDataForLCC() {
        dataFactory.getMasterDataForLCC().success(function (data) {
            $scope.Modules = data.Modules;
        });
    }

    //Automatically called when module dropdown is changed
    $scope.$watch("Module", function (newModule) {
        if (newModule) {
            $scope.Applications = newModule.Applications;
        }
    });

    //Browse directory
    function retrieveLCCDirectoryLog(QueryInput) {
        dataFactory.getLCCLogDirectory(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            }
            else {
                if (data.LCCLog.length) {
                    //if it's called the first time, set the root directory for the breadcrumb
                    if (!QueryInput.Path) {
                        $scope.directories.push(data.LCCLog[0]);
                        data.LCCLog.splice(0, 1);
                    }
                    $scope.LCCLog = data.LCCLog;
                }
                else {
                    $scope.Error = "The configured log path for the application cannot be found";
                }
            }
            $scope.showLoader = false;
        }).error(function (data) {
            $scope.Error = "There was a problem while fetching the XML Logs";
            $scope.showLoader = false;
        });
    }

    //Fetch file content
    function retrieveLCCFileContent(QueryInput) {        
        dataFactory.getLCCLogFileContent(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            }
            else {
                $scope.ModalContent = data.LogContent;
            }
            $scope.showLoader = false;
        }).error(function (data) {
            $scope.Error = "There was a problem while fetching the XML Logs";
            $scope.showLoader = false;
        });
    }

    //Called when the view button is clicked
    $scope.browseLCCLog = function () {
        $scope.showLoader = true;        
        $scope.directories = [];
        $scope.LCCLog = null;
        $scope.Error = null;

        var QueryInput = {
            //ReferenceId: $scope.ReferenceId,
            Module: $scope.Module.Name,
            Application: $scope.Application
        };

        retrieveLCCDirectoryLog(QueryInput);
    };

    $scope.setModalTarget = function (directoryItemType) {        
        if (directoryItemType === 0) {
            return "#myModal";
        }
        else {
            return "";
        }
    };

    $scope.setModalToggle = function (directoryItemType) {
        if (directoryItemType === 0) {
            return "modal";
        }
        else {
            return "";
        }
    };

    $scope.directoryItemIconClass = function (directoryItem) {
        return directoryItem.DirectoryItemType === 0 ? 'glyphicon-file clr-xml' : 'glyphicon-folder-open clr-folder';
    };

    $scope.setRootDirectoryIcon = function (directoryIndex) {
        return directoryIndex === 0 ? 'glyphicon glyphicon-home' : '';
    };

    //Called when folder or file is clicked
    $scope.getFileInfo = function (directoryItem) {
        if (directoryItem.DirectoryItemType === 0) {
            $scope.showLoader = true;            
            $scope.ModalContent = null;
            $scope.Error = null;

            var QueryInput = {
                Path: directoryItem.DirectoryItemPath,
            };

            retrieveLCCFileContent(QueryInput);
        }
        else {
            $scope.directories.push(directoryItem);            
            $scope.showLoader = true;            
            $scope.LCCLog = null;
            $scope.Error = null;

            var QueryInput = {
                Path: directoryItem.DirectoryItemPath,
            };

            retrieveLCCDirectoryLog(QueryInput);
        }
    };

    //Called when breadcrumb is clicked
    $scope.changeDirectory = function (directory, directoryIndex) {
        $scope.getFileInfo(directory);
        var _directoryLength = $scope.directories.length;
        if (_directoryLength > 0) {
            $scope.directories.splice(directoryIndex + 1, _directoryLength - directoryIndex + 1);            
        }
    };

    getMasterDataForLCC();
    $scope.showLoader = false;

}]);