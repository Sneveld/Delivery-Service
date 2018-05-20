import { Component, OnInit } from '@angular/core';
import { ProductMenuService } from "./product.menu.service";
import { CategoryDto } from "../DTO/category.dto";
import { ProductDto } from "../DTO/product.dto";

@Component({
    selector: 'product-menu',
    templateUrl: './product.menu.html',
    styleUrls: ['./productMenu.css'],
    providers: [ProductMenuService]
})

export class ProductMenuController implements OnInit {
    siteMenu: CategoryDto[];
    topLvlCategories: CategoryDto[];
    products: ProductDto[];
    fimdname: any;

    constructor(private productsMenuService: ProductMenuService) {
        this.fimdname = '...';
    }

    ngOnInit(): void {
        this.productsMenuService.getSiteMenu().subscribe((data: CategoryDto[]) => {
            this.siteMenu = data;
            this.topLvlCategories = this.siteMenu.filter(c => c.parentCategoryId === null);
        });

        this.getAllProducts();
    }

    updateProducts(id: string) {
        this.productsMenuService.updateProducts(id).subscribe((data: ProductDto[]) => { this.products = data });
    }

    find() {
        this.productsMenuService.find(this.fimdname).subscribe((data: ProductDto[]) => { this.products = data });
    }

    getAllProducts() {
        this.productsMenuService.getAllProducts().subscribe((data: ProductDto[]) => { this.products = data });
    }

}