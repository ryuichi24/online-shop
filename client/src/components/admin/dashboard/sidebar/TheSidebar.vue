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
      <ProductFormToggleBtn />
    </ul>
  </nav>
</template>

<script>
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
// hooks
import { useSidebarItems } from '../../../../hooks';
// components
import ProductFormToggleBtn from '../product-form/ProductFormToggleBtn';

export default defineComponent({
  components: {
    ProductFormToggleBtn,
  },
  setup() {
    const { sidebarItems, changeSelectedState } = useSidebarItems();

    const { afterEach } = useRouter();
    afterEach(() => {
      changeSelectedState();
    });

    return {
      sidebarItems,
    };
  },
});
</script>
