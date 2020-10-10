<template>
  <div class="container" style="margin-bottom: 10rem;">
    {{ product }}
  </div>
</template>

<script>
import { defineComponent, onMounted, computed } from 'vue';
import { useRoute } from 'vue-router';
// vuex
import { useStore } from 'vuex';
import { GET_PRODUCT_BY_ID } from '../../../store/types/action.type';

export default defineComponent({
  setup() {
    const { params } = useRoute();
    const { dispatch, getters } = useStore();

    const product = computed(() => getters.product);

    onMounted(() => {
      dispatch(GET_PRODUCT_BY_ID, params.id);
    });

    return {
      product,
    };
  },
});
</script>
