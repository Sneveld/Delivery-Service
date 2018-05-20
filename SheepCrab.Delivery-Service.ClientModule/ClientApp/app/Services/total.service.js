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
import { TotalsDto } from '../DTO/totals.dto';
import { AddProductsDto } from '../DTO/addproduct.dto';
var TotalsService = /** @class */ (function () {
    function TotalsService(http) {
        this.http = http;
        this.url = "/Chart/";
        this.totals = new TotalsDto(0);
    }
    TotalsService.prototype.getOrderSum = function () {
        var _this = this;
        this.http.get(this.url + "/GetOrderSum").subscribe(function (data) { _this.totals = new TotalsDto(data); });
    };
    TotalsService.prototype.setCount = function (id, oldPrice, newPrice, count) {
        var _this = this;
        this.totals.totalPrice -= oldPrice;
        this.totals = new TotalsDto(this.totals.totalPrice + newPrice);
        var body = new AddProductsDto();
        body.productId = id;
        body.count = count;
        this.http.post(this.url + "/SetCount", body).subscribe(function (data) { _this.getOrderSum(); });
    };
    TotalsService.prototype.selectProduct = function (id, price) {
        var _this = this;
        this.totals = new TotalsDto(this.totals.totalPrice + price);
        var body = new AddProductsDto();
        body.productId = id;
        body.count = 1;
        this.http.post("/MainMenu/AddProductToCard", body).subscribe(function (data) { _this.getOrderSum(); });
    };
    TotalsService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [HttpClient])
    ], TotalsService);
    return TotalsService;
}());
export { TotalsService };
//$scope.init = function (sum) {
//    $http.get("/Chart/GetOrderSum").then(function (sum) {
//        $rootScope.totalPrice = parseFloat(sum.data);
//    });
//};
//$scope.selectProduct = function (id, price) {
//    $rootScope.totalPrice += parseFloat(price);
//    let urlSearchParams = new URLSearchParams();
//    urlSearchParams.append('productId', id);
//    urlSearchParams.append('count', 1);
//    let body = urlSearchParams.toString();
//    var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }
//    $http.post("/MainMenu/AddProductToCard", body, config);
//}; 
//# sourceMappingURL=total.service.js.map