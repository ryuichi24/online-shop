<template>
  <div v-if="order" class="order">
    <div>
      <span>Order ID: {{ order.orderId }}</span>
    </div>
    <div>
      <span>Order date: {{ order.orderedAt }}</span>
    </div>
    <div v-if="order.user">
      <span>Purchaser: {{ order.user.firstName }} {{ order.user.lastName }}</span>
    </div>
    <div v-if="order.address">
      <span
        >Delibery address: {{ order.address.address1 }}, {{ order.address.address2 }},
        {{ order.address.city }}, Post Code: {{ order.address.postCode }}</span
      >
    </div>
    <div>
      <div v-for="(item, index) in order.orderItems" :key="index">
        <div v-if="item.product">
          <span>{{ item.product.name }}</span>
        </div>
      </div>
    </div>
    <div>
      <span>Total Payment: €{{ order.totalPayment }}</span>
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
