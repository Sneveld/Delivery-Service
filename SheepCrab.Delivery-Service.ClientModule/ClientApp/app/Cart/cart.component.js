var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { OrderDto } from '../DTO/Order/order.dto';
import { CartService } from './cart.service';
import { Router } from '@angular/router';
var CartComponent = /** @class */ (function () {
    function CartComponent(cartService, router) {
        this.cartService = cartService;
        this.router = router;
        this.order = new OrderDto();
    }
    CartComponent.prototype.ngOnInit = function () {
        this.getCurrentOrder();
    };
    CartComponent.prototype.saveOrder = function () {
        var _this = this;
        this.cartService.saveOrder(this.order).subscribe(function (data) { _this.router.navigate(['']); });
    };
    CartComponent.prototype.getCurrentOrder = function () {
        var _this = this;
        this.cartService.getCurrentOrder().subscribe(function (data) { _this.order = data; });
    };
    CartComponent = __decorate([
        Component({
            selector: 'cart-page',
            templateUrl: './cart.html',
            styleUrls: ['./cart.css'],
            providers: []
        }),
        __metadata("design:paramtypes", [CartService, Router])
    ], CartComponent);
    return CartComponent;
}());
export { CartComponent };
//$scope.SaveOrder = function () {
//    $http.post("/Chart/SaveOrder", $scope.Order).then(function (redirect) {
//        window.location.pathname = redirect.data;
//    });
//}
//$http.get("/Chart/GetCurrnetOrder").then(function (result) {
//    $scope.Order = JSON.parse(result.data);
//}); 
//# sourceMappingURL=cart.component.js.map