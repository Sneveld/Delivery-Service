import { Input, Component, OnInit } from '@angular/core';
import { TotalsService } from '../../../Services/total.service';
import { OrderDto } from '../../../DTO/Order/order.dto';
import { CartService } from '../../cart.service';
import { OrderItemDto } from '../../../DTO/Order/order-item.dto';

@Component({
    selector: 'cart-items-list',
    template: `<div>
            <table class="table">
                <tr>
                    <th>
                        Продукт
                    </th>
                    <th>
                        Масса
                    </th>
                    <th>
                        Количество
                    </th>
                    <th>
                        Цена
                    </th>
                </tr>

                <tr *ngFor="let orderitem of order.items">
                    <td>
                        {{orderitem.product.name}}
                    </td>
                    <td>
                        {{orderitem.mass}}
                    </td>
                    <td>
                        <span (click)="removeItem(orderitem)" class="glyphicon glyphicon-minus"></span>
                        {{orderitem.Count}}
                        <span (click)="addItem(orderitem)" class="glyphicon glyphicon-plus"></span>
                    </td>
                    <td>
                        {{orderitem.price}}
                    </td>
                </tr>
            </table>
        </div>`,
    providers: []
})

export class CartItemsComponent {
    @Input() order: OrderDto;

    constructor(private cartService: CartService, private totalsService: TotalsService) {

    }

    addItem(orderItemDto: OrderItemDto) {
        orderItemDto.count++;
        const oldPrice = orderItemDto.price;
        orderItemDto.price = orderItemDto.product.price * orderItemDto.count;
        this.totalsService.setCount(orderItemDto.id, oldPrice, orderItemDto.price, orderItemDto.count);
    }

    removeItem(orderItemDto: OrderItemDto) {
        
        if (orderItemDto.count > 0) {
            orderItemDto.count--;
            const oldPrice = orderItemDto.price;
            orderItemDto.price = orderItemDto.product.price * orderItemDto.count;
            this.totalsService.setCount(orderItemDto.id, oldPrice, orderItemDto.price, orderItemDto.count);
        }
    }
}

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