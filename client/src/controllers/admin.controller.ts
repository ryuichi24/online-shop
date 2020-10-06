import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { Admin, ServerError } from '@/types';

const loginAdmin = async (adminCredentials: { email: string; password: string }) => {
  try {
    const { data } = await ApiService.API.post<{ token: string; admin: Admin }>(
      '/admin/login',
      adminCredentials,
    );
    const token = data;
    return token;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

export default {
  loginAdmin,
};
