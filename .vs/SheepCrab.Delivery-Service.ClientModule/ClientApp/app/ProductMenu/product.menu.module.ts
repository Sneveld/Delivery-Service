import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CategoryListComponent } from './categoryList/category.list.component';
import { ProductMenuController } from './product.menu.controller';
import { ProductController } from '../Product/product.component';

@NgModule(
    {
        imports: [BrowserModule, FormsModule],
        declarations: [CategoryListComponent, ProductMenuController, ProductController],
        exports: [ProductMenuController]
    }
)

export class ProductsMenuModule {

}