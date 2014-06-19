var LogApp = angular.module("LogApp");
LogApp.controller("EncryptDecryptController", ["$scope", "dataFactory", function ($scope, dataFactory) {
    $scope.EncryptedValue = null;
    $scope.OriginalText = null;

    $scope.encryptPlainText = function () {
        $scope.EncryptedValue = null;
        $scope.Error = null;
        var QueryInput = {
            EncrInputText: $scope.EncrInputText,
            SaltText: $scope.SaltText === "" ? null : $scope.SaltText
        };

        dataFactory.encryptPlainText(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            } else {
                $scope.EncryptedValue = data.EncryptedValue;
            }
        }).error(function () {
            $scope.Error = "Encryption Failed";
        });
    };

    $scope.decryptText = function () {
        $scope.OriginalText = null;
        $scope.Error = null;
        var QueryInput = {
            EncrInputText: $scope.EncrInputText,
            SaltText: $scope.SaltText
        };

        dataFactory.decryptText(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            } else {
                $scope.OriginalText = data.DecryptedValue;
            }
        }).error(function () {
            $scope.Error = "Decryption Failed";
        });
    };

    $scope.encryptXML = function () {
        $scope.EncryptedValue = null;
        $scope.Error = null;
        var QueryInput = {
            EncrInputText: $scope.EncrInputText,
            SaltText: $scope.SaltText === "" ? null : $scope.SaltText
        };

        dataFactory.encryptXML(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            } else {
                $scope.EncryptedValue = data.EncryptedValue;
            }
        }).error(function () {
            $scope.Error = "Encryption Failed";
        });
    };

    $scope.decryptXML = function () {
        $scope.EncryptedValue = null;
        $scope.Error = null;
        var QueryInput = {
            EncrInputText: $scope.EncrInputText,
            SaltText: $scope.SaltText === "" ? null : $scope.SaltText
        };

        dataFactory.decryptXML(QueryInput).success(function (data) {
            if (data.Error) {
                $scope.Error = data.Error;
            } else {
                $scope.EncryptedValue = data.EncryptedValue;
            }
        }).error(function () {
            $scope.Error = "Decryption Failed";
        });
    }

    $scope.emptyData = function () {
        $scope.EncrInputText = null;
        $scope.EncryptedValue = null;
        $scope.OriginalText = null;
        $scope.SaltText = null;
        $scope.Error = null;
    };

}]);