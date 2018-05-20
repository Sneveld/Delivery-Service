var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Input, Component } from '@angular/core';
import { TotalsService } from '../../../Services/total.service';
import { OrderDto } from '../../../DTO/Order/order.dto';
import { CartService } from '../../cart.service';
var CartItemsComponent = /** @class */ (function () {
    function CartItemsComponent(cartService, totalsService) {
        this.cartService = cartService;
        this.totalsService = totalsService;
    }
    CartItemsComponent.prototype.addItem = function (orderItemDto) {
        orderItemDto.count++;
        var oldPrice = orderItemDto.price;
        orderItemDto.price = orderItemDto.product.price * orderItemDto.count;
        this.totalsService.setCount(orderItemDto.id, oldPrice, orderItemDto.price, orderItemDto.count);
    };
    CartItemsComponent.prototype.removeItem = function (orderItemDto) {
        if (orderItemDto.count > 0) {
            orderItemDto.count--;
            var oldPrice = orderItemDto.price;
            orderItemDto.price = orderItemDto.product.price * orderItemDto.count;
            this.totalsService.setCount(orderItemDto.id, oldPrice, orderItemDto.price, orderItemDto.count);
        }
    };
    __decorate([
        Input(),
        __metadata("design:type", OrderDto)
    ], CartItemsComponent.prototype, "order", void 0);
    CartItemsComponent = __decorate([
        Component({
            selector: 'cart-items-list',
            template: "<div>\n            <table class=\"table\">\n                <tr>\n                    <th>\n                        \u041F\u0440\u043E\u0434\u0443\u043A\u0442\n                    </th>\n                    <th>\n                        \u041C\u0430\u0441\u0441\u0430\n                    </th>\n                    <th>\n                        \u041A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u043E\n                    </th>\n                    <th>\n                        \u0426\u0435\u043D\u0430\n                    </th>\n                </tr>\n\n                <tr *ngFor=\"let orderitem of order.items\">\n                    <td>\n                        {{orderitem.product.name}}\n                    </td>\n                    <td>\n                        {{orderitem.mass}}\n                    </td>\n                    <td>\n                        <span (click)=\"removeItem(orderitem)\" class=\"glyphicon glyphicon-minus\"></span>\n                        {{orderitem.Count}}\n                        <span (click)=\"addItem(orderitem)\" class=\"glyphicon glyphicon-plus\"></span>\n                    </td>\n                    <td>\n                        {{orderitem.price}}\n                    </td>\n                </tr>\n            </table>\n        </div>",
            providers: []
        }),
        __metadata("design:paramtypes", [CartService, TotalsService])
    ], CartItemsComponent);
    return CartItemsComponent;
}());
export { CartItemsComponent };
//$scope.addItem = function (orderItem) {
//    orderItem.Count++;
//    $scope.countChanged(orderItem);
//}
//$scope.removeItem = function (orderItem) {
//    if (orderItem.Count > 0) {
//        orderItem.Count--;
//        $scope.countChanged(orderItem);
//    }
//}
//$scope.countChanged = function (orderItem) {
//    $rootScope.totalPrice -= orderItem.Price;
//    orderItem.Price = orderItem.ProductPrice * orderItem.Count;
//    $rootScope.totalPrice += orderItem.Price;
//    let urlSearchParams = new URLSearchParams();
//    urlSearchParams.append('id', orderItem.Product.ID);
//    urlSearchParams.append('count', orderItem.Count);
//    let body = urlSearchParams.toString();
//    var config = { headers: { 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' } }
//    $http.post("/Chart/SetCount", body, config).then(function (result) {
//    });;
//};
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
//# sourceMappingURL=cart-items-list.component.js.map