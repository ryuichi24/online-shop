<template>
  <div v-if="cartItem.product" class="cart-item">
    <h2>{{ cartItem.product.name }}</h2>
    <p>{{ cartItem.cartItemCount }}</p>
    <form @submit.prevent>
      <div>
        <label for="itemCount">Quantity</label>
        <input @change="updateItemCount" v-model.number="itemCount" type="number" step="1" />
      </div>
    </form>
    <button @click="deleteItem">Delete</button>
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
      dispatch(UPDATE_CART_ITEM_COUNT, {
        cartItemId: cartItem.cartItemId,
        cartItemCount: itemCount.value,
      });
    };

    const deleteItem = () => {
      dispatch(REMOVE_CART_ITEM, cartItem.cartItemId);
    };

    return {
      itemCount,
      updateItemCount,
      deleteItem,
    };
  },
});
</script>
