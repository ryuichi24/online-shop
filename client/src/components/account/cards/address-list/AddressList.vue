<template>
  <div class="address-list">
    <div class="address-list__plus-icon">
      <PlusIcon v-if="!isAddingAddress"  @click="isAddingAddress = !isAddingAddress" :width="30" :height="35" :fill="'#B6B6B6'" />
      <XIcon v-if="isAddingAddress"  @click="isAddingAddress = !isAddingAddress" :width="30" :height="35" :fill="'#B6B6B6'" />
    </div>
    <AddressForm v-if="isAddingAddress" />
    <h3>Address list</h3>
    <div class="address-list__address-wrapper">
      <AddressWrapper v-for="(address, index) in addresses" :address="address" :key="index" />
    </div>
  </div>
</template>

<script>
import { defineComponent, onMounted, computed, ref } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_ADDRESSES_BY_USER_ID } from '../../../../store/types/action.type';
// components
import AddressWrapper from './AddressWrapper.vue';
import { PlusIcon, XIcon } from '../../../common/icons';
import AddressForm from '../../../common/address/AddressForm.vue';

export default defineComponent({
  components: {
    AddressWrapper,
    PlusIcon,
    AddressForm,
    XIcon,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const addresses = computed(() => getters.addresses);
    const userId = computed(() => getters.userId);

    const isAddingAddress = ref(false);

    onMounted(() => {
      dispatch(GET_ALL_ADDRESSES_BY_USER_ID, userId.value);
    });

    return {
      addresses,
      isAddingAddress,
    };
  },
});
</script>
