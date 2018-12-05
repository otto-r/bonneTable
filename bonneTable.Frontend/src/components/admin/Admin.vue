<template>
  <div>
    <h1>Admin</h1>
    <h3>{{ date }}</h3>
    <div>
      <div class="container-fluid mt-3">
        <div class="row">
          <div class="col-6 mx-auto">
            <b-button-group>
              <b-button @click="clickBookingMenu()">Booking</b-button>
              <b-button @click="clickTableMenu()">Tables</b-button>
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

export default {
  name: "Admin",
  data() {
    return {
      displayBookingnMenu: true,
      displayTableMenu: false
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
    }
  },
  created() {}
};
</script>

<style scoped>
</style>
