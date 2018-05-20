var app = angular.module('MyApp');

app.controller('menuController', ['$scope', '$http', '$sce', '$compile', '$templateCache', '$rootScope', function ($scope, $http, $sce, $compile, $templateCache, $rootScope) {
    $scope.SiteMenu = [];
    $scope.products = [];
    $scope.fimdname = "...";

    $http.get('/MainMenu/GetSiteMenu').then(function (data) {
        $scope.SiteMenu = JSON.parse(data.data);
    },

        function (error) {
            alert('Error');
        });

    $scope.updateProducts = function (id) {
        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('param', id);
        let body = urlSearchParams.toString();
        var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }

        $http.get("/MainMenu/UpDateProducts", body, config).then(function (result) {

            $scope.products = JSON.parse(result.data);

        });
    };


    $scope.find = function () {
        $http.get("/MainMenu/Find", { params: { findname: $scope.fimdname }}).then(function (result) {

            $scope.products = JSON.parse(result.data);

        });
    }
    
    $http.get("/MainMenu/GetAllProducts").then(function (result) {

        $scope.products = JSON.parse(result.data);
        
    });

}]);