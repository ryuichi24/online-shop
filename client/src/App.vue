<template>
  <TheNavbar v-if="!isAdmin" />
  <RouterView />
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue';
// layout components
import { TheNavbar } from './layouts';
// hooks
import { useUtils } from './hooks';

// section components
export default defineComponent({
  components: {
    TheNavbar,
  },
  setup() {
    const { evalURL } = useUtils();
    const isAdmin = ref(false);
    isAdmin.value = evalURL('admin');

    return {
      isAdmin,
    };
  },
});
</script>
