<template>
  <form class="product-edit-form" @submi.prevent>
    <div>
      <label for="name">name</label>
      <input v-model="name" type="text" />
    </div>
    <div>
      <label for="price">price</label>
      <input v-model="price" type="text" />
    </div>
    <div>
      <label for="description">description</label>
      <textarea v-model="description" name="description" cols="30" rows="10"></textarea>
    </div>
    <div>
      <label for="image">image</label>
      <input v-model="image" type="text" />
    </div>
    <div>
      <label for="inventory">inventory</label>
      <input v-model="inventory" type="text" />
    </div>
    <div class="product-edit-form__update-btn">
      <span @click="updateProduct">Update</span>
    </div>
  </form>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs, PropType } from 'vue';
import { useStore } from 'vuex';
import { UPDATE_PRODUCT } from '../../../../store/types/action.type';
import { Product } from '../../../../types';

export default defineComponent({
  props: {
    product: Object as PropType<Product>,
  },
  setup({ product }) {
    const { dispatch } = useStore();

    const productInputs = reactive(product!);

    const updateProduct = () => {
      dispatch(UPDATE_PRODUCT, productInputs).then(() => {
        alert('The product has been updated.');
      });
    };

    return {
      ...toRefs(productInputs),
      updateProduct,
    };
  },
});
</script>
