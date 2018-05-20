var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Input, Component } from '@angular/core';
import { ProductDto } from '../DTO/product.dto';
import { TotalsService } from '../Services/total.service';
var ProductController = /** @class */ (function () {
    function ProductController(totalsService) {
        this.totalsService = totalsService;
    }
    ProductController.prototype.selectProduct = function (id, price) {
        this.totalsService.selectProduct(id, price);
    };
    __decorate([
        Input(),
        __metadata("design:type", ProductDto)
    ], ProductController.prototype, "product", void 0);
    ProductController = __decorate([
        Component({
            selector: 'product',
            templateUrl: './product.html',
            styleUrls: ["./product.css"]
        }),
        __metadata("design:paramtypes", [TotalsService])
    ], ProductController);
    return ProductController;
}());
export { ProductController };
//# sourceMappingURL=product.component.js.map