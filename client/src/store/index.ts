import { createStore } from 'vuex';
// modules
import { user, admin, category, product } from './modules';

export default createStore({
  modules: {
    admin,
    category,
    product,
    user,
  },
});
