<template>
  <div class="product-section">
    <div class="product-section__heading-container">
      <h1>PRODUCTS</h1>
    </div>
    <div class="product-section__product-list-container">
      <div class="product-section__product" v-for="(product, index) in products" :key="index">
        <div>{{ product.productId }}</div>
        <div>{{ product.name }}</div>
        <div>{{ product.price }}</div>
        <div>{{ product.description }}</div>
        <div>{{ product.inventory }}</div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted, ref } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCTS } from '../../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch, getters } = useStore();

    const products = computed(() => getters.products);

    const whichProductId = ref();
    const toggle = (productId: number) => {
      whichProductId.value = productId;
    };

    onMounted(() => {
      dispatch(GET_PRODUCTS);
    });

    return {
      products,
      whichProductId,
      toggle,
    };
  },
});
</script>
