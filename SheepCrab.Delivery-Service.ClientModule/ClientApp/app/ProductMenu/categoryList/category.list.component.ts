import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { CategoryDto } from '../../DTO/category.dto';
import { ProductMenuService } from '../product.menu.service';


@Component({
    selector: 'category-list',
    templateUrl: `./category.list.html`
})

export class CategoryListComponent implements OnInit {
    @Input() category: CategoryDto;
    @Input() categories: CategoryDto[];
    @Output() selectCategory = new EventEmitter<string>();

    childCategories: CategoryDto[];

    constructor() {

    }

    ngOnInit(): void {
        this.childCategories = this.categories.filter(c => c.parentCategoryId === this.category.id);
    }

    updateProducts(id: string) {
        this.selectCategory.emit(id);
    }
   
}
