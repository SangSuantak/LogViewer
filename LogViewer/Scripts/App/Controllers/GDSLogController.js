var LogApp = angular.module("LogApp");
LogApp.controller("GDSLogController", ["$scope", "dataFactory", function ($scope, dataFactory) {

    $scope.Applications;
    $scope.QueryInput = {};
    $scope.GDSLog;
    $scope.Error;

    function getWBSApplications() {
        dataFactory.getWBSApplications().success(function (data) {
            $scope.Applications = data.Applications;
        });
    }

    $scope.getGDSLog = function () {
        $scope.showLoader = true;
        var QueryInput = {
            ReferenceId: $scope.ReferenceId,
            Application: $scope.Application
        };

        $scope.GDSLog = null;
        $scope.Error = null;

        dataFactory.getGDSLog(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            }
            else {
                $scope.GDSLog = data.GDSLog;
            }
            $scope.showLoader = false;
        }).error(function (data) {
            $scope.Error = "There was a problem while fetching the XML Logs";
            $scope.showLoader = false;
        });
    };

    $(document).on("click", ".slide", function () {
        var elem = $(this).next("div");
        if (elem.is(":hidden")) {
            elem.slideDown("normal");
        }
        else {
            elem.slideUp("normal");
        }
    });

    $scope.setModalContent = function (content) {
        $scope.ModalContent = content;
    };

    getWBSApplications();
    $scope.showLoader = false;

}]);