<template>
  <div class="product-section">
    <div class="product-section__heading-container">
      <h1>PRODUCTS</h1>
    </div>
    <div class="product-section__product-list-container">
      <div class="product-section__product" v-for="(product, index) in products" :key="index">
        <div class="product-section__edit-btn">
          <span @click="isEditting = !isEditting">{{ editBtnText }}</span>
        </div>
        <ProductEditForm :product="product" v-if="isEditting" />
        <div v-if="!isEditting">
          <div>
            <h3><span>Product Id</span></h3>
            <div>
              <span>{{ product.productId }}</span>
            </div>
          </div>
          <div>
            <h3><span>Product name</span></h3>
            <div>
              <span>{{ product.name }}</span>
            </div>
          </div>
          <div>
            <h3><span>Product price</span></h3>
            <div>
              <span>€ {{ product.price }}</span>
            </div>
          </div>
          <div>
            <h3><span>Product description</span></h3>
            <div>
              <span>{{ product.description }}</span>
            </div>
          </div>
          <div>
            <h3><span>Product inventory</span></h3>
            <div>
              <span>{{ product.inventory }}</span>
            </div>
          </div>
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
// components
import ProductEditForm from './ProductEditForm.vue';

export default defineComponent({
  components: {
    ProductEditForm,
  },
  setup() {
    const { dispatch, getters } = useStore();

    const products = computed(() => getters.products);

    const isEditting = ref(false);

    const editBtnText = computed(() => (isEditting.value ? 'Close' : 'Edit'));

    onMounted(() => {
      dispatch(GET_PRODUCTS);
    });

    return {
      products,
      isEditting,
      editBtnText,
    };
  },
});
</script>
