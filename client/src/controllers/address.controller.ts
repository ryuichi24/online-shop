import { AxiosError } from 'axios';
// services
import ApiService from '@/services/api.service';
// types
import { Address, ServerError } from '@/types';

const addAddress = async (address: Address) => {
  try {
    const { data } = await ApiService.API.post<Address>('/address', address);

    return data;
  } catch (err) {
    if (err && err.response) {
      const axiosError = err as AxiosError<ServerError>;
      if (axiosError.response) return axiosError.response.data;
    }
    throw err;
  }
};

const removeAddress = async (id: number) => {
  try {
    const { status } = await ApiService.API.delete(`/address/${id}`);
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

const updatedAddress = async (id: number, newAddress: Address) => {
  try {
    const { status } = await ApiService.API.put(`/address/${id}`, newAddress);
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

const getAllAddressesByUserId = async (id: number) => {
  try {
    const { data } = await ApiService.API.get<Address[]>(`/address/all-by-user/${id}`);

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
  addAddress,
  removeAddress,
  updatedAddress,
  getAllAddressesByUserId,
};
