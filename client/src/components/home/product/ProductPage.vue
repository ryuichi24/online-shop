<template>
  <div class="container">
    <div v-if="product" class="product-page">
      <div class="product-page__section">
        <div class="product-page__image-wrapper">
          <img class="product-page__image" :src="product.image" alt="product image" />
        </div>
      </div>
      <div class="product-page__section">
        <div class="product-page__text">
          <h2>{{ product.name }}</h2>
          <hr />
          <p>{{ product.description }}</p>
        </div>
        <div class="product-page__actions">
          <div class="product-page__price">
            <span>€ {{ product.price }}</span>
          </div>
          <div class="product-page__stock" v-if="product.inventory > 0">
            <span>In stock</span>
          </div>
          <div class="product-page__stock" v-else>
            <span>Out of stock</span>
          </div>
          <form class="product-page__item-count-form" @submit.prevent>
            <div class="product-page__input-wrapper">
              <label for="cartItemCount">Item Count</label>
              <input v-model.number="cartItemCount" name="cartItemCount" type="number" />
            </div>
            <span class="product-page__btn" @click="addCartItem">Add to Cart</span>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, onMounted, computed, ref } from 'vue';
import { useRoute, useRouter } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import {
  GET_PRODUCT_BY_ID,
  ADD_CART_ITEM,
  GET_ALL_CART_ITEMS_BY_USER_ID,
  CHECK_IS_IN_CART,
} from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { params } = useRoute();
    const { push } = useRouter();
    const { dispatch, getters } = useStore();

    const product = computed(() => getters.product);
    const userId = computed(() => getters.userId);
    const isInCart = computed(() => getters.isInCart);
    const isAuthenticated = computed(() => getters.isAuthenticated);

    const cartItemCount = ref(1);

    const addCartItem = () => {
      if (isAuthenticated.value) {
        dispatch(ADD_CART_ITEM, {
          userId: userId.value,
          productId: product.value.productId,
          cartItemCount: cartItemCount.value,
        }).then(() => {
          alert('The Item has been added to the cart');
        });
      } else {
        alert('Please login');
        push({ name: 'LoginForm' });
      }
    };

    onMounted(() => {
      dispatch(GET_PRODUCT_BY_ID, params.id)
        .then(() => dispatch(GET_ALL_CART_ITEMS_BY_USER_ID, userId.value))
        .then(() => dispatch(CHECK_IS_IN_CART, parseInt(params.id, 10)));
    });

    return {
      product,
      addCartItem,
      cartItemCount,
      isInCart,
    };
  },
});
</script>
