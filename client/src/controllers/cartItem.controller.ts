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
    const { status } = await ApiService.API.delete(`/cartitem/${id}`);
    if (status !== 204) return null;

    return true;
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
    const { status } = await ApiService.API.put(`/cartitem/${id}`, {
      cartItemCount,
    });
    if (status !== 204) return null;

    return true;
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
    const { data } = await ApiService.API.get(`/cartitem/all-by-user/${id}`);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const clearCartItems = async (userId: number) => {
  try {
    const { status } = await ApiService.API.delete(`/cartitem/clear-cart-items/${userId}`);
    if (status !== 204) return false;

    return true;
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
  clearCartItems,
};
