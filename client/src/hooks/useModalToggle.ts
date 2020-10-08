import { ref } from 'vue';

const useModalToggle = () => {
  const isModalOpen = ref(false);

  const toggle = () => {
    isModalOpen.value = !isModalOpen.value;
  };

  return {
    isModalOpen,
    toggle,
  };
};

export default useModalToggle;
