<template>
  <div class="product">
    <router-link :to="`/product/${product.productId}`">
      <span>{{ product.name }}</span>
    </router-link>
    <div>{{ product.price }}</div>
  </div>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  props: {
    product: Object,
  },
});
</script>
