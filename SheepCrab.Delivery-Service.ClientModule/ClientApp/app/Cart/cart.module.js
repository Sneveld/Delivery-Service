var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CartComponent } from './cart.component';
import { CartService } from './cart.service';
import { CartItemsComponent } from './CartList/CartListItem/cart-items-list.component';
import { CartProfileComponent } from './CartList/CartProfile/cart-profile.component';
var CartModule = /** @class */ (function () {
    function CartModule() {
    }
    CartModule = __decorate([
        NgModule({
            imports: [BrowserModule, FormsModule],
            declarations: [CartComponent, CartItemsComponent, CartProfileComponent],
            providers: [CartService],
            exports: [CartComponent]
        })
    ], CartModule);
    return CartModule;
}());
export { CartModule };
//# sourceMappingURL=cart.module.js.map