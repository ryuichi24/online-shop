<template>
  <div class="product-section">
    <div class="product-section__heading-container">
      <h1>PRODUCTS</h1>
    </div>
    <div class="product-section__product-list-container">
      <div class="product-section__product" v-for="(product, index) in products" :key="index">
        <div>
          <h3><span>Product Id</span></h3>
          <div><span>{{ product.productId }}</span></div>
        </div>
        <div>
          <h3><span>Product name</span></h3>
          <div><span>{{ product.name }}</span></div>
        </div>
        <div>
          <h3><span>Product price</span></h3>
          <div><span>€ {{ product.price }}</span></div>
        </div>
        <div>
          <h3><span>Product description</span></h3>
          <div><span>{{ product.description }}</span></div>
        </div>
        <div>
          <h3><span>Product inventory</span></h3>
          <div><span>{{ product.inventory }}</span></div>
        </div>
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
