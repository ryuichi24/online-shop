<template>
  <button @click="isAddressFormOpen = !isAddressFormOpen">{{ addressFormBtnText }}</button>
  <AddressForm v-if="isAddressFormOpen" />
</template>

<script lang="ts">
import { defineComponent, ref, computed } from 'vue';
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
    const isAddressFormOpen = ref(false);

    const addressFormBtnText = computed(() =>
      isAddressFormOpen.value ? 'close' : 'Add a new address',
    );

    return {
      isAddressFormOpen,
      addressFormBtnText,
    };
  },
});
</script>
