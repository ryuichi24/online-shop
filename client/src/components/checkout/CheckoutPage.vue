<template>
  <div class="container" style="margin-bottom: 10rem;">
    <AddressSection />
    <OrderItemSection />
  </div>
</template>

<script>
import { defineComponent } from 'vue';
// components
import AddressSection from './address/AddressSection.vue';
import OrderItemSection from './order-items/OrderItemSection.vue';

export default defineComponent({
  components: {
    AddressSection,
    OrderItemSection,
  },
});
</script>
