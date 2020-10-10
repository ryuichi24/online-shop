import {
  createRouter,
  createWebHistory,
  RouteRecordRaw,
  RouteLocationNormalized,
  NavigationGuardNext,
} from 'vue-router';
// views
import {
  HomePage,
  AdminPage,
  ProductSection,
  OrderSection,
  SignUpForm,
  LoginForm,
  AccountPage,
  CartItemsPage,
  ProductPage,
} from '@/views';
// vuex
import store from '@/store';
import { CHECK_ADMIN_AUTH, CHECK_AUTH } from '@/store/types/action.type';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage,
  },
  {
    path: '/product/:id',
    name: 'ProductPage',
    component: ProductPage,
  },
  {
    path: '/sign-up',
    name: 'SignUpForm',
    component: SignUpForm,
  },
  {
    path: '/login',
    name: 'LoginForm',
    component: LoginForm,
  },
  {
    path: '/account',
    name: 'AccountPage',
    component: AccountPage,
    meta: {
      requiredAuth: true,
    },
  },
  {
    path: '/cart-items',
    name: 'CartItemsPage',
    component: CartItemsPage,
    meta: {
      requiredAuth: true,
    },
  },
  {
    path: '/admin',
    name: 'AdminPage',
    component: AdminPage,
    children: [
      {
        path: 'products',
        name: 'ProductSection',
        component: ProductSection,
      },
      {
        path: 'orders',
        name: 'OrderSection',
        component: OrderSection,
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

router.beforeEach(
  async (to: RouteLocationNormalized, from: RouteLocationNormalized, next: NavigationGuardNext) => {
    const requiredAuth = to.matched.some((route) => route.meta.requiredAuth);

    await store.dispatch(CHECK_AUTH);
    const isAuthenticated = store.getters.isAuthenticated;

    // admin auth check
    await store.dispatch(CHECK_ADMIN_AUTH);

    if (requiredAuth && !isAuthenticated) {
      // TODO: dispatch message saying you need to login
      alert('Please login to access');
      next('/login');
    } else if (requiredAuth && isAuthenticated) {
      next();
    } else {
      next();
    }
  },
);

export default router;
