<template>
  <TheSideBar />
</template>

<script>
import { defineComponent } from 'vue';
// components
import TheSideBar from './sidebar/TheSidebar.vue';

export default defineComponent({
  components: {
    TheSideBar,
  },
});
</script>
