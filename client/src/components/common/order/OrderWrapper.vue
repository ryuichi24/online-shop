<template>
  <div class="order">
    {{ order }}
  </div>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  props: {
    order: Object,
  },
});
</script>
