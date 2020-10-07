<template>
  <ProductForm v-if="isModalOpen" :toggleForm="toggleForm" />
  <button @click="toggleForm">Add Product</button>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
// components
import ProductForm from './ProductForm.vue';

export default defineComponent({
  components: {
    ProductForm,
  },
  setup() {
    const isModalOpen = ref(false);

    const toggleForm = () => {
      isModalOpen.value = !isModalOpen.value;
    };

    return {
      isModalOpen,
      toggleForm,
    };
  },
});
</script>
