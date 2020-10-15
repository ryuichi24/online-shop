<template>
  <div class="order-history">
    <h3>Order history</h3>
    <div class="order-history__order-wrapper">
      <OrderWrapper v-for="(order, index) in orders" :key="index" :order="order" />
    </div>
  </div>
</template>

<script>
import { defineComponent, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_ORDERS_BY_USER_ID } from '../../../../store/types/action.type';
// component
import OrderWrapper from '../../../common/order/OrderWrapper.vue';

export default defineComponent({
  components: {
    OrderWrapper,
  },
  setup() {
    const { getters, dispatch } = useStore();

    const orders = computed(() => getters.orders);
    const userId = computed(() => getters.userId);

    onMounted(() => {
      dispatch(GET_ALL_ORDERS_BY_USER_ID, userId.value);
    });

    return {
      orders,
    };
  },
});
</script>
