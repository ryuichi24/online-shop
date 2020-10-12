import { Commit } from 'vuex';
// controller
import { AddressController } from '@/controllers';
// types
import { Address } from '@/types';
// mutation types
import {
  ADD_ADDRESS,
  REMOVE_ADDRESS,
  UPDATE_ADDRESS,
  SET_ADDRESSES,
  SET_SELECTED_ADDRESS_ID,
} from '../types/mutation.type';

interface AddressState {
  address: Address | null;
  addresses: Address[] | null;
  selectedAddressId: number | null;
}

const state: AddressState = {
  address: null,
  addresses: [],
  selectedAddressId: null,
};

const getters = {
  address: (state: AddressState) => state.address,
  addresses: (state: AddressState) => state.addresses,
  selectedAddressId: (state: AddressState) => state.selectedAddressId,
};

const actions = {
  async addAddress({ commit }: { commit: Commit }, newAddress: Address) {
    try {
      const addedAddress = await AddressController.addAddress(newAddress);
      // TODO: make error message
      if (!addedAddress) return;

      commit(ADD_ADDRESS, newAddress);
    } catch (err) {
      console.log(err.message);
    }
  },
  async removeAddress({ commit }: { commit: Commit }, addressId: number) {
    try {
      const res = await AddressController.removeAddress(addressId);
      // TODO: make error message
      if (!res) return;

      commit(REMOVE_ADDRESS, addressId);
    } catch (err) {
      console.log(err.message);
    }
  },
  async updatedAddress(
    { commit }: { commit: Commit },
    { addressId, newAddress }: { addressId: number; newAddress: Address },
  ) {
    try {
      const res = await AddressController.updatedAddress(addressId, newAddress);
      // TODO: make error message
      if (!res) return;

      commit(UPDATE_ADDRESS, { addressId, newAddress });
    } catch (err) {
      console.log(err.message);
    }
  },
  async getAllAddressesByUserId({ commit }: { commit: Commit }, userId: number) {
    try {
      const addresses = await AddressController.getAllAddressesByUserId(userId);
      // TODO: make error message
      if (!addresses) return;

      commit(SET_ADDRESSES, addresses);
    } catch (err) {
      console.log(err.message);
    }
  },
  selectAddress({ commit }: { commit: Commit }, addressId: number) {
    commit(SET_SELECTED_ADDRESS_ID, addressId);
  },
};

const mutations = {
  ADD_ADDRESS: (state: AddressState, newAddress: Address) => {
    state.addresses?.push(newAddress);
  },
  REMOVE_ADDRESS: (state: AddressState, addressId: number) => {
    const indexToRemove = state.addresses?.findIndex((a: Address) => a.addressId === addressId);
    state.addresses?.splice(indexToRemove!, 1);
  },
  UPDATE_ADDRESS: (
    state: AddressState,
    { addressId, newAddress }: { addressId: number; newAddress: Address },
  ) => {
    const indexToUpdate = state.addresses?.findIndex((a: Address) => a.addressId === addressId);
    if (state && state.addresses && indexToUpdate) state.addresses[indexToUpdate] = newAddress;
  },
  SET_ADDRESSES: (state: AddressState, addresses: Address[]) => {
    state.addresses = addresses;
  },
  SET_SELECTED_ADDRESS_ID: (state: AddressState, addressId: number) => {
    state.selectedAddressId = addressId;
  },
};

export default {
  state,
  actions,
  mutations,
  getters,
};
