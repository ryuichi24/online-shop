<template>
  <teleport to="#teleportCreateProduct">
    <modal-wrapper>
      <span class="close-btn" @click="toggleForm">&times;</span>
      <form @submit.prevent="" class="product-form">
        <div class="product-form__input-container">
          <label for="name">Name</label>
          <input name="name" type="text" />
        </div>
        <div class="product-form__input-container">
          <label for="price">Price</label>
          <input name="price" type="number" step="0.01" />
        </div>
        <div class="product-form__input-container">
          <label for="description">Description</label>
          <textarea name="description" cols="30" rows="10"></textarea>
        </div>
        <div class="product-form__input-container">
          <label for="inventory">Inventory</label>
          <input name="inventory" type="number" />
        </div>
        <div class="product-form__category-input-container">
          <label for="category-list">Category</label>
          <select name="category-list">
            <option
              v-for="(category, index) in categories"
              :key="index"
              value="category.categoryId"
              >{{ category.name }}</option
            >
          </select>
          <CategoryForm />
        </div>
        <button type="submit">Create</button>
      </form>
    </modal-wrapper>
  </teleport>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { GET_CATEGORIES } from '../../../../store/types/action.type';
// components
import ModalWrapper from '../../../common/modal/ModalWrapper.vue';
import CategoryForm from './category-form/CategoryForm.vue';

export default defineComponent({
  props: {
    toggleForm: Function,
  },
  components: {
    ModalWrapper,
    CategoryForm,
  },
  setup() {
    const { getters, dispatch } = useStore();

    const categories = computed(() => getters.categories);

    onMounted(() => {
      dispatch(GET_CATEGORIES);
    });

    return {
      categories,
    };
  },
});
</script>
