import Vue from 'vue'
import BootstrapVue from "bootstrap-vue"
import App from './App'
import VueRouter from 'vue-router'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import Admin from './components/Admin.vue'
import Book from './components/Book.vue'
import DateSelect from './components/DateSelect.vue'
import GuestsSelect from './components/GuestsSelect.vue'
import TimeSelect from './components/TimeSelect.vue'
import ConfirmSelect from './components/ConfirmSelect.vue'

Vue.use(BootstrapVue)
Vue.use(VueRouter);

Vue.config.productionTip = false

const routes = [
  { path: '/admin', component: Admin},
  { path: '/book', component: Book,
    children: [
      {
        path: 'date', component: DateSelect
      },
      {
        path: 'guests', component: GuestsSelect
      },
      {
        path: 'time', component: TimeSelect
      },
      {
        path: 'confirm', component: ConfirmSelect
      }
    ]}
]

const router = new VueRouter({
  routes,
  mode: 'history'
})

new Vue({
  el: '#app',
  router,
  template: '<App/>',
  components: { App }
})
