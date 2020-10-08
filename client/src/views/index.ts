const HomePage = () => import('@/components/home/HomePage.vue');
// admin
const AdminPage = () => import('@/components/admin/AdminPage.vue');
const ProductSection = () => import('@/components/admin/dashboard/product/ProductSection.vue');
const OrderSection = () => import('@/components/admin/dashboard/order/OrderSection.vue');
// auth
const SignUpForm = () => import('@/components/auth/sign-up/SignUpForm.vue');
const LoginForm = () => import('@/components/auth/login/LoginForm.vue');
// account
const AccountPage = () => import('@/components/account/AccountPage.vue');
// cart items
const CartItemsPage = () => import('@/components/cart-items/CartItemsPage.vue');

export {
  HomePage,
  AdminPage,
  ProductSection,
  OrderSection,
  SignUpForm,
  LoginForm,
  AccountPage,
  CartItemsPage,
};
