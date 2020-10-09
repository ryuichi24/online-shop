<template>
  <form class="container" style="margin-bottom: 10rem;" @submit.prevent>
    <div>
      <label for="">Email</label>
      <input v-model="email" type="text" />
    </div>
    <div>
      <label for="">password</label>
      <input v-model="password" type="text" />
    </div>
    <button @click="login">Login</button>
  </form>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs } from 'vue';
// vuex
import { useStore } from 'vuex';
import { LOGIN_USER } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch } = useStore();

    const userInputs = reactive({
      email: '',
      password: '',
    });

    const login = () => {
      dispatch(LOGIN_USER, userInputs);
    };

    return {
      ...toRefs(userInputs),
      login,
    };
  },
});
</script>
