import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { ProductDto } from '../DTO/product.dto';
import { TotalsService } from '../Services/total.service';

@Component({
    selector: 'product',
    templateUrl: './product.html',
    styleUrls: [`./product.css`]    
})

export class ProductController {
    @Input() product: ProductDto;

    constructor(private totalsService: TotalsService) {

    }

    selectProduct(id: string, price: number) {
        this.totalsService.selectProduct(id, price);
    }
}