const HomePage = () => import('@/components/home/HomePage.vue');
// admin
const AdminPage = () => import('@/components/admin/AdminPage.vue');
const ProductSection = () => import('@/components/admin/dashboard/product/ProductSection.vue');
const OrderSection = () => import('@/components/admin/dashboard/order/OrderSection.vue');

export { HomePage, AdminPage, ProductSection, OrderSection };
