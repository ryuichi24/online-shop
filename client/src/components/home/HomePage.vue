<template>
  <div class="container" style="margin-bottom: 10rem;">
    <ProductList />
  </div>
</template>

<script>
import { defineComponent } from 'vue';
// components
import ProductList from './product/ProductList.vue';

export default defineComponent({
  components: {
    ProductList,
  },
});
</script>
