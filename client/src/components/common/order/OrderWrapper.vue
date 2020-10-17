<template>
  <div v-if="order" class="order">
    <div>
      <h3>Order ID</h3>
      <span>{{ order.orderId }}</span>
    </div>
    <div>
      <h3>Order date</h3>
      <span>{{ order.orderedAt }}</span>
    </div>
    <div v-if="order.user">
      <h3>Purchaser</h3>
      <span>{{ order.user.firstName }} {{ order.user.lastName }}</span>
    </div>
    <div v-if="order.address">
      <h3>Delibery address</h3>
      <span
        >{{ order.address.address1 }}, {{ order.address.address2 }},
        {{ order.address.city }}, Post Code: {{ order.address.postCode }}</span
      >
    </div>
    <div>
      <h3>Order items</h3>
      <div v-for="(item, index) in order.orderItems" :key="index">
        <div v-if="item.product">
          <span>{{ item.product.name }}</span>
        </div>
      </div>
    </div>
    <div>
      <h3>Total Payment</h3>
      <span>€{{ order.totalPayment }}</span>
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
