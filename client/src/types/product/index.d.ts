import { Category } from '../category';

export interface Product {
    productId?: number;
    name: string;
    price: number;
    description: string;
    inventory: number;
    image: string | null;
    categoryId: number;
    category?: Category
}