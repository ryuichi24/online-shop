<template>
  <nav class="sidebar">
    <ul class="sidebar__container">
      <li
        v-for="(item, index) in sidebarItems"
        :key="index"
        :class="[`sidebar__item ${item.isSelected && 'sidebar__item--selected'}`]"
      >
        <router-link :to="item.path">
          <span>{{ item.text }}</span>
        </router-link>
      </li>
    </ul>
  </nav>
</template>

<script>
import { defineComponent, ref } from 'vue';

export default defineComponent({
  setup() {
    const sidebarItems = ref([
      {
        text: 'Products',
        path: '/admin/products',
        isSelected: false,
      },
      {
        text: 'Orders',
        path: '/admin/orders',
        isSelected: true,
      },
    ]);

    return {
      sidebarItems,
    };
  },
});
</script>
