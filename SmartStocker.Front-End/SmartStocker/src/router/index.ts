import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '@/views/Home.vue'
import StockView from '@/views/Stock.vue'
import OrderView from '@/views/Orders.vue'

const routes = [
  { path: '/', name: 'Home', component: HomeView },
   { path: '/Stock', name: 'Stock', component: StockView },
   { path: '/Orders', name: 'Orders', component: OrderView },

]

const router = createRouter({
  history: createWebHistory(),
  routes,
})

export default router