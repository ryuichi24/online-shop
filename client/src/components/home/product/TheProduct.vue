<template>
  <div class="product">
      <div>{{ product.name }}</div>
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
