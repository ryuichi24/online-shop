import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
// views
import { HomePage, AdminPage } from '@/views';

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
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
