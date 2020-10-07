import { Commit } from 'vuex';
// controller
import { ProductController } from '@/controllers';
// type
import { Product } from '@/types';
// mutation types
import { ADD_PRODUCT } from '../types/mutation.type';

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
  async addProduct({ commit }: { commit: Commit }, newProduct: Product) {
    try {
      const addedProduct = await ProductController.addProduct(newProduct);

      commit(ADD_PRODUCT, addedProduct);
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  ADD_PRODUCT: (state: ProductState, addedProduct: Product) => {
    state.products.push(addedProduct);
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
