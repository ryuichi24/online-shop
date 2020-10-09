<template>
  <form class="container" style="margin-bottom: 10rem;" @submit.prevent>
    <div>
      <label for="">First Name</label>
      <input v-model="firstName" type="text" />
    </div>
    <div>
      <label for="">Last Name</label>
      <input v-model="lastName" type="text" />
    </div>
    <div>
      <label for="">Email</label>
      <input v-model="email" type="text" />
    </div>
    <div>
      <label for="">password</label>
      <input v-model="password" type="text" />
    </div>
    <div>
      <label for="">phone</label>
      <input v-model="phone" type="text" />
    </div>
    <button @click="signUp">Send</button>
  </form>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs } from 'vue';
// router
import { useRouter } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { SIGN_UP_USER } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { dispatch } = useStore();
    const { push } = useRouter();

    const userInputs = reactive({
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      phone: '',
    });

    const signUp = () => {
      dispatch(SIGN_UP_USER, userInputs).then(() => {
        push({ name: 'HomePage' });
      });
    };

    return {
      ...toRefs(userInputs),
      signUp,
    };
  },
});
</script>
