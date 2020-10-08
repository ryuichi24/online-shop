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
      <ProductForm v-if="isModalOpen" :toggleForm="toggle" />
      <button @click="toggle">Add Product</button>
    </ul>
  </nav>
</template>

<script>
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
// hooks
import { useSidebarItems, useModalToggle } from '../../../../hooks';
// components
import ProductForm from '../product-form/ProductForm';

export default defineComponent({
  components: {
    ProductForm,
  },
  setup() {
    const { sidebarItems, changeSelectedState } = useSidebarItems();

    const { afterEach } = useRouter();
    afterEach(() => {
      changeSelectedState();
    });

    const { isModalOpen, toggle } = useModalToggle();

    return {
      sidebarItems,
      isModalOpen,
      toggle,
    };
  },
});
</script>
