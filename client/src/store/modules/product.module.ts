import { Commit } from 'vuex';
// controller
import { ProductController } from '@/controllers';
// type
import { Product } from '@/types';
// mutation types
import { SET_PRODUCTS, ADD_PRODUCT } from '../types/mutation.type';

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
  async getProducts({ commit }: { commit: Commit }) {
    try {
      const products = await ProductController.getProducts();

      commit(SET_PRODUCTS, products);
    } catch (err) {
      console.log(err.message);
    }
  },
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
  SET_PRODUCTS: (state: ProductState, products: Product[]) => {
    state.products = products;
  },
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
