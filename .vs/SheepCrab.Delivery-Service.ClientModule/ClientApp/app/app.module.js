var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from "./app.component";
import { HomeModule } from "./Home/home.module";
import { LandingPageImagesComponent } from "./Home/LandingPageImage/landing-page-images.component";
import { RouterModule } from '@angular/router';
import { ProductMenuController } from './ProductMenu/product.menu.controller';
import { ProductsMenuModule } from './ProductMenu/product.menu.module';
import { CartInfoComponent } from './CartInfo/cart-info.component';
import { TotalsService } from './Services/total.service';
import { CartModule } from './Cart/cart.module';
import { CartComponent } from './Cart/cart.component';
var appRoutes = [
    { path: '', component: LandingPageImagesComponent },
    { path: 'menu', component: ProductMenuController },
    { path: 'cart', component: CartComponent }
];
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule, HomeModule, ProductsMenuModule, CartModule, RouterModule.forRoot(appRoutes)],
            declarations: [AppComponent, CartInfoComponent],
            providers: [TotalsService],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map