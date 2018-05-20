import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from "./app.component";
import { HomeModule } from "./Home/home.module";
import { LandingPageImagesComponent } from "./Home/LandingPageImage/landing-page-images.component"
import { Routes, RouterModule } from '@angular/router';
import { ProductMenuController } from './ProductMenu/product.menu.controller';
import { ProductsMenuModule } from './ProductMenu/product.menu.module';
import { CartInfoComponent } from './CartInfo/cart-info.component';
import { TotalsService } from './Services/total.service';
import { CartModule } from './Cart/cart.module';
import { CartComponent } from './Cart/cart.component';

const appRoutes: Routes = [
    { path: '', component: LandingPageImagesComponent },
    { path: 'menu', component: ProductMenuController },
    { path: 'cart', component: CartComponent }
];


@NgModule({
    imports: [BrowserModule, FormsModule, HomeModule, ProductsMenuModule, CartModule, RouterModule.forRoot(appRoutes)],
    declarations: [AppComponent, CartInfoComponent],
    providers: [TotalsService],
    bootstrap: [AppComponent]
})

export class AppModule { }