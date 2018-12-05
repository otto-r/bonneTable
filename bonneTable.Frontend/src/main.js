import Vue from "vue";
import Vuex from "vuex";
import BootstrapVue from "bootstrap-vue";
import App from "./App";
import VueRouter from "vue-router";
import VCalendar from "v-calendar";
import "v-calendar/lib/v-calendar.min.css";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

import Admin from "./components/admin/Admin.vue";
import TableMenu from "./components/admin/TableMenu.vue";
import BookingMenu from "./components/admin/BookingMenu.vue";
import LogIn from "./components/admin/LogIn.vue";
import Book from "./components/Book.vue";
import DateSelect from "./components/DateSelect.vue";
import GuestsSelect from "./components/GuestsSelect.vue";
import TimeSelect from "./components/TimeSelect.vue";
import ConfirmSelect from "./components/ConfirmSelect.vue";
import VeeValidate from "vee-validate";

Vue.use(BootstrapVue);
Vue.use(VueRouter);
Vue.use(Vuex);
Vue.use(VeeValidate);
Vue.use(VCalendar, {
  firstDayOfWeek: 2
});

Vue.config.productionTip = false;

const routes = [
  {
    path: "/admin",
    component: Admin,
    children: [
      { path: "tablemenu", component: TableMenu },
      { path: "bookingmenu", component: BookingMenu }
    ]
  },
  { path: "/login", component: LogIn },
  {
    path: "/book",
    component: Book,
    children: [
      {
        path: "date",
        component: DateSelect
      },
      {
        path: "guests",
        component: GuestsSelect
      },
      {
        path: "time",
        component: TimeSelect
      },
      {
        path: "confirm",
        component: ConfirmSelect
      }
    ]
  }
];

const router = new VueRouter({
  routes,
  mode: "history"
});

const store = new Vuex.Store({
  state: {
    date: new Date(),
    guests: null,
    time: null,
    name: null,
    email: null,
    phoneNumber: null,
    loggedIn: false
  },
  mutations: {
    setDate(state, newDate) {
      state.date = newDate;
    },
    setGuests(state, newGuests) {
      state.guests = newGuests;
    },
    setTime(state, newTime) {
      state.time = newTime;
    },
    setName(state, newName) {
      state.name = newName;
    },
    setEmail(state, newEmail) {
      state.email = newEmail;
    },
    setPhoneNumber(state, newPhoneNumber) {
      state.phoneNumber = newPhoneNumber;
    },
    setLoggedIn(state, newLoggedIn) {
      state.loggedIn = newLoggedIn;
    }
  }
});

new Vue({
  el: "#app",
  router,
  store,
  template: "<App/>",
  components: { App }
});
