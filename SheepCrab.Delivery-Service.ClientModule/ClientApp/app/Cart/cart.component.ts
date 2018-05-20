import { Component, OnInit } from '@angular/core';
import { OrderDto } from '../DTO/Order/order.dto';
import { CartService } from './cart.service';
import { Router } from '@angular/router';

@Component({
    selector: 'cart-page',
    templateUrl: './cart.html',
    styleUrls: ['./cart.css'],
    providers:[]
})

export class CartComponent {
    order: OrderDto = new OrderDto();

    constructor(private cartService: CartService, private router: Router) {
        
    }

    ngOnInit(): void {
        this.getCurrentOrder();
    }

    saveOrder() {
        this.cartService.saveOrder(this.order).subscribe((data: any) => { this.router.navigate([''])});
    }

    getCurrentOrder() {
        this.cartService.getCurrentOrder().subscribe((data: OrderDto) => { this.order = data });
    }
}

//$scope.SaveOrder = function () {
//    $http.post("/Chart/SaveOrder", $scope.Order).then(function (redirect) {
//        window.location.pathname = redirect.data;
//    });
//}

//$http.get("/Chart/GetCurrnetOrder").then(function (result) {
//    $scope.Order = JSON.parse(result.data);
//});