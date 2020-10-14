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
    <button @click="update">Update</button>
  </form>
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs, PropType } from 'vue';
// type
import { User } from '../../../../types';

export default defineComponent({
  props: {
    user: Object as PropType<User>,
  },
  setup({ user }) {
    const userInputs = reactive({
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      password: '',
      phone: user.phone,
    });

    const update = () => {
      console.log(userInputs);
    };

    return {
      ...toRefs(userInputs),
      update,
    };
  },
});
</script>
