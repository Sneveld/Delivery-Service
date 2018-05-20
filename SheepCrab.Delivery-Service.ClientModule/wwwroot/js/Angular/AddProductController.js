var app = angular.module('MyApp');

app.controller('AddProductController', ['$scope', '$http', '$rootScope', function ($scope, $http, $rootScope) {

    $scope.init = function (sum) {
        $http.get("/Chart/GetOrderSum").then(function (sum) {
            $rootScope.totalPrice = parseFloat(sum.data);
        });

    };

    $scope.selectProduct = function (id, price) {
        $rootScope.totalPrice += parseFloat(price);

        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('productId', id);
        urlSearchParams.append('count', 1);
        let body = urlSearchParams.toString();       
        var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }

        $http.post("/MainMenu/AddProductToCard", body, config);
    };

}]);