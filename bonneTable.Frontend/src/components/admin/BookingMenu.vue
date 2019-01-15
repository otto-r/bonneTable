<template>
  <div>
    <h1>Ｂｏｏｋｉｎｇ Ｍｅｎｕ</h1>
    <div>
      <b-nav fill tabs>
        <button class="btn col-6 nav-btn" @click="menuBook()">Book</button>
        <button class="btn col-6 nav-btn" @click="menuList()">List</button>
      </b-nav>
    </div>
    <BookingList v-if="displayList"></BookingList>
    <BookAdmin v-if="displayBook" @newBooking="reloadBookAdmin()"></BookAdmin>
    <br>
    <br>
    <br>
    <br>
    <div class="row">
      <div class="mx-auto">
        <b-img class="logo" src="/static/logo.png"/>
      </div>
    </div>
  </div>
</template>

<script>
import BookingList from "../admin/bookmenu/BookingList";
import BookAdmin from "../admin/bookmenu/BookAdmin";
import { decode } from "@/Helper/JWT.js";

export default {
  components: {
    BookingList,
    BookAdmin
  },
  name: "BookingMenu",
  data() {
    return {
      displayList: true,
      displayBook: false
    };
  },
  methods: {
    reloadBookAdmin() {
      this.displayBook = false;
      this.displayBook = true;
    },
    menuBook() {
      (this.displayBook = true), (this.displayList = false);
    },
    menuList() {
      (this.displayBook = false), (this.displayList = true);
    },
    logOut() {
      localStorage.token = "";
      localStorage.loggedIn = false;
      this.displayLogOut = false;
      this.displaylogIn = true;
      this.$router.push({ path: "/login" });
    },
    notLoggedIn() {
      console.log("notlogged in method");
      if (localStorage.token == "null" || localStorage.token == "") {
        console.log("No token found " + localStorage.token);
        this.logOut();
        return;
      }
      if (localStorage.loggedIn == "false") {
        console.log("not logged in run");
        this.$router.push({ path: "/LogIn" });
        return;
      }
      var time = decode(localStorage.token);
      if (time <= 0) {
        console.log("time is up: " + time);
        this.logOut();
      }
    }
  },
  beforeCreate() {
    this.notLoggedIn();
  }
};
</script>

<style scoped>
.nav-btn {
  border-bottom: 0px none none;
  border: 0px #ffe6ff solid;
  color: beige;
  border-radius: 0;
  text-decoration: underline;
}
.btn:hover {
  background: pink;
}
</style>
