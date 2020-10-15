<template>
  <nav class="nav">
    <div class="nav__container">
      <div class="nav__brand-container">
        <router-link to="/">
          <span @click="resetSelectedState" class="nav__brand">Online Shop</span>
        </router-link>
      </div>
      <ul class="nav__items">
        <li v-for="(item, index) in navItems" :key="index">
          <router-link  v-if="!item.isForGuest && isAuthenticated" :to="item.path">
            <span :class="[`nav__item ${item.isSelected && 'nav__item--selected'}`]">
              {{ item.text }}
            </span>
          </router-link>

          <router-link  v-else-if="item.isForGuest && !isAuthenticated" :to="item.path">
            <span :class="[`nav__item ${item.isSelected && 'nav__item--selected'}`]">
              {{ item.text }}
            </span>
          </router-link>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script lang="ts">
import { computed, defineComponent, registerRuntimeCompiler } from 'vue';
import { useRouter } from 'vue-router';
// vuex
import { useStore } from 'vuex';
// hooks
import { useNavItems } from '../../hooks';

export default defineComponent({
  setup() {
    const { getters } = useStore();
    const { navItems, changeSelectedState, resetSelectedState } = useNavItems();

    const isAuthenticated = computed(() => getters.isAuthenticated);

    const { afterEach } = useRouter();
    afterEach(() => {
      changeSelectedState();
    });
    return {
      navItems,
      resetSelectedState,
      isAuthenticated,
    };
  },
});
</script>
