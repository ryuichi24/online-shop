<template>
  <div class="container" style="margin-bottom: 10rem;">Product page</div>
</template>

<script>
import { defineComponent } from 'vue';
import { useRoute } from 'vue-router';

export default defineComponent({
  setup() {
    const { params } = useRoute();
  },
});
</script>
