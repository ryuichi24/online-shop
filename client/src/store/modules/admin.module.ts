import { Commit } from 'vuex';

// types
import { Admin } from '@/types';
// mutation types
import { SET_ADMIN_AUTH } from '../types/mutation.type';

interface AdminState {
  currentAdmin: Admin | null;
  isAdmin: boolean;
}

const state: AdminState = {
  currentAdmin: null,
  isAdmin: false,
};

const getters = {
  currentAdmin: (state: AdminState) => state.currentAdmin,
  isAdmin: (state: AdminState) => state.isAdmin,
};

const actions = {
  async loginAdmin(
    { commit }: { commit: Commit },
    adminCredentials: { email: string; password: string }
  ) {
    try {
      const { email, password } = adminCredentials;
      // do some api call
      // get token

      // dummy results
      const admin = { name: 'Admin' };
      const token = 'ThisIsADummyToken';

      commit(SET_ADMIN_AUTH, { admin, token });
    } catch (error) {}
  },
};

const mutations = {
  SET_ADMIN_AUTH: (
    state: AdminState,
    { admin, token }: { admin: { name: string }; token: string }
  ) => {
    state.currentAdmin = admin;
    state.isAdmin = true;
    // TODO: add a json web token service
    if (token) localStorage.setItem('token', token);
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
