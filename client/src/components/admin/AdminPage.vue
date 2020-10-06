<template>
  <LoginForm v-if="!isAdmin" />
  <TheDashboard v-if="isAdmin" />
</template>

<script lang="ts">
import { defineComponent, computed } from 'vue';
// vuex
import { useStore } from 'vuex';
// components
import LoginForm from './login/LoginForm.vue';
import TheDashboard from './dashboard/TheDashboard.vue';

export default defineComponent({
  components: {
    LoginForm,
    TheDashboard,
  },
  setup() {
    const { getters } = useStore();

    const isAdmin = computed<boolean>(() => getters.isAdmin);

    return {
      isAdmin,
    };
  },
});
</script>
