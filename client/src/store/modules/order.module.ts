import { Commit } from 'vuex';
// controller
import { OrderController } from '@/controllers';
// types
import { Order } from '@/types';
// mutation types
import { ADD_ORDER, SET_ORDERS } from '../types/mutation.type';

interface OrderState {
  orders: Order[];
  order: Order | null;
}

const state: OrderState = {
  orders: [],
  order: null,
};

const getters = {
  orders: (state: OrderState) => state.orders,
  order: (state: OrderState) => state.order,
};

const actions = {
  async addOrder({ commit }: { commit: Commit }, newOrder: Order) {
    try {
      const res = await OrderController.addOrder(newOrder);
      // TODO: make error message
      if (res.status === 400) throw Error;

      commit(ADD_ORDER, res);
    } catch (err) {
      throw Error;
    }
  },
  async getAllOrders({ commit }: { commit: Commit }) {
    try {
      const orders = await OrderController.getAllOrders();
      // TODO: make error message
      if (!orders) return;

      commit(SET_ORDERS, orders);
    } catch (err) {
      console.log(err.message);
    }
  },
  async getAllOrdersByUserId({ commit }: { commit: Commit }, userId: number) {
    try {
      const orders = await OrderController.getAllOrdersByUserId(userId);
      // TODO: make error message
      if (!orders) return;

      commit(SET_ORDERS, orders);
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  ADD_ORDER: (state: OrderState, newOrder: Order) => {
    state.orders.push(newOrder);
  },
  SET_ORDERS: (state: OrderState, orders: Order[]) => {
    state.orders = orders;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
