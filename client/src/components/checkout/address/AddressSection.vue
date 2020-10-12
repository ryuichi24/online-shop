<template>
  <button @click="isAddressFormOpen = !isAddressFormOpen">{{ addressFormBtnText }}</button>
  <AddressForm v-if="isAddressFormOpen" />
  <h2>Select your delivery address</h2>
  <select name="address">
    <option value="-1">--- Choose the delivery address ---</option>
    <option v-for="(address, index) in addresses" :value="address.addressId" :key="index">
      {{ address.address1 }} {{ address.address2 }}
    </option>
  </select>
</template>

<script lang="ts">
import { defineComponent, ref, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_ADDRESSES_BY_USER_ID } from '../../../store/types/action.type';
// type
import { Address } from '../../../types';
// components
import AddressForm from './AddressForm.vue';

export default defineComponent({
  components: {
    AddressForm,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const isAddressFormOpen = ref(false);

    const addressFormBtnText = computed(() =>
      isAddressFormOpen.value ? 'close' : 'Add a new address',
    );

    const userId = computed(() => getters.userId);

    const addresses = computed(() => getters.addresses);

    onMounted(() => {
      dispatch(GET_ALL_ADDRESSES_BY_USER_ID, userId.value);
    });

    return {
      isAddressFormOpen,
      addressFormBtnText,
      addresses,
    };
  },
});
</script>
