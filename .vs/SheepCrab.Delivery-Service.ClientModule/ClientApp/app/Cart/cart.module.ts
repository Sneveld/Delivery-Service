import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { CartComponent } from './cart.component';
import { CartService } from './cart.service';
import { CartItemsComponent } from './CartList/CartListItem/cart-items-list.component';
import { CartProfileComponent } from './CartList/CartProfile/cart-profile.component';

@NgModule({
    imports: [BrowserModule, FormsModule],
    declarations: [CartComponent, CartItemsComponent, CartProfileComponent],
    providers: [CartService],
    exports: [CartComponent]

})

export class CartModule {

}