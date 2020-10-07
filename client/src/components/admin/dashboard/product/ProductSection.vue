<template>
  <div class="product-section">
    <div class="product-section__heading-container">
      <h1>PRODUCTS</h1>
    </div>
    <div class="product-section__product-list-container">
      <div class="product-section__product" v-for="(product, index) in products" :key="index">
        {{ product.name }}
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, ref } from 'vue';

export default defineComponent({
  setup() {
    const products = ref([
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
      {
        name: 'product 1',
        price: '10',
      },
    ]);

    return {
      products,
    };
  },
});
</script>
