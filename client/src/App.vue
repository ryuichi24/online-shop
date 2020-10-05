<template>
  <TheNavbar />

  <div class="container" style="margin-bottom: 10rem;">
    <RouterView />
  </div>

  <TheFooter />
</template>

<script lang="ts">
import { defineComponent } from 'vue';
// layout components
import { TheNavbar, TheFooter } from './layouts';
// section components
export default defineComponent({
  components: {
    TheNavbar,
    TheFooter,
  },
});
</script>