import { ProductDto } from "../product.dto";

export class OrderItemDto {
    id: string;
    product: ProductDto;
    mass: number;
    count: number;
    price: number;
}