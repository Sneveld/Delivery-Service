var app = angular.module('MyApp');

app.controller('FindController', [
    '$scope', '$http', '$compile', function ($scope, $http, $compile) {
        $scope.fimdname = "...";
        $scope.find = function () {

            let urlSearchParams = new URLSearchParams();
            urlSearchParams.append('findname', $scope.fimdname);
            let body = urlSearchParams.toString();
            var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }

            $http.post("/MainMenu/Find", body, config).then(function (result) {

                angular.element('.targetPartial').html('');
                var newDirective = $compile(result.data)($scope);
                angular.element('.targetPartial').append(newDirective);

            });
        }
    }
]);