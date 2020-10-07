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
import { defineComponent, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCTS } from '../../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch, getters } = useStore();

    const products = computed(() => getters.products);

    onMounted(() => {
      dispatch(GET_PRODUCTS);
    });

    return {
      products,
    };
  },
});
</script>
