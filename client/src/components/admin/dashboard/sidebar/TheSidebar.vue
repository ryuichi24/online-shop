<template>
  <nav class="sidebar">
    <ul class="sidebar__container">
      <li class="sidebar__item">
        <router-link to="/admin/products">
          <span>Products</span>
        </router-link>
      </li>
      <li class="sidebar__item">
        <router-link to="/admin/orders">
          <span>Orders</span>
        </router-link>
      </li>
    </ul>
  </nav>
</template>

<script>
export default {};
</script>
