import { Injectable, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TotalsDto } from '../DTO/totals.dto';
import {  AddProductsDto } from '../DTO/addproduct.dto';

@Injectable()
export class TotalsService {

    totals: TotalsDto;

    private url = "/Chart/";

    constructor(private http: HttpClient) {
        this.totals = new TotalsDto(0);
    }

    getOrderSum() {
        this.http.get(this.url + "/GetOrderSum").subscribe((data: number) => { this.totals = new TotalsDto(data) });
    }

    setCount(id: string, oldPrice: number, newPrice: number, count: number) {
        this.totals.totalPrice -= oldPrice;
        this.totals = new TotalsDto(this.totals.totalPrice + newPrice);

        const body = new AddProductsDto();
        body.productId = id;
        body.count = count;
        this.http.post(this.url + "/SetCount", body).subscribe((data: any) => { this.getOrderSum() });
    }

    selectProduct(id: string, price: number) {
        this.totals = new TotalsDto(this.totals.totalPrice + price);
        const body = new AddProductsDto();
        body.productId = id;
        body.count = 1;
        this.http.post("/MainMenu/AddProductToCard", body).subscribe((data: any) => { this.getOrderSum()});
    }
}

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