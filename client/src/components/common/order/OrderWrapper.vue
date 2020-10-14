<template>
  <div class="order">
    <div class="order__orderId">
      <span>{{ order.orderId }}</span>
    </div>
    <div class="order__orderedAt">
      <span>{{ order.orderedAt }}</span>
    </div>
    <div class="order__totalPayment">
      <span>€ {{ order.totalPayment }}</span>
    </div>
    <div class="order__address">
      <div>
        <span>{{ order.user.firstName }} {{ order.user.lastName }}</span>
      </div>
      <div>
        <span>{{ order.user.email }}</span>
      </div>
      <div>
        <span>{{ order.user.phone }}</span>
      </div>
      <div>
        <span>{{ order.address.address1 }}</span>
      </div>
      <div>
        <span>{{ order.address.address2 }}</span>
      </div>
      <div>
        <span>{{ order.address.city }}</span>
      </div>
      <div>
        <span>{{ order.address.postCode }}</span>
      </div>
    </div>
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
