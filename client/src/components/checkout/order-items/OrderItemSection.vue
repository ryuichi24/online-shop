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
import { GET_ALL_CART_ITEMS_BY_USER_ID } from '../../../store/types/action.type';
// type
import { CartItem } from '../../../types';

export default defineComponent({
  setup() {
    const { dispatch, getters } = useStore();

    const userId = computed(() => getters.userId);
    const cartItems = computed<CartItem[]>(() => getters.cartItems);
    const totalAmount = computed(() => {
      if (!cartItems.value.length) return 0;

      return cartItems.value
        .map((c: CartItem) => {
          if (!c.product?.price) return 0;
          return c.product!.price * c.cartItemCount;
        })
        .reduce((accum: number, current: number) => accum + current);
    });

    onMounted(() => {
      dispatch(GET_ALL_CART_ITEMS_BY_USER_ID, userId.value);
    });

    return {
      cartItems,
      totalAmount,
    };
  },
});
</script>
