export class CategoryDto {
    id: string;
    name: string;
    description: string;
    childCategories: CategoryDto[];
    parentCategory?: CategoryDto;
    parentCategoryId?: string;
}