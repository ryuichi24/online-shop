<template>
  <svg
    xmlns="http://www.w3.org/2000/svg"
    :width="width"
    :height="height"
    :fill="fill"
    viewBox="0 0 24 24"
  >
    <path d="M24 10h-10v-10h-4v10h-10v4h10v10h4v-10h10z" />
  </svg>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'PlusIcon',
  props: {
    width: String,
    height: String,
    fill: String,
  },
});
</script>
