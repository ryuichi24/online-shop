<template>
  <form @submit.prevent>
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
// vuex
import { useStore } from 'vuex';

export default defineComponent({
  setup() {
    const { dispatch } = useStore();

    const userInputs = reactive({
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      phone: '',
    });

    const signUp = () => {
      console.log(userInputs);
    };

    return {
      ...toRefs(userInputs),
      signUp,
    };
  },
});
</script>
