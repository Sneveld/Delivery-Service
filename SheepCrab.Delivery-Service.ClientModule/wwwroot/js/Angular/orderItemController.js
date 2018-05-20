var app = angular.module('MyApp');

app.controller('orderItemController', ['$scope', '$http', '$compile', '$rootScope', function ($scope, $http, $compile, $rootScope) {
    $scope.count = 0;
    $scope.price = 0;
    $scope.Id = " ";

    $scope.addItem = function (orderItem) {
        orderItem.Count++;
        $scope.countChanged(orderItem);
    }
    $scope.removeItem = function (orderItem) {
        if (orderItem.Count > 0) {
            orderItem.Count--;
            $scope.countChanged(orderItem);
        }
    }

    $scope.countChanged = function (orderItem) {
        $rootScope.totalPrice -= orderItem.Price;
        orderItem.Price = orderItem.ProductPrice * orderItem.Count;
        $rootScope.totalPrice += orderItem.Price;

        let urlSearchParams = new URLSearchParams();
        urlSearchParams.append('id', orderItem.Product.ID);
        urlSearchParams.append('count', orderItem.Count);
        let body = urlSearchParams.toString();
        var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }

        $http.post("/Chart/SetCount", body, config).then(function (result) {

        });;
    };

    $scope.SaveOrder = function () {
        $http.post("/Chart/SaveOrder", $scope.Order).then(function (redirect) {
            window.location.pathname = redirect.data;
        });
    }

    $http.get("/Chart/GetCurrnetOrder").then(function (result) {
        $scope.Order = JSON.parse(result.data);
    });

    $scope.numberChanged = function () {
        $http.get("/Chart/GetOrderInfoByNumber", { params: { number: $scope.Order.OrderInfo.Number } }).then(function (result) {
            var orderInfo = JSON.parse(result.data);
            if (orderInfo.Number != null) {
                $scope.Order.OrderInfo = orderInfo;
            }
        });
    }


}]);