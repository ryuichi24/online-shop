import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { Order, ServerError } from '@/types';

const addOrder = async (newOrder: Order) => {
  try {
    ApiService.setToken();

    const { data } = await ApiService.API.post('/order', newOrder);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const getAllOrders = async () => {
  try {
    ApiService.setAdminToken();
    const { data } = await ApiService.API.get('/order');

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const getAllOrdersByUserId = async (id: number) => {
  try {
    ApiService.setToken();

    const { data } = await ApiService.API.get(`/order/all-by-user/${id}`);

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
  addOrder,
  getAllOrdersByUserId,
  getAllOrders,
};
