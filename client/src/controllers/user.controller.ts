import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { User, ServerError } from '@/types';

const createUser = async (user: User) => {
  try {
    const { data } = await ApiService.API.post<{ user: User; token: string }>('/user', user);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const loginUser = async (userCredentials: { email: string; password: string }) => {
  try {
    const { data } = await ApiService.API.post<{ user: User; token: string }>(
      '/user/login',
      userCredentials,
    );

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const checkUserAuth = async () => {
  try {
    ApiService.setToken();

    const { data } = await ApiService.API.get<User>('/user/check-auth');

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

export default {
  createUser,
  checkUserAuth,
  loginUser,
};
