import { Commit } from 'vuex';
// type
import { Product } from '@/types';

interface ProductState {
  selectedProduct: Product | null;
  products: Product[];
}

const state: ProductState = {
  selectedProduct: null,
  products: [],
};

const getters = {
  selectedProduct: (state: ProductState) => state.selectedProduct,
  products: (state: ProductState) => state.products,
};

const actions = {
  async addProduct() {
    try {
      // api call

      // commit
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  ADD_PRODUCT: (state: ProductState, product: Product) => {
    state.products.push(product);
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
