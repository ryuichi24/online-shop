import { ref } from 'vue';

const useNavItems = () => {
  const navItems = ref([
    {
      text: 'Login',
      path: '/login',
      isSelected: false,
    },
    {
      text: 'Contact us',
      path: '/contact-us',
      isSelected: false,
    },
  ]);

  const resetSelectedState = () => {
    navItems.value.forEach((item) => {
      item.isSelected = false;
    });
  };

  const changeSelectedState = () => {
    resetSelectedState();

    const { href } = document.location;
    const reg = /([^/]*)\/*$/;
    const result = href.match(reg);
    if (!result) return;
    const selectedPagePath = `/${result[1]}`;

    const selectedIndex = navItems.value.findIndex((item) => item.path === selectedPagePath);
    navItems.value[selectedIndex].isSelected = true;
  };

  return {
    navItems,
    changeSelectedState,
    resetSelectedState,
  };
};

export default useNavItems;
