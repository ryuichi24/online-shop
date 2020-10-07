import { createStore } from 'vuex';
// modules
import { admin, category } from './modules';

export default createStore({
  modules: {
    admin,
    category,
  },
});
