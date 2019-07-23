import Vue from 'vue'
import BootstrapVue from 'bootstrap-vue'
import App from './App.vue'
import router from './router'
import store from './store'
import AuthService from "./AuthService"

//Vue.config.productionTip = false
Vue.use(BootstrapVue)
async function init() {
  let user = await AuthService.Authenticate()
  if (user) { store.commit("setUser", user) }
  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
init()

