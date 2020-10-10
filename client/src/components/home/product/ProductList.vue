<template>
  <div class="product-list">
    <TheProduct :product="product" v-for="(product, index) in productList" :key="index" />
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, computed } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCTS } from '../../../store/types/action.type';
// components
import TheProduct from './TheProduct.vue';

export default defineComponent({
  components: {
    TheProduct,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const productList = computed(() => getters.products);

    onMounted(() => {
      dispatch(GET_PRODUCTS);
    });

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
