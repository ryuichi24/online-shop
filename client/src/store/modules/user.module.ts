import { Commit } from 'vuex';
// types
import { User } from '@/types';
// mutation types
import { CLEAR_AUTH } from '@/store/types/mutation.type';
// services
import JwtService from '@/services/jwt.service';

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
      // do api call
      // commit
    } catch (err) {
      console.log(err.message);
    }
  },
  async loginUser(
    { commit }: { commit: Commit },
    userCredentials: { email: string; password: string }
  ) {
    try {
      // do api
      // commit
    } catch (err) {
      console.log(err.message);
    }
  },
  async logoutUser({ commit }: { commit: Commit }) {
    commit(CLEAR_AUTH);
  },
  async checkAuth() {
    try {
      // do api call
      // commit
    } catch (err) {
      console.log(err.message);
    }
  }
};

const mutations = {
  SET_AUTH: (state: UserState, { user, token }: { user: User, token: string }) => {
    state.currentUser = user;
    state.isAuthenticated = true;
    if (token) JwtService.saveToken(token);
  },
  CLEAR_AUTH: (state: UserState) => {
    JwtService.destroyToken();
    state.currentUser = null;
    state.isAuthenticated = false;
  }
};

export default {
  state,
  actions,
  mutations,
  getters,
};
