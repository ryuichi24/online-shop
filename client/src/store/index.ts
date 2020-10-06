import { createStore } from 'vuex';
// modules
import { admin } from './modules';

export default createStore({
  modules: {
    admin,
  },
});
