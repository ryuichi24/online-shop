import { createStore } from 'vuex';
// modules
import { user } from './modules';

export default createStore({
    modules: {
      user
  }
});
