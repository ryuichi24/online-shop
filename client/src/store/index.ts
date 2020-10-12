import { createStore } from 'vuex';
// modules
import { user, admin, category, product, cartItem, address, order } from './modules';

export default createStore({
  modules: {
    admin,
    category,
    product,
    user,
    cartItem,
    address,
    order,
  },
});
