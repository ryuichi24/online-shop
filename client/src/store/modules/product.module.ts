import { Commit } from 'vuex';
// controller
import { ProductController } from '@/controllers';
// type
import { Product } from '@/types';
// mutation types
import { SET_PRODUCTS, ADD_PRODUCT, SET_SELECTED_PRODUCT } from '../types/mutation.type';

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
  async updateProduct({ commit }: { commit: Commit }, productToUpdate: Product) {
    try {
      console.log(productToUpdate);
    } catch (err) {
      console.log(err.message);
    }
  },
  selectProduct({ commit }: { commit: Commit }, productId: number) {
    if (!productId || typeof productId !== 'number') return;

    console.log(productId);

    commit(SET_SELECTED_PRODUCT, productId);
  },
};

const mutations = {
  SET_PRODUCTS: (state: ProductState, products: Product[]) => {
    state.products = products;
  },
  ADD_PRODUCT: (state: ProductState, addedProduct: Product) => {
    state.products.push(addedProduct);
  },
  SET_SELECTED_PRODUCT: (state: ProductState, productId: number) => {
    const selected = state.products.find((p: Product) => p.productId === productId);
    if (!selected) return;

    state.selectedProduct = selected;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
