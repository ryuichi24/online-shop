<template>
  <div class="container">
    <div v-if="product" class="product-page">
      <div class="product-page__section">
        <div>
          <img src="https://source.unsplash.com/random" alt="product image" />
        </div>
      </div>
      <div class="product-page__section">
        <h2>{{ product.name }}</h2>
        <hr />
        <p>€{{ product.price }}</p>
        <p>{{ product.description }}</p>
        <p v-if="product.inventory > 0">In stock</p>
        <p v-else>Out of stock</p>
        <form @submit.prevent>
          <div>
            <label for="cartItemCount">Item Count</label>
            <input v-model.number="cartItemCount" name="cartItemCount" type="number" />
          </div>
          <button @click="addCartItem">Add to Cart</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, onMounted, computed, ref } from 'vue';
import { useRoute } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCT_BY_ID, ADD_CART_ITEM } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { params } = useRoute();
    const { dispatch, getters } = useStore();

    const product = computed(() => getters.product);
    const userId = computed(() => getters.userId);

    const cartItemCount = ref(0);

    const addCartItem = () => {
      dispatch(ADD_CART_ITEM, {
        userId: userId.value,
        productId: product.value.productId,
        cartItemCount: cartItemCount.value,
      });
    };

    onMounted(() => {
      dispatch(GET_PRODUCT_BY_ID, params.id);
    });

    return {
      product,
      addCartItem,
      cartItemCount,
    };
  },
});
</script>
