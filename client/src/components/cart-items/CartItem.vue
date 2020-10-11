<template>
  <div class="cart-item">
    <h2>{{ cartItem.product.name }}</h2>
    <p>{{ cartItem.cartItemCount }}</p>
    <form>
      <div>
        <label for="itemCount">Quantity</label>
        <input @change="updateItemCount" v-model.number="itemCount" type="number" step="1" />
      </div>
    </form>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, PropType } from 'vue';
// vuex
import { useStore } from 'vuex';
import { REMOVE_CART_ITEM, UPDATE_CART_ITEM_COUNT } from '../../store/types/action.type';
// type
import { CartItem } from '../../types';

export default defineComponent({
  props: {
    cartItem: Object as PropType<CartItem>,
  },
  setup({ cartItem }) {
    const { dispatch } = useStore();
    const itemCount = ref(cartItem.cartItemCount);

    const updateItemCount = () => {
        console.log(cartItem.cartItemId);
      dispatch(UPDATE_CART_ITEM_COUNT, {
        cartItemId: cartItem.cartItemId,
        cartItemCount: itemCount.value,
      });
    };

    return {
      itemCount,
      updateItemCount,
    };
  },
});
</script>
