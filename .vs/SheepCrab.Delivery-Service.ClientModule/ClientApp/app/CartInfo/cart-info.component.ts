import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { TotalsService } from '../Services/total.service';

@Component({
    selector: 'cart-info',
    templateUrl: './cartInfo.html',
    styleUrls: ['./cartInfo.css']
})

export class CartInfoComponent implements OnInit {

    constructor(public totalService: TotalsService) {

    }

    ngOnInit(): void {
        this.totalService.getOrderSum();
    }

}
