import { Input, Component, OnInit } from '@angular/core';
import { OrderInfoDto } from '../../../DTO/Order/order-info.dto';
import { CartService } from '../../cart.service';
import { OrderDto } from '../../../DTO/Order/order.dto';

@Component({
    selector: 'cart-profile',
    templateUrl: './cart-profile.html',
    styleUrls: ['./cart-profile.css'],
    providers: []
})

export class CartProfileComponent {
    @Input() order: OrderDto;

    constructor(private cartService: CartService) {

    }

    numberChanged() {
        this.cartService.getOrderInfoByNumber(this.order.orderInfo.number).subscribe((data: OrderInfoDto) => {
            if (data != null && data.number != null) {
                this.order.orderInfo = data;
            }
        });
    }
}