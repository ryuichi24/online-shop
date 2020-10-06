import {
  createRouter,
  createWebHistory,
  RouteRecordRaw,
  RouteLocationNormalized,
  NavigationGuardNext,
} from 'vue-router';
// views
import { HomePage, AdminPage, ProductSection, OrderSection } from '@/views';
// vuex
import store from '@/store';
import { CHECK_ADMIN_AUTH } from '@/store/types/action.type';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'HomePage',
    component: HomePage,
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
    // admin auth check
    await store.dispatch(CHECK_ADMIN_AUTH);
    next();
  }
);

export default router;
