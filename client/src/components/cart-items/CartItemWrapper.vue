<template>
  <div v-if="cartItem.product" class="cart-item">
    <div
      class="cart-item__image"
      :style="`background-image: url(${cartItem.product.image});`"
    ></div>
    <div class="cart-item__details">
      <div class="cart-item__name"><span>{{ cartItem.product.name }}</span></div>
      <div class="cart-item__price"><span>€ {{ cartItem.product.price }}</span></div>
      <form @submit.prevent>
        <div>
          <label class="cart-item__quantity" for="itemCount">Quantity</label>
          <input @change="updateItemCount" v-model.number="itemCount" type="number" step="1" />
        </div>
      </form>
      <span class="cart-item__delete-btn" @click="deleteItem(cartItem.cartItemId)">Delete</span>
    </div>
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
    const itemCount = ref(cartItem!.cartItemCount!);

    const updateItemCount = () => {
      dispatch(UPDATE_CART_ITEM_COUNT, {
        cartItemId: cartItem!.cartItemId,
        cartItemCount: itemCount.value,
      });
    };

    const deleteItem = (cartItemId: number) => {
      dispatch(REMOVE_CART_ITEM, cartItemId);
    };

    return {
      itemCount,
      updateItemCount,
      deleteItem,
    };
  },
});
</script>
