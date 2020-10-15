<template>
  <div class="container" style="margin-bottom: 10rem;">
    <div class="checkout-page">
      <div class="checkout-page__card">
        <AddressSection />
      </div>
      <div class="checkout-page__card">
        <OrderItemSection />
        <div class="checkout-page__order-btn">
          <span @click="sendOrder">Send order</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
// vuex
import { useStore } from 'vuex';
import { ADD_ORDER } from '../../store/types/action.type';
// components
import AddressSection from './address/AddressSection.vue';
import OrderItemSection from './order-items/OrderItemSection.vue';
// type
import { CartItem } from '../../types';

export default defineComponent({
  components: {
    AddressSection,
    OrderItemSection,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const selectedAddressId = computed(() => getters.selectedAddressId);
    const totalPayment = computed(() => getters.totalPayment);
    const userId = computed(() => getters.userId);
    const cartItems = computed<CartItem[]>(() => getters.cartItems);

    const sendOrder = () => {
      const orderItems = cartItems.value.map((c: CartItem) => ({
        productId: c.productId,
        orderItemCount: c.cartItemCount,
      }));

      const order = {
        userId: userId.value,
        addressId: selectedAddressId.value,
        totalPayment: totalPayment.value,
        orderItems,
      };

      dispatch(ADD_ORDER, order);
    };

    return {
      sendOrder,
    };
  },
});
</script>
