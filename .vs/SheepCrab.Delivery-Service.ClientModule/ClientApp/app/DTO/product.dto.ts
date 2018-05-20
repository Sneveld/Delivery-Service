import { CategoryDto } from "./category.dto";

export class ProductDto {
    id: string 
    name: string
    description: string
    price: number       
    nominalMass?: number
    category: CategoryDto      
    categoryId: string
    image: string       

}