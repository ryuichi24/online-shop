import { Commit } from 'vuex';
// types
import { User } from '@/types';
// mutation types
import { CLEAR_AUTH, SET_AUTH } from '@/store/types/mutation.type';
// services
import JwtService from '@/services/jwt.service';
// controller
import { UserController } from '@/controllers';

interface UserState {
  currentUser: User | null;
  isAuthenticated: boolean;
}

const state: UserState = {
  currentUser: null,
  isAuthenticated: false,
};

const getters = {
  currentUser: (state: UserState) => state.currentUser,
  isAuthenticated: (state: UserState) => state.isAuthenticated,
};

const actions = {
  async signUpUser({ commit }: { commit: Commit }, newUser: User) {
    try {
      const res = await UserController.createUser(newUser);

      commit(SET_AUTH, res);
    } catch (err) {
      console.log(err.message);
    }
  },
  async loginUser(
    { commit }: { commit: Commit },
    userCredentials: { email: string; password: string }
  ) {
    try {
      const res = await UserController.loginUser(userCredentials);

      commit(SET_AUTH, res);
    } catch (err) {
      console.log(err.message);
    }
  },
  async logoutUser({ commit }: { commit: Commit }) {
    commit(CLEAR_AUTH);
  },
  async checkAuth({ commit }: { commit: Commit }) {
    try {
      const user = await UserController.checkUserAuth();

      commit(SET_AUTH, { user });
    } catch (err) {
      console.log(err.message);
    }
  },
};

const mutations = {
  SET_AUTH: (state: UserState, { user, token }: { user: User; token: string }) => {
    state.currentUser = user;
    state.isAuthenticated = true;
    if (token) JwtService.saveToken(token);
  },
  CLEAR_AUTH: (state: UserState) => {
    JwtService.destroyToken();
    state.currentUser = null;
    state.isAuthenticated = false;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
