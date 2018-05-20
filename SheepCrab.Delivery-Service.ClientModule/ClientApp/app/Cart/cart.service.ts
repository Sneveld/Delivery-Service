import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddProductsDto } from '../DTO/addproduct.dto';
import { OrderDto } from '../DTO/Order/order.dto';

@Injectable()

export class CartService {
    private url = "/Chart/";
    constructor(private http: HttpClient) {

    }

    saveOrder(order: OrderDto) {
        return this.http.post(this.url + "/SaveOrder", order);
    }

    getCurrentOrder() {
        return this.http.get(this.url + "/GetCurrnetOrder");
    }

    getOrderInfoByNumber(number: string) {
        return this.http.get(this.url + "/GetOrderInfoByNumber", { params: { number: number }});
    }
}



//$http.post("/Chart/SetCount", body, config).then(function (result) {

//});;
//    };

//$scope.SaveOrder = function () {
//    $http.post("/Chart/SaveOrder", $scope.Order).then(function (redirect) {
//        window.location.pathname = redirect.data;
//    });
//}

//$http.get("/Chart/GetCurrnetOrder").then(function (result) {
//    $scope.Order = JSON.parse(result.data);
//});

//$scope.numberChanged = function () {
//    $http.get("/Chart/GetOrderInfoByNumber", { params: { number: $scope.Order.OrderInfo.Number } }).then(function (result) {
//        var orderInfo = JSON.parse(result.data);
//        if (orderInfo.Number != null) {
//            $scope.Order.OrderInfo = orderInfo;
//        }
//    });
//}