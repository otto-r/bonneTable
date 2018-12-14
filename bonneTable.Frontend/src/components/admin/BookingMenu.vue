<template>
  <div>
    <h1>Booking Menu</h1>
    <button class="btn" @click="openModal()">Show Modal</button>
    <div>
      <b-nav fill tabs>
        <b-nav-item @click="menuBook()">Book</b-nav-item>
        <b-nav-item @click="menuList()">List</b-nav-item>
      </b-nav>
    </div>
    <EditModal v-if="displayModal" @close="displayModal = false"/>
    <BookingList v-if="displayList"></BookingList>
  </div>
</template>

<script>
import BookingList from "../admin/bookmenu/BookingList";
import EditModal from "../admin/bookmenu/EditModal";

export default {
  components: {
    BookingList,
    EditModal
  },
  name: "BookingMenu",
  data() {
    return {
      displayModal: false,
      displayList: true,
      displayBook: false
    };
  },
  methods: {
    openModal() {
      this.displayModal = true;
    },
    menuBook() {
      (this.displayBook = true), (this.displayList = false);
    },
    menuList() {
      (this.displayBook = false), (this.displayList = true);
    },
    notLoggedIn() {
      if (!localStorage.loggedIn) {
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
</style>
