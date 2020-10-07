import { Commit } from 'vuex';
// controller
import { CategoryController } from '@/controllers';
// types
import { Category } from '@/types';
// mutation types
import { SET_CATEGORIES, ADD_CATEGORY } from '../types/mutation.type';

interface CategoryState {
  categories: Category[];
}

const state = {
  categories: [],
};

const getters = {
  categories: (state: CategoryState) => state.categories,
};

const actions = {
  async getCategories({ commit }: { commit: Commit }) {
    try {
      const categories = await CategoryController.getCategories();

      commit(SET_CATEGORIES, categories);
    } catch (err) {
      console.log(err.message);
    }
  },
  async addCategory({ commit }: { commit: Commit }, categoryName: string) {
    try {
      const category = await CategoryController.addCategory(categoryName);

      commit(ADD_CATEGORY, category);
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  SET_CATEGORIES: (state: CategoryState, categories: Category[]) => {
    state.categories = categories;
  },
  ADD_CATEGORY: (state: CategoryState, category: Category) => {
    state.categories.push(category);
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
