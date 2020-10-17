<template>
  <div class="dashboard">
    <TheSideBar />
    <router-view />
  </div>
</template>

<script>
import { defineComponent, onMounted } from 'vue';
import { useRouter } from 'vue-router';
// components
import TheSideBar from './sidebar/TheSidebar.vue';

export default defineComponent({
  components: {
    TheSideBar,
  },
  setup() {
    const { push } = useRouter();

    onMounted(() => {
      push({ name: 'ProductSection' });
    });
  },
});
</script>
