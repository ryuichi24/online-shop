<template>
  <div class="order-section">
    <div class="order-section__heading">
      <h1>Orders</h1>
    </div>
    <div class="order-section__orders">
      <OrderWrapper v-for="(order, index) in orders" :key="index" :order="order" />
    </div>
  </div>
</template>

<script>
import { defineComponent, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_ORDERS } from '../../../../store/types/action.type';
// component
import OrderWrapper from '../../../common/order/OrderWrapper.vue';

export default defineComponent({
  components: {
    OrderWrapper,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const orders = computed(() => getters.orders);

    onMounted(() => {
      dispatch(GET_ALL_ORDERS);
    });

    return {
      orders,
    };
  },
});
</script>
