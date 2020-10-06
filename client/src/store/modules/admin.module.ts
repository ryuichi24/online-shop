import { Commit } from 'vuex';
// services
import JwtService from '@/services/jwt.service';
// controllers
import { AdminController } from '@/controllers';
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
      const res = await AdminController.loginAdmin(adminCredentials);
      const { admin, token } = res;

      commit(SET_ADMIN_AUTH, { admin, token });
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  SET_ADMIN_AUTH: (
    state: AdminState,
    { admin, token }: { admin: Admin; token: string }
  ) => {
    state.currentAdmin = admin;
    state.isAdmin = true;
    if (token) JwtService.saveToken(token);
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};