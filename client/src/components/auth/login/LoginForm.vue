<template>
  <div class="container" style="margin-bottom: 10rem;">
    <form @submit.prevent>
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
    <div>
      <span>Don't have an account yet?</span>
      <router-link to="/sign-up">
        <span>
          Create an account
        </span>
      </router-link>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs, computed } from 'vue';
// router
import { useRouter } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { LOGIN_USER } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch, getters } = useStore();
    const { push } = useRouter();

    const userInputs = reactive({
      email: '',
      password: '',
    });

    const isAutheticated = computed(() => getters.isAuthenticated);
    const login = () => {
      dispatch(LOGIN_USER, userInputs).then(() => {
        if (!isAutheticated.value) return push({ name: 'LoginForm' });

        push({ name: 'HomePage' });
      });
    };

    return {
      ...toRefs(userInputs),
      login,
    };
  },
});
</script>
