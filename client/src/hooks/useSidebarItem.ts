import { ref } from 'vue';

const useSidebarItems = () => {
  const sidebarItems = ref([
    {
      text: 'Products',
      path: '/admin/products',
      isSelected: false,
    },
    {
      text: 'Orders',
      path: '/admin/orders',
      isSelected: false,
    },
  ]);

  const resetSelectedState = () => {
    sidebarItems.value.forEach((item) => {
      item.isSelected = false;
    });
  };

  const changeSelectedState = () => {
    resetSelectedState();
    console.log('object');

    const { href } = document.location;
    const reg = /([^/]*)\/*$/;
    const result = href.match(reg);
    if (!result) return;
    const selectedPagePath = `/admin/${result[1]}`;

    const selectedIndex = sidebarItems.value.findIndex((item) => item.path === selectedPagePath);
    sidebarItems.value[selectedIndex].isSelected = true;
  };

  return {
    sidebarItems,
    changeSelectedState,
    resetSelectedState,
  };
};

export default useSidebarItems;
