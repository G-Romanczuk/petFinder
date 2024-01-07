// Composables
import { createRouter, createWebHistory } from 'vue-router'

const routes = [
  {
    path: '/',
    name: 'Home',
    component: () => import('@/views/LandingView.vue'),
  },
  {
    path: '/userMenu',
    name: 'userMenu',
    component: () => import('@/views/UserLandingView.vue'),
  },
  {
    path: '/shelterMenu',
    name: 'shelterMenu',
    component: () => import('@/views/ShelterLandingView.vue'),
  },
  {
    path: '/hi',
    name: 'test',
    component: () => import('@/components/tes.vue'),
  },
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
})

export default router
