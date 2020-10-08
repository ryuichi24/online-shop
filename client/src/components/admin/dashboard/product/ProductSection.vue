<template>
  <div class="product-section">
    <div class="product-section__heading-container">
      <h1>PRODUCTS</h1>
    </div>
    <div class="product-section__product-list-container">
      <div class="product-section__product" v-for="(product, index) in products" :key="index">
        <ProductForm v-if="isModalOpen" :productId="product.productId" :toggleForm="toggle" :key="index" />
        <button @click="toggle">Edit</button>
        <div>{{ product.name }}</div>
        <div>{{ product.price }}</div>
        <div>{{ product.description }}</div>
        <div>{{ product.inventory }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, ref, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCTS } from '../../../../store/types/action.type';
// components
import ProductForm from '../product-form/ProductForm.vue';

export default defineComponent({
  components: {
    ProductForm,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const products = computed(() => getters.products);

    const isModalOpen = ref(false);

    const toggle = () => {
      isModalOpen.value = !isModalOpen.value;
    };

    onMounted(() => {
      dispatch(GET_PRODUCTS);
    });

    return {
      products,
      isModalOpen,
      toggle,
    };
  },
});
</script>
