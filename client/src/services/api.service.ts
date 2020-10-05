import axios from 'axios';
import jwtService from './jwt.service';

export const API = axios.create({
  baseURL: process.env.VUE_APP_API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const setToken = () => {
  if (!jwtService.getToken()) return;
  API.defaults.headers.common = {
    Authorization: `bearer ${jwtService.getToken()}`,
  };
};