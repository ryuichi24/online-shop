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

export default {
  API,
  setToken,
}
