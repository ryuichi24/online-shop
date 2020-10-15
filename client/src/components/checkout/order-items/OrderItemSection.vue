<template>
  <div class="order-item-section">
    <div class="order-item-section__orders-container">
      <h3>Your orders</h3>
      <div class="order-item-section__order" v-for="(item, index) in cartItems" :key="index">
        <div class="order-item-section__item-info order-item-section__item-name">
          <span>{{ item.product.name }}</span>
        </div>
        <div class="order-item-section__item-info order-item-section__item-price">
          <span>€ {{ item.product.price }}</span>
        </div>
        <div class="order-item-section__item-info order-item-section__item-qty">
          <span>Qty: {{ item.cartItemCount }}</span>
        </div>
      </div>
      <hr />
    </div>

    <div class="order-item-section__total-payment-container">
      <h3>Total payment</h3>
      <div class="order-item-section__total-payment">
        <span>€{{ totalAmount }}</span>
      </div>
    </div>
  </div>
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
