<template>
  <nav class="sidebar">
    <ul class="sidebar__container">
      <li
        v-for="(item, index) in sidebarItems"
        :key="index"
        :class="[`sidebar__item ${item.isSelected && 'sidebar__item--selected'}`]"
      >
        <router-link :to="item.path">
          <span
            :class="[`sidebar__item-text ${item.isSelected && 'sidebar__item-text--selected'}`]"
            >{{ item.text }}</span
          >
        </router-link>
      </li>
      <CreateProductForm v-if="isModalOpen" :toggle="toggle" />
      <button @click="toggle">Add Product</button>
    </ul>
  </nav>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
import { useRouter } from 'vue-router';
// hooks
import { useSidebarItems } from '../../../../hooks';
// components
import CreateProductForm from '../form/create-product/CreateProductForm.vue';

export default defineComponent({
  components: {
    CreateProductForm,
  },
  setup() {
    const { sidebarItems, changeSelectedState } = useSidebarItems();

    const { afterEach } = useRouter();
    afterEach(() => {
      changeSelectedState();
    });

    const isModalOpen = ref(false);
    const toggle = () => {
      isModalOpen.value = !isModalOpen.value;
    };

    return {
      sidebarItems,
      isModalOpen,
      toggle,
    };
  },
});
</script>
