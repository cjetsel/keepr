import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Keep from './views/Keep.vue'
import MyKeeps from './views/MyKeeps.vue'
import MyVaults from './views/MyVaults.vue'
import VaultKeeps from './views/VaultKeeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/keeps/:keepId',
      name: 'keep',
      props: true,
      component: Keep
    },
    {
      path: '/myKeeps/',
      name: 'myKeeps',
      component: MyKeeps
    },
    {
      path: '/myVaults/',
      name: 'myVaults',
      component: MyVaults
    },
    {
      path: '/vaults/:vaultId',
      name: 'VaultKeeps',
      component: VaultKeeps
    }
  ]
})
