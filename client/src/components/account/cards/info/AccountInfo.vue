<template>
  <div class="account-info">
    <ul>
      <li><span>Name: {{ user.firstName }} {{ user.lastName }}</span></li>
      <li><span>Email: {{ user.email }}</span></li>
      <li><span>Phone: {{ user.phone }}</span></li>
    </ul>
  </div>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  props: {
    user: Object,
  },
});
</script>
