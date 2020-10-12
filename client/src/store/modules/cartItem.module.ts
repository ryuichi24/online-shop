import { Commit } from 'vuex';
// types
import { CartItem } from '@/types';
// mutation types
import {
  ADD_CART_ITEM,
  REMOVE_CART_ITEM,
  UPDATE_CART_ITEM_COUNT,
  SET_CART_ITEMS,
  SET_IS_IN_CART,
} from '@/store/types/mutation.type';
// controller
import { CartItemController } from '@/controllers';

interface CartItemState {
  cartItem: CartItem | null;
  cartItems: CartItem[];
  cartItemsCount: number;
  isInCart: boolean;
}

const state: CartItemState = {
  cartItem: null,
  cartItems: [],
  cartItemsCount: 0,
  isInCart: false,
};

const getters = {
  cartItem: (state: CartItemState) => state.cartItem,
  cartItems: (state: CartItemState) => state.cartItems,
  cartItemsCount: (state: CartItemState) => state.cartItemsCount,
  isInCart: (state: CartItemState) => state.isInCart,
};

const actions = {
  async addCartItem({ commit }: { commit: Commit }, newCartItem: CartItem) {
    try {
      const addedCartItem = await CartItemController.addCartItem(newCartItem);
      // TODO: make error message
      if (!addedCartItem) return;

      commit(ADD_CART_ITEM, addedCartItem);
    } catch (err) {
      console.log(err.message);
    }
  },
  async removeCartItem({ commit }: { commit: Commit }, cartItemId: number) {
    try {
      const res = await CartItemController.removeCartItem(cartItemId);
      // TODO populate error message
      if (!res) return;

      commit(REMOVE_CART_ITEM, cartItemId);
    } catch (err) {
      console.log(err.message);
    }
  },
  async updateCartItemCount(
    { commit }: { commit: Commit },
    { cartItemId, cartItemCount }: { cartItemId: number; cartItemCount: number },
  ) {
    try {
      const res = await CartItemController.updateCartItemCount(cartItemId, cartItemCount);
      // TODO populate error message
      if (!res) return;

      commit(UPDATE_CART_ITEM_COUNT, { cartItemId, cartItemCount });
    } catch (err) {
      console.log(err.message);
    }
  },
  async getAllCartItemsByUserId({ commit }: { commit: Commit }, userId: number) {
    try {
      const cartItems = await CartItemController.getAllCartItemsByUserId(userId);

      commit(SET_CART_ITEMS, cartItems);
    } catch (err) {
      console.log(err.message);
    }
  },
  checkIsInCart({ commit }: { commit: Commit }, productId: number) {
    commit(SET_IS_IN_CART, productId);
  },
};

const mutations = {
  ADD_CART_ITEM: (state: CartItemState, newCartItem: CartItem) => {
    state.cartItems.push(newCartItem);
    state.cartItemsCount = state.cartItems.length;
  },
  REMOVE_CART_ITEM: (state: CartItemState, cartItemId: number) => {
    const indexToRemove = state.cartItems.findIndex((c: CartItem) => c.cartItemId === cartItemId);
    state.cartItems.splice(indexToRemove, 1);
  },
  UPDATE_CART_ITEM_COUNT: (
    state: CartItemState,
    { cartItemId, cartItemCount }: { cartItemId: number; cartItemCount: number },
  ) => {
    const indexToUpdate = state.cartItems.findIndex((c: CartItem) => c.cartItemId === cartItemId);
    state.cartItems[indexToUpdate].cartItemCount = cartItemCount;
  },
  SET_CART_ITEMS: (state: CartItemState, cartItems: CartItem[]) => {
    state.cartItems = cartItems;
  },
  SET_IS_IN_CART: (state: CartItemState, productId: number) => {
    const isInCart = state.cartItems.some((c: CartItem) => c.productId === productId);
    state.isInCart = isInCart;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
