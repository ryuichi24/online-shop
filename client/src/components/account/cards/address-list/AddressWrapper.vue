<template>
  <div class="address-wrapper">
    <div class="address-wrapper__address">
      <div class="address-wrapper__post-code">
        <span> Post Code: {{ address.postCode }} </span>
      </div>
      <div class="address-wrapper__address-text">
        <span> {{ address.address1 }}, {{ address.address2 }}, {{ address.city }} </span>
      </div>
    </div>
    <div class="address-wrapper__trash-icon">
      <TrashIcon @click="removeAddress(address.addressId)" :width="30" :height="35" :fill="'#B6B6B6'" />
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, PropType } from 'vue';
// vuex
import { useStore } from 'vuex';
import { REMOVE_ADDRESS } from '../../../../store/types/action.type';
// icons
import { TrashIcon } from '../../../common/icons';
// types
import { Address } from '../../../../types';

export default defineComponent({
  components: {
    TrashIcon,
  },
  props: {
    address: Object as PropType<Address>,
  },
  setup({ address }) {
    const { dispatch } = useStore();

    const removeAddress = (addressId: number) => {
      dispatch(REMOVE_ADDRESS, addressId).then(() => {
        alert('The address has been deleted');
      });
    };

    return {
      removeAddress,
    };
  },
});
</script>

<style></style>
