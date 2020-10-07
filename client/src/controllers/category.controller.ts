import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { Category, ServerError } from '@/types';

const getCategories = async () => {
  try {
    const { data } = await ApiService.API.get<Category[]>('/category');

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const addCategory = async (name: string) => {
  try {
    const { data } = await ApiService.API.post<Category>('/category', { name });
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
  getCategories,
  addCategory,
};
