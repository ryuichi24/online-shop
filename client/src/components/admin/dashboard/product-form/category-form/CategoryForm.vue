<template>
  <label for="category"></label>
  <input v-model="categoryName" name="cateogry" type="text" />
  <button @click="addCategory">Add category</button>
</template>

<script>
import { defineComponent, ref } from 'vue';
// vuex
import { useStore } from 'vuex';
import { ADD_CATEGORY } from '../../../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch } = useStore();

    const categoryName = ref();

    const addCategory = () => {
      dispatch(ADD_CATEGORY, categoryName.value);
    };

    return {
      categoryName,
      addCategory,
    };
  },
});
</script>
