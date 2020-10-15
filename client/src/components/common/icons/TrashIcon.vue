<template>
  <svg
    :width="width"
    :height="height"
    viewBox="0 0 20 18"
    fill="none"
    xmlns="http://www.w3.org/2000/svg"
  >
    <path
      d="M1.75004 4.5V18H18.25V4.5H1.75004ZM19.1667 1.5V3H0.833374V1.5H6.06846C6.89346 1.5 7.56354 0.67575 7.56354 0H12.4356C12.4356 0.67575 13.1057 1.5 13.9307 1.5H19.1667Z"
      :fill="fill"
    />
  </svg>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'TrashIcon',
  props: {
    width: String,
    height: String,
    fill: String,
  },
});
</script>
