<template>
  <form @submit.prevent>
    <div>
      <label for="address1">Address 1</label>
      <input v-model="address1" type="text" name="address1" />
    </div>
    <div>
      <label for="address2">Address 2</label>
      <input v-model="address2" type="text" name="address2" />
    </div>
    <div>
      <label for="city">City</label>
      <input v-model="city" type="text" name="city" />
    </div>
    <div>
      <label for="postalCode">Post code</label>
      <input v-model="postCode" type="text" name="postalCode" />
    </div>
    <button @click="addAddress">Add</button>
  </form>
  <hr style="margin-top: 1rem;">
</template>

<script lang="ts">
import { defineComponent, reactive, toRefs, computed } from 'vue';
// vuex
import { useStore } from 'vuex';
import { ADD_ADDRESS } from '../../../store/types/action.type';
// type
import { Address } from '../../../types';

export default defineComponent({
  setup() {
    const { dispatch, getters } = useStore();

    const addressInputs = reactive<Address>({
      address1: '',
      address2: '',
      city: '',
      postCode: '',
      userId: null,
    });

    const userId = computed(() => getters.userId);

    const addAddress = () => {
      addressInputs.userId = userId.value;
      dispatch(ADD_ADDRESS, addressInputs);
    };

    return {
      ...toRefs(addressInputs),
      addAddress,
    };
  },
});
</script>
