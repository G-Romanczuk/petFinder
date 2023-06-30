// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('@/views/LandingView.vue'),
  },
  {
    path: '/userData',
    name: 'userData',
    component: () => import('@/components/UserForm.vue'),
  },
  {
    path: '/userMenu',
    name: 'userMenu',
    component: () => import('@/views/UserLandingView.vue'),
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
