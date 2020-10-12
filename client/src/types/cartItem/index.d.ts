import { Product } from '../product';

export interface CartItem {
  cartItemId?: number;
  productId: number;
  userId: number;
  cartItemCount: number;
  product?: Product
}
