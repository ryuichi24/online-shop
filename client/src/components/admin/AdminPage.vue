<template>
  <div>Admin</div>
  <LoginForm />
</template>

<script>
import { defineComponent } from 'vue';
// components
import LoginForm from './login/LoginForm.vue';

export default defineComponent({
  components: {
    LoginForm,
  },
});
</script>
