import { OrderItemDto } from "./order-item.dto";
import { OrderInfoDto } from "./order-info.dto";

export class OrderDto {
    constructor() {
        this.orderInfo = new OrderInfoDto();
    }

    id: string;
    orderTime: Date;
    deliveryTime: Date;
    description: string;
    isCorrect: boolean;
    items: OrderItemDto[];
    personName: string;
    orderInfoId: string;
    orderInfo: OrderInfoDto;
    isPrint: boolean;
    summPrice: number;
}