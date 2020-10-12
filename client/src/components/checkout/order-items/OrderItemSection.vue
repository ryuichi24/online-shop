<template>
  <h2>Your orders</h2>
  <div v-for="(item, index) in cartItems" :key="index">
    <span>{{ item.product.name }}</span>
  </div>
  <h3>Total payment</h3>
  <div>€{{ totalAmount }}</div>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_CART_ITEMS_BY_USER_ID, CALCULATE_PAYMENT } from '../../../store/types/action.type';
// type
import { CartItem } from '../../../types';

export default defineComponent({
  setup() {
    const { dispatch, getters } = useStore();

    const userId = computed(() => getters.userId);
    const cartItems = computed<CartItem[]>(() => getters.cartItems);
    const totalAmount = computed(() => getters.totalPayment);

    onMounted(() => {
      dispatch(GET_ALL_CART_ITEMS_BY_USER_ID, userId.value).then(() => {
        dispatch(CALCULATE_PAYMENT);
      });
    });

    return {
      cartItems,
      totalAmount,
    };
  },
});
</script>
