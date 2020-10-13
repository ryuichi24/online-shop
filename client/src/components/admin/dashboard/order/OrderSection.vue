<template>
  <div class="order-section">
    <OrderWrapper v-for="(order, index) in orders" :key="index" :order="order" />
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
