<template>
  <div class="product-list" >
    <TheProduct :product="product" v-for="(product, index) in productList" :key="index" />
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
// components
import TheProduct from './TheProduct.vue';

export default defineComponent({
  components: {
    TheProduct,
  },
  setup() {
    const productList = ref([
      {
        productId: 1,
        name: 'product 1',
        price: 12.8,
        description: 'This is a product 1',
        inventory: 20,
        categoryId: 1,
      },
      {
        productId: 1,
        name: 'product 1',
        price: 12.8,
        description: 'This is a product 1',
        inventory: 20,
        categoryId: 1,
      },
      {
        productId: 1,
        name: 'product 1',
        price: 12.8,
        description: 'This is a product 1',
        inventory: 20,
        categoryId: 1,
      },
      {
        productId: 1,
        name: 'product 1',
        price: 12.8,
        description: 'This is a product 1',
        inventory: 20,
        categoryId: 1,
      },
      {
        productId: 1,
        name: 'product 1',
        price: 12.8,
        description: 'This is a product 1',
        inventory: 20,
        categoryId: 1,
      },
      {
        productId: 1,
        name: 'product 1',
        price: 12.8,
        description: 'This is a product 1',
        inventory: 20,
        categoryId: 1,
      },
    ]);

    return {
      productList,
    };
  },
});
</script>

<style scoped>
.product-list {
  display: grid;

  grid-template-columns: repeat(3, 1fr);
  grid-gap: 3rem;
  grid-auto-rows: minmax(200px, auto);

  margin-top: 5rem;
}
</style>
