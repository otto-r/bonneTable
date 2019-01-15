<template>
  <div>
    <glitchImage/>
    <div>
      <div class="container-fluid mt-3">
        <div class="row">
          <div class="col-6 mx-auto">
            <b-button-group>
              <button class="btn" @click="clickBookingMenu()">Booking</button>
              <b-button @click="clickTableMenu()">Tables</b-button>
              <b-button v-if="displayLogOut" @click="logOut()">Log out</b-button>
            </b-button-group>
            <router-view></router-view>
          </div>
        </div>
      </div>
      <div v-if="loaded && displayChart" class="mx-auto col-lg-6 col-sm-12">
        <h2>Ｂｏｏｋｉｎｇｓ ｔｏｎｉｇｈｔ</h2>
        <bar-chart v-if="loaded && displayChart" :dataArray="bookingsArray"></bar-chart>
      </div>
    </div>
    <div class="col-8 mx-auto">
      <token-timer/>
      <Footer/>
    </div>
  </div>
</template>

<script>
import glitchImage from "../admin/glitchImage";
import Footer from "../admin/Footer";
import { getAll, book, getByDate, getByEmail, cancel } from "@/api/BookingAPI";
import { getTables } from "@/api/TableAPI";
import { formatTime } from "@/api/TimeFormatter";
import TableMenu from "../admin/TableMenu";
import BookingMenu from "../admin/BookingMenu";
import LogIn from "../admin/LogIn";
import TokenTimer from "../admin/TokenTimer";
import { decode } from "@/Helper/JWT.js";
import BarChart from "../admin/Chart.js";

export default {
  components: {
    LogIn,
    glitchImage,
    Footer,
    TokenTimer,
    BarChart
  },
  name: "Admin",
  data() {
    return {
      displayBookingnMenu: true,
      displayTableMenu: false,
      displayLogIn: true,
      displayLogOut: true,
      bookings: [],
      bookingsArray: [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
      loaded: false,
      displayChart: true
    };
  },
  methods: {
    clickTableMenu() {
      this.displayTableMenu = true;
      this.displayBookingnMenu = false;
      this.displayChart = false;

      this.$router.push({ path: "/admin/tablemenu" });
    },
    clickBookingMenu() {
      this.displayBookingnMenu = true;
      this.displayTableMenu = false;
      this.displayChart = false;

      this.$router.push({ path: "/admin/bookingmenu" });
    },
    logOut() {
      localStorage.token = "";
      localStorage.loggedIn = false;
      this.displayChart = false;
      this.displayLogOut = false;
      this.displaylogIn = true;
      this.$router.push({ path: "/login" });
    },
    notLoggedIn() {
      if (localStorage.loggedIn == "false") {
        console.log("notloggedin in if");

        this.$router.push({ path: "/login" });
      }
    },
    seeIfLoggedIn() {
      if (localStorage.token == "null" || localStorage.token == "") {
        console.log("No token found " + localStorage.token);
        this.logOut();
        return;
      }
      var time = decode(localStorage.token);
      if (time <= 0) {
        console.log("time is up: " + time);
        this.logOut();
      }
    },
    fetchBookingsForChart() {
      getByDate(formatTime(new Date()))
        .then(response => {
          this.bookings = response.bookings;

          this.bookings.forEach(booking => {
            var time =
              new Date(booking.time).getUTCHours() +
              "" +
              new Date(booking.time).getUTCMinutes();

            if (time === "160") {
              this.bookingsArray[0] += booking.seats;
            } else if (time === "1630") {
              this.bookingsArray[1] += booking.seats;
            } else if (time === "170") {
              this.bookingsArray[2] += booking.seats;
            } else if (time === "1730") {
              this.bookingsArray[3] += booking.seats;
            } else if (time === "180") {
              this.bookingsArray[4] += booking.seats;
            } else if (time === "1830") {
              this.bookingsArray[5] += booking.seats;
            } else if (time === "190") {
              this.bookingsArray[6] += booking.seats;
            } else if (time === "1930") {
              this.bookingsArray[7] += booking.seats;
            } else if (time === "200") {
              this.bookingsArray[8] += booking.seats;
            } else if (time === "2030") {
              this.bookingsArray[9] += booking.seats;
            } else if (time === "210") {
              this.bookingsArray[10] += booking.seats;
            } else if (time === "2130") {
              this.bookingsArray[11] += booking.seats;
            }
          });
          this.loaded = true;
        })
        .catch(error => {
          console.log(error);
        });
    },
    feedHungryHungryChart() {}
  },
  created() {
    this.fetchBookingsForChart();
    this.seeIfLoggedIn();
    this.notLoggedIn();
  }
};
</script>

<style >
@import url("https://fonts.googleapis.com/css?family=Staatliches");

h1 {
  /* font-family: 'Times New Roman';
  font-size: 2em; */
}

.bg {
  color: pink;
  height: 100%;
  min-height: 100%;
}

.btn {
  border-color: #ffe6ff;
  border-width: 2px;
  color: #ffe6ff;
  background: none;
  font-family: "Staatliches", cursive;
}

.btn:hover {
  border-color: #99ffff;
  border-width: 2px;
  color: none;
  background: #99ffff;
}

.btn:active {
  border-color: #99ffff;
  border-width: 2px;
  color: #99ffff;
  background: none;
}

.btn:focus {
  border-color: #99ffff;
  border-width: 4px;
  color: #99ffff;
  background: none;
  box-shadow: #99ffff;
}

.btn.active {
  border-color: #99ffff;
  border-width: 4px;
  color: #99ffff;
  background: none;
  box-shadow: #99ffff;
}

html,
body {
  background: linear-gradient(
    to bottom right,
    #f056ff 0%,
    #2989d8 50%,
    #00fffa 100%
  );
  color: pink;
  background-attachment: fixed;
  height: 100%;
}

.logo {
  max-width: 100px;
  height: auto;
}
</style>
