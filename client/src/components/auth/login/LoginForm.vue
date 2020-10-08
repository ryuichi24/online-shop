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

export default defineComponent({
  setup() {
    const { dispatch } = useStore();

    const userInputs = reactive({
      email: '',
      password: '',
    });

    const login = () => {
      console.log(userInputs);
    };

    return {
      ...toRefs(userInputs),
      login,
    };
  },
});
</script>
