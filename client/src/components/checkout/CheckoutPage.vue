<template>
  <div class="container" style="margin-bottom: 10rem;">
    <AddressSection />
  </div>
</template>

<script>
import { defineComponent } from 'vue';
// components
import AddressSection from './address/AddressSection.vue';

export default defineComponent({
  components: {
    AddressSection,
  },
});
</script>
