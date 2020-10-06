import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
// views
import { HomePage, AdminPage, ProductSection, OrderSection } from '@/views';

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
        component: ProductSection
      },
      {
        path: 'orders',
        name: 'OrderSection',
        component: OrderSection
      },
    ],
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
