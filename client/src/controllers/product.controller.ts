import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { Product, ServerError } from '@/types';

const addProduct = async (product: Product) => {
  try {
    const { data } = await ApiService.API.post<Product>('/product', product);

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
  addProduct,
};
