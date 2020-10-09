import { ref } from 'vue';

const useNavItems = () => {
  const navItems = ref([
    {
      text: 'Cart Items',
      path: '/cart-items',
      isSelected: false,
      isForGuest: false,
    },
    {
      text: 'Login',
      path: '/login',
      isSelected: false,
      isForGuest: true,
    },
    {
      text: 'Account',
      path: '/account',
      isSelected: false,
      isForGuest: false,
    },
  ]);

  const resetSelectedState = () => {
    navItems.value.forEach((item) => {
      item.isSelected = false;
    });
  };

  const changeSelectedState = () => {
    resetSelectedState();

    if (`${document.location.origin}/` === document.location.href) return;

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
