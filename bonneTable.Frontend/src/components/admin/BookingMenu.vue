<template>
  <div>
    <h1>Ｂｏｏｋｉｎｇ　Ｍｅｎｕ</h1>
    <div>
      <b-nav fill tabs>
        <button class="btn col-6 nav-btn" @click="menuBook()">Book</button>
        <button class="btn col-6 nav-btn" @click="menuList()">List</button>
      </b-nav>
    </div>
    <BookingList v-if="displayList"></BookingList>
  </div>
</template>

<script>
import BookingList from "../admin/bookmenu/BookingList";

export default {
  components: {
    BookingList
  },
  name: "BookingMenu",
  data() {
    return {
      displayList: true,
      displayBook: false
    };
  },
  methods: {
    menuBook() {
      (this.displayBook = true), (this.displayList = false);
    },
    menuList() {
      (this.displayBook = false), (this.displayList = true);
    },
    notLoggedIn() {
      if (localStorage.loggedIn == "false") {
        console.log("not logged in run");
        this.$router.push({ path: "/LogIn" });
      }
    }
  },
  beforeCreate() {
    this.notLoggedIn();
  }
};
</script>

<style scoped>
.nav-btn{
  border-bottom: 0px none none;
  border: 0px #ffe6ff solid;
  color: beige;
  border-radius: 0;
  text-decoration: underline;
}
.btn:hover{
  background: pink;
}
</style>
