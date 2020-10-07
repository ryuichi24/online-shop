import { createStore } from 'vuex';
// modules
import { admin, category, product } from './modules';

export default createStore({
  modules: {
    admin,
    category,
    product,
  },
});
