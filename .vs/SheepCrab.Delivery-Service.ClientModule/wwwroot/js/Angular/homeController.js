var app = angular.module('MyApp');

app.controller('homeController', ['$scope', '$http', '$timeout', function ($scope, $http, $timeout) {


    $http.get("/Home/GetLandingPageImages").then(function (data) {
        $scope.slides = data.data;
    });


    $scope.myInterval = 50000;
}]);