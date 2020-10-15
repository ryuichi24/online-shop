<template>
  <div class="container" style="margin-bottom: 10rem;">
    <div class="account-page">
      <div class="account-page__card account-page__info">
        <span class="account-page__edit-btn" @click="isBeingEdited = !isBeingEdited">{{ editBtnText }}</span>
        <AccountInfo v-if="!isBeingEdited" />
        <AccountInfoForm v-if="isBeingEdited" :user="currentUser" />
      </div>
      <div class="account-page__card account-page__addresses">
        <AddressList />
      </div>
      <div class="account-page__card account-page__order-history">
        <OrderHistory />
      </div>
      <div class="account-page__logout-contact-us">
        <div class="account-page__card account-page__contact-us">
          <h3>Contact us</h3>
          <ul>
            <li>Company name: Example Inc.</li>
            <li>Email: example@exaple.com</li>
            <li>Phone: +359 1234567</li>
          </ul>
        </div>
        <div class="account-page__logout-btn-container">
          <span class="account-page__logout-btn" @click="logout">Logout</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent, ref, computed } from 'vue';
import { useRouter } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { LOGOUT_USER } from '../../store/types/action.type';
// components
import AccountInfo from './cards/info/AccountInfo.vue';
import AccountInfoForm from './cards/info/AccountInfoForm.vue';
import OrderHistory from './cards/order-history/OrderHistory.vue';
import AddressList from './cards/address-list/AddressList';

export default defineComponent({
  components: {
    AccountInfo,
    AccountInfoForm,
    OrderHistory,
    AddressList,
  },
  setup() {
    const { push } = useRouter();
    const { dispatch, getters } = useStore();

    const isBeingEdited = ref(false);

    const logout = () => {
      dispatch(LOGOUT_USER).then(() => push({ name: 'LoginForm' }));
    };

    const currentUser = computed(() => getters.currentUser);

    const editBtnText = computed(() => isBeingEdited.value ? 'Close' : 'Edit');

    return {
      logout,
      isBeingEdited,
      currentUser,
      editBtnText,
    };
  },
});
</script>
