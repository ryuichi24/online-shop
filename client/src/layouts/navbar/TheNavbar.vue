<template>
  <nav class="nav">
    <div class="nav__container">
      <div class="nav__brand-container">
        <router-link to="/">
          <span @click="resetSelectedState" class="nav__brand">Ryuichi</span>
        </router-link>
      </div>
      <ul class="nav__items">
        <li v-for="(item, index) in navItems" :key="index">
          <router-link :to="item.path">
            <span
              :class="[`nav__item ${item.isSelected && 'nav__item--selected'}`]"
            >
              {{ item.text }}
            </span>
          </router-link>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
// hooks
import { useNavItems } from '../../hooks'
export default defineComponent({
  setup() {
    const { navItems, changeSelectedState, resetSelectedState } = useNavItems();
    const { afterEach } = useRouter();
    afterEach(() => {
      changeSelectedState();
    });
    return {
      navItems,
      resetSelectedState,
    };
  },
});
</script>