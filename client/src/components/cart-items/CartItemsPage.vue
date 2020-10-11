<template>
  <div v-if="cartItems" class="container" style="margin-bottom: 10rem;">
    <CartItem v-for="(item, index) in cartItems" :key="index" :cartItem="item" />
  </div>
</template>

<script>
import { defineComponent, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_ALL_CART_ITEMS_BY_USER_ID } from '../../store/types/action.type';
// components
import CartItem from './CartItem.vue';

export default defineComponent({
  components: {
    CartItem,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const userId = computed(() => getters.userId);
    const cartItems = computed(() => getters.cartItems);

    onMounted(() => {
      dispatch(GET_ALL_CART_ITEMS_BY_USER_ID, userId.value);
    });

    return {
      cartItems,
    };
  },
});
</script>
