import { Commit } from 'vuex';
// controller
import { CategoryController } from '@/controllers';
// types
import { Category } from '@/types';
// mutation types
import { ADD_CATEGORY } from '../types/mutation.type';

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
  async addCategory({ commit }: { commit: Commit }, categoryName: string) {
    try {
      const { category } = await CategoryController.addCategory(categoryName);

      commit(ADD_CATEGORY, category);
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
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
