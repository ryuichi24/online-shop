<template>
  <div class="container" style="margin-bottom: 10rem;">
    <div class="account-page">
      <div class="account-page__card account-page__info">Account Info</div>
      <div class="account-page__card account-page__orders">Orders</div>
      <div class="account-page__card account-page__cart-items">CartItems</div>
      <div class="account-page__logout-contact-us">
        <div class="account-page__card">
          <span>Contact us</span>
        </div>
        <div class="account-page__logout-btn-container">
          <span class="account-page__logout-btn" @click="logout">Logout</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from 'vue';
import { useRouter } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { LOGOUT_USER } from '../../store/types/action.type';

export default defineComponent({
  setup() {
    const { push } = useRouter();
    const { dispatch } = useStore();

    const logout = () => {
      dispatch(LOGOUT_USER).then(() => push({ name: 'LoginForm' }));
    };

    return {
      logout,
    };
  },
});
</script>
