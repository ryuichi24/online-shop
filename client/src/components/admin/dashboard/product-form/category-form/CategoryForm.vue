<template>
  <label for="category"></label>
  <input v-model="categoryName" name="cateogry" type="text" />
  <button @click="addCategory">Add category</button>
</template>

<script>
import { defineComponent, ref } from 'vue';

export default defineComponent({
  setup() {
    const categoryName = ref();

    const addCategory = () => {
      console.log(categoryName.value);
    };

    return {
      categoryName,
      addCategory,
    };
  },
});
</script>
