var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Input, Output, Component, EventEmitter } from '@angular/core';
import { CategoryDto } from '../../DTO/category.dto';
var CategoryListComponent = /** @class */ (function () {
    function CategoryListComponent() {
        this.selectCategory = new EventEmitter();
    }
    CategoryListComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.childCategories = this.categories.filter(function (c) { return c.parentCategoryId === _this.category.id; });
    };
    CategoryListComponent.prototype.updateProducts = function (id) {
        this.selectCategory.emit(id);
    };
    __decorate([
        Input(),
        __metadata("design:type", CategoryDto)
    ], CategoryListComponent.prototype, "category", void 0);
    __decorate([
        Input(),
        __metadata("design:type", Array)
    ], CategoryListComponent.prototype, "categories", void 0);
    __decorate([
        Output(),
        __metadata("design:type", Object)
    ], CategoryListComponent.prototype, "selectCategory", void 0);
    CategoryListComponent = __decorate([
        Component({
            selector: 'category-list',
            templateUrl: "./category.list.html"
        }),
        __metadata("design:paramtypes", [])
    ], CategoryListComponent);
    return CategoryListComponent;
}());
export { CategoryListComponent };
//# sourceMappingURL=category.list.component.js.map