<template>
  <form @submit.prevent="login" class="login">
    <div class="login__input-container">
      <label class="login__input-lable" for="email">Email</label>
      <input v-model="email" class="login__input" type="email" name="email" />
    </div>
    <div class="login__input-container">
      <label class="login__input-lable" for="password">Password</label>
      <input v-model="password" class="login__input" type="password" name="password" />
    </div>
    <button type="submit">Login</button>
  </form>
</template>

<script>
import { defineComponent, reactive, toRefs } from 'vue';
// vuex
import { useStore } from 'vuex';
import { LOGIN_ADMIN } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch } = useStore();

    const adminInputs = reactive({
      email: '',
      password: '',
    });

    const login = () => {
      dispatch(LOGIN_ADMIN, adminInputs);
    };

    return {
      login,
      ...toRefs(adminInputs),
    };
  },
});
</script>
