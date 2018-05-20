var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
var CartService = /** @class */ (function () {
    function CartService(http) {
        this.http = http;
        this.url = "/Chart/";
    }
    CartService.prototype.saveOrder = function (order) {
        return this.http.post(this.url + "/SaveOrder", order);
    };
    CartService.prototype.getCurrentOrder = function () {
        return this.http.get(this.url + "/GetCurrnetOrder");
    };
    CartService.prototype.getOrderInfoByNumber = function (number) {
        return this.http.get(this.url + "/GetOrderInfoByNumber", { params: { number: number } });
    };
    CartService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], CartService);
    return CartService;
}());
export { CartService };
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
//# sourceMappingURL=cart.service.js.map