import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { CartItem, ServerError } from '@/types';

const addCartItem = async (cartItem: CartItem) => {
  try {
    const { data } = await ApiService.API.post('/cartitem', cartItem);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const removeCartItem = async (id: number) => {
  try {
    const { data, status, statusText } = await ApiService.API.delete(`/cartitem/${id}`);
    console.log('removeCartItem', status, statusText);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const updateCartItemCount = async (id: number, cartItemCount: number) => {
  try {
    const { data, status, statusText } = await ApiService.API.put(`/cartitem/${id}`, {
      cartItemCount,
    });
    console.log('updateCartItemCount', status, statusText);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const getAllCartItemsByUserId = async (id: number) => {
  try {
    const { data } = await ApiService.API.get(`/cartitems/all-by-user/${id}`);

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
  addCartItem,
  removeCartItem,
  updateCartItemCount,
  getAllCartItemsByUserId,
};
