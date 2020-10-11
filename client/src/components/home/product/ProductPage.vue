<template>
  <div class="container">
    <div v-if="product" class="product-page">
      <div class="product-page__section">
        <div>
          <img src="https://source.unsplash.com/random" alt="product image">
        </div>
      </div>
      <div class="product-page__section">
        <h2>{{ product.name }}</h2>
        <hr>
        <p>€{{ product.price }}</p>
        <p>{{ product.description }}</p>
        <p v-if="product.inventory > 0">In stock</p>
        <p v-else>Out of stock</p>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCT_BY_ID } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { params } = useRoute();
    const { dispatch, getters } = useStore();

    const product = computed(() => getters.product);

    onMounted(() => {
      dispatch(GET_PRODUCT_BY_ID, params.id);
    });

    return {
      product,
    };
  },
});
</script>
