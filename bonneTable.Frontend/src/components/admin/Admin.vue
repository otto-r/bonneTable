<template>
  <div>
    <h1>Admin</h1>
    <div>
      <div class="container-fluid mt-3">
        <div class="row">
          <div class="col-6 mx-auto">
            <!-- <logIn/> -->
            <b-button-group>
              <b-button @click="clickBookingMenu()">Booking</b-button>
              <b-button @click="clickTableMenu()">Tables</b-button>
              <b-button v-if="displayLogOut" @click="logOut()">Log out</b-button>
            </b-button-group>
            <router-view></router-view>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { getAll, book, getByDate, getByEmail, cancel } from "@/api/BookingAPI";
import { getTables } from "@/api/TableAPI";
import { formatTime } from "@/api/TimeFormatter";
import TableMenu from "../admin/TableMenu";
import BookingMenu from "../admin/BookingMenu";
import LogIn from "../admin/LogIn";

export default {
  components: {
    LogIn
  },
  name: "Admin",
  data() {
    return {
      displayBookingnMenu: true,
      displayTableMenu: false,
      displayLogIn: true,
      displayLogOut: true
    };
  },
  methods: {
    clickTableMenu() {
      this.displayTableMenu = true;
      this.displayBookingnMenu = false;

      this.$router.push({ path: "/admin/tablemenu" });
    },
    clickBookingMenu() {
      this.displayBookingnMenu = true;
      this.displayTableMenu = false;

      this.$router.push({ path: "/admin/bookingmenu" });
    },
    logOut() {
      localStorage.token = "";
      this.displayLogOut = false;
      this.displaylogIn = true;
      this.$router.push({ path: "/login" });
    },
    notLoggedIn() {
      if (!this.$store.state.loggedIn) {
        this.$router.push({ path: "/LogIn" });
      }
    }
  },
  created() {
    this.notLoggedIn();
  }
};
</script>

<style scoped>
</style>
