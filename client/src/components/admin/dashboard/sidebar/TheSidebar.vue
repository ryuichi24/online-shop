<template>
  <nav class="sidebar">
    <ul class="sidebar__container">
      <li
        v-for="(item, index) in sidebarItems"
        :key="index"
        :class="[`sidebar__item ${item.isSelected && 'sidebar__item--selected'}`]"
      >
        <router-link :to="item.path">
          <span :class="[`sidebar__item-text ${item.isSelected && 'sidebar__item-text--selected'}`]">{{ item.text }}</span>
        </router-link>
      </li>
    </ul>
  </nav>
</template>

<script>
import { defineComponent, onMounted } from 'vue';
import { useRouter } from 'vue-router';
// hooks
import { useSidebarItems } from '../../../../hooks';

export default defineComponent({
  setup() {
    const { sidebarItems, changeSelectedState } = useSidebarItems();

    const { afterEach } = useRouter();
    afterEach(() => {
      changeSelectedState();
    });

    onMounted(() => changeSelectedState());

    return {
      sidebarItems,
    };
  },
});
</script>
