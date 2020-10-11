import { Commit } from 'vuex';
// types
import { CartItem } from '@/types';
// mutation types
import { ADD_CART_ITEM } from '@/store/types/mutation.type';
// services
import JwtService from '@/services/jwt.service';
// controller
import { CartItemController } from '@/controllers';

interface CartItemState {
  cartItem: CartItem | null;
  cartItems: CartItem[];
  cartItemsCount: number;
}

const state: CartItemState = {
  cartItem: null,
  cartItems: [],
  cartItemsCount: 0,
};

const getters = {
  cartItem: (state: CartItemState) => state.cartItem,
  cartItems: (state: CartItemState) => state.cartItems,
  cartItemsCount: (state: CartItemState) => state.cartItemsCount,
};

const actions = {
  async addCartItem({ commit }: { commit: Commit }, newCartItem: CartItem) {
    try {
      const addedCartItem = await CartItemController.addCartItem(newCartItem);
      if (!addedCartItem) return;

      commit(ADD_CART_ITEM, addedCartItem);
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  ADD_CART_ITEM: (state: CartItemState, newCartItem: CartItem) => {
    state.cartItems.push(newCartItem);
    state.cartItemsCount = state.cartItems.length;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
