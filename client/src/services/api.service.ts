import axios from 'axios';
import jwtService from './jwt.service';

const API = axios.create({
  baseURL: process.env.VUE_APP_API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

const setToken = () => {
  if (!jwtService.getToken()) return;
  API.defaults.headers.common = {
    Authorization: `bearer ${jwtService.getToken()}`,
  };
};

const clearAuth = () => {
  delete API.defaults.headers.common.Authorization;
};

const setAdminToken = () => {
  if (!jwtService.getAdminToken()) return;
  API.defaults.headers.common = {
    Authorization: `bearer ${jwtService.getAdminToken()}`,
  };
};

export default {
  API,
  setToken,
  setAdminToken,
  clearAuth,
};
