<template>
  <div class="cart-item">
    <h2>{{ cartItem.product.name }}</h2>
    <p>{{ cartItem.cartItemCount }}</p>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  props: {
    cartItem: Object,
  },
});
</script>
