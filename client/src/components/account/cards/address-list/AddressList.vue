<template>
  <div class="address-list">
    <h3>Address list</h3>
    <div class="address-list__address-wrapper">
      <AddressWrapper v-for="(address, index) in addresses" :address="address" :key="index" />
    </div>
  </div>
</template>

<script>
import { defineComponent, onMounted, computed } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_ADDRESSES_BY_USER_ID } from '../../../../store/types/action.type';
// components
import AddressWrapper from './AddressWrapper.vue';

export default defineComponent({
  components: {
    AddressWrapper,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const addresses = computed(() => getters.addresses);
    const userId = computed(() => getters.userId);

    onMounted(() => {
      dispatch(GET_ALL_ADDRESSES_BY_USER_ID, userId.value);
    });

    return {
      addresses,
    };
  },
});
</script>
