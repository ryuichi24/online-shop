<template>
  <teleport to="#teleportTarget">
    <modal-wrapper>
      <span class="close-btn" @click="toggle">&times;</span>
      <form @submit.prevent class="product-form">
        <div class="product-form__input-container">
          <label for="name">Name</label>
          <input v-model="name" name="name" type="text" />
        </div>
        <div class="product-form__input-container">
          <label for="price">Price</label>
          <input v-model="price" name="price" type="number" step="0.01" />
        </div>
        <div class="product-form__input-container">
          <label for="description">Description</label>
          <textarea
            v-model="description"
            name="description"
            cols="30"
            rows="10"
          ></textarea>
        </div>
        <div class="product-form__input-container">
          <label for="image">Image (URL)</label>
          <input v-model="image" name="image" type="text" />
        </div>
        <div class="product-form__input-container">
          <label for="inventory">Inventory</label>
          <input v-model="inventory" name="inventory" type="number" />
        </div>
        <div class="product-form__category-input-container">
          <label for="category-list">Category</label>
          <select v-model="categoryId" name="category-list">
            <option value="null">-- Choose a category --</option>
            <option
              v-for="(category, index) in categories"
              :key="index"
              :value="category.categoryId"
              >{{ category.name }}</option
            >
          </select>
          <CategoryForm />
        </div>
        <button @click="submitHandle" type="submit">Create</button>
      </form>
    </modal-wrapper>
  </teleport>
</template>

<script lang="ts">
import { defineComponent, computed, onMounted, reactive, toRefs } from 'vue';
// vuex
import { useStore } from 'vuex';
import {
  GET_CATEGORIES,
  ADD_PRODUCT,
} from '../../../../../store/types/action.type';
// components
import ModalWrapper from '../../../../common/modal/ModalWrapper.vue';
import CategoryForm from '../category-form/CategoryForm.vue';

export default defineComponent({
  props: {
    toggle: Function,
  },
  components: {
    ModalWrapper,
    CategoryForm,
  },
  setup() {
    const { getters, dispatch } = useStore();

    const productInputs = reactive({
          name: '',
          price: '',
          description: '',
          image: '',
          inventory: '',
          categoryId: '',
        });

    const submitHandle = () => {
      const parsed = {
        name: productInputs.name,
        price: parseInt(productInputs.price, 10),
        description: productInputs.description,
        image: productInputs.image,
        inventory: parseInt(productInputs.inventory, 10),
        categoryId: parseInt(productInputs.categoryId, 10),
      };

      dispatch(ADD_PRODUCT, parsed);
    };

    const categories = computed(() => getters.categories);

    onMounted(() => {
      dispatch(GET_CATEGORIES);
    });

    return {
      categories,
      ...toRefs(productInputs),
      submitHandle,
    };
  },
});
</script>
