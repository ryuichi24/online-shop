<template>
  <div class="address-section">
    <div class="address-section__add-address-btn">
      <span @click="isAddressFormOpen = !isAddressFormOpen">{{ addressFormBtnText }}</span>
    </div>
    <AddressForm v-if="isAddressFormOpen" />
    <div class="address-section__address-selecting">
      <label>Select your delivery address</label>
      <select v-model="selectedAddressId" name="address" @change="selectedAddress">
        <option value="-1">--- Choose the delivery address ---</option>
        <option v-for="(address, index) in addresses" :value="address.addressId" :key="index">
          {{ address.address1 }} {{ address.address2 }}
        </option>
      </select>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_ADDRESSES_BY_USER_ID, SELECT_ADDRESS } from '../../../store/types/action.type';
// components
import AddressForm from '../../common/address/AddressForm.vue';

export default defineComponent({
  components: {
    AddressForm,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const isAddressFormOpen = ref(false);

    const addressFormBtnText = computed(() =>
      isAddressFormOpen.value ? 'close' : 'Add an address',
    );

    const userId = computed(() => getters.userId);

    const addresses = computed(() => getters.addresses);

    const selectedAddressId = ref();

    const selectedAddress = () => {
      dispatch(SELECT_ADDRESS, selectedAddressId.value);
    };

    onMounted(() => {
      dispatch(GET_ALL_ADDRESSES_BY_USER_ID, userId.value);
    });

    return {
      isAddressFormOpen,
      addressFormBtnText,
      addresses,
      selectedAddressId,
      selectedAddress,
    };
  },
});
</script>
