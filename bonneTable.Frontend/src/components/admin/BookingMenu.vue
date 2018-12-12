<template>
  <div>
    <h1>Booking Menu</h1>
    <div>
      <b-nav fill tabs>
        <b-nav-item @click="menuBook()">Book</b-nav-item>
        <b-nav-item @click="menuList()">List</b-nav-item>
      </b-nav>
    </div>
    <BookingList v-if="displayList"></BookingList>
    <TableAdd v-if="displayBook"></TableAdd>
  </div>
</template>

<script>
import BookingList from "../admin/bookmenu/BookingList";
// import --- from "../admin/bookmenu/---";

export default {
  components: {
    BookingList,
    // BookTable
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
      if (!localStorage.loggedIn) {
        console.log("not logged in run")
        this.$router.push({ path: "/LogIn" });
      }
    }
  },
  beforeCreate(){
    this.notLoggedIn()
  }
};
</script>

<style scoped>
</style>
