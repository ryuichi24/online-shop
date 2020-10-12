<template>
  <div class="product">
    <router-link :to="`/product/${product.productId}`">
      <div class="product__container" :style="`background-image: url(${product.image})`">
        <div class="product__text-wrapper">
          <span>€ {{ product.price }}</span>
        </div>
        <div class="product__text-wrapper">
          <span>{{ product.name }}</span>
        </div>
      </div>
    </router-link>
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
