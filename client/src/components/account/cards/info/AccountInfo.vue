<template>
  <div class="account-info">
    <ul>
      <li>
        <span>Name: {{ user.firstName }} {{ user.lastName }}</span>
      </li>
      <li>
        <span>Email: {{ user.email }}</span>
      </li>
      <li>
        <span>Phone: {{ user.phone }}</span>
      </li>
    </ul>
  </div>
</template>

<script>
import { defineComponent, ref, computed, onMounted } from 'vue';
// vuex
import { useStore } from 'vuex';
import { CHECK_AUTH } from '../../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { getters, dispatch } = useStore();

    const user = computed(() => getters.currentUser);

    onMounted(() => {
      dispatch(CHECK_AUTH);
    });

    return {
      user,
    };
  },
});
</script>
