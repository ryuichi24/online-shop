import { Address } from '../address';

interface OrderItem {
    productId: number;
    orderItemCount: number;
}

export interface Order {
    orderId?: number;
    orderedAt?: Date;
    totalPayment: number;
    addressId: number;
    address?: Address;
    userId: number;
    orderItems?: Array<OrderItem>;
}