import { Commit } from 'vuex';
// controller
import { ProductController } from '@/controllers';
// type
import { Product } from '@/types';
// mutation types
import {
  SET_PRODUCTS,
  SET_PRODUCT,
  ADD_PRODUCT,
  SET_SELECTED_PRODUCT,
  UPDATE_PRODUCT,
} from '../types/mutation.type';

interface ProductState {
  product: Product | null;
  products: Product[];
}

const state: ProductState = {
  product: null,
  products: [],
};

const getters = {
  product: (state: ProductState) => state.product,
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
  async getProductById({ commit }: { commit: Commit }, productId: number) {
    try {
      const product = await ProductController.getProductById(productId);
      if (!product) return;

      commit(SET_PRODUCT, product);
    } catch (err) {
      console.log(err.message);
    }
  },
  async updateProduct({ commit }: { commit: Commit }, productToUpdate: Product) {
    try {
      const res = await ProductController.updatedProduct(productToUpdate);
      // TODO: make error message
      if (!res) return;

      commit(UPDATE_PRODUCT, productToUpdate);
    } catch (err) {
      console.log(err.message);
    }
  },
  selectProduct({ commit }: { commit: Commit }, productId: number) {
    if (!productId || typeof productId !== 'number') return;

    commit(SET_SELECTED_PRODUCT, productId);
  },
};

const mutations = {
  SET_PRODUCTS: (state: ProductState, products: Product[]) => {
    state.products = products;
  },
  SET_PRODUCT: (state: ProductState, product: Product) => {
    state.product = product;
  },
  ADD_PRODUCT: (state: ProductState, addedProduct: Product) => {
    state.products.push(addedProduct);
  },
  SET_SELECTED_PRODUCT: (state: ProductState, productId: number) => {
    const selected = state.products.find((p: Product) => p.productId === productId);
    if (!selected) return;

    state.product = selected;
  },
  UPDATE_PRODUCT: (state: ProductState, product: Product) => {
    const indexToUpdate = state.products.findIndex(
      (p: Product) => p.productId === product.productId,
    );
    state.products[indexToUpdate] = product;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
