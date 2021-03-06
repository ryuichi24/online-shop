import { Commit } from 'vuex';
// services
import JwtService from '@/services/jwt.service';
// controllers
import { AdminController } from '@/controllers';
// types
import { Admin } from '@/types';
// mutation types
import { SET_ADMIN_AUTH, CLEAR_ADMIN_AUTH } from '../types/mutation.type';

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
    adminCredentials: { email: string; password: string },
  ) {
    try {
      const { admin, token } = await AdminController.loginAdmin(adminCredentials);
      // TODO: make error message
      if ((!admin) || (!token)) return;

      commit(SET_ADMIN_AUTH, { admin, token });
    } catch (err) {
      console.log(err.message);
    }
  },
  async checkAdminAuth({ commit }: { commit: Commit }) {
    try {
      if (!JwtService.getAdminToken()) return commit(CLEAR_ADMIN_AUTH);
      const admin = await AdminController.checkAdminAuth();
      if (!admin) return commit(CLEAR_ADMIN_AUTH);

      commit(SET_ADMIN_AUTH, { admin });
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  SET_ADMIN_AUTH: (state: AdminState, { admin, token }: { admin: Admin; token: string }) => {
    state.currentAdmin = admin;
    state.isAdmin = true;
    if (token) JwtService.saveAdminToken(token);
  },
  CLEAR_ADMIN_AUTH: (state: AdminState) => {
    state.currentAdmin = null;
    state.isAdmin = false;
    JwtService.destroyAdminToken();
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
