<template>
  <div>
    <h1>Ｔａｂｌｅ Ｍｅｎｕ</h1>
    <div>
      <b-nav fill tabs>
        <button class="btn col-6 nav-btn" @click="menuAdd()">Add</button>
        <button class="btn col-6 nav-btn" @click="menuList()">List</button>
      </b-nav>
    </div>
    <TableList v-if="displayList"></TableList>
    <TableAdd v-if="displayAdd"></TableAdd>
  </div>
</template>

<script>
import TableList from "../admin/tablemenu/TableList";
import TableAdd from "../admin/tablemenu/TableAdd";

export default {
  components: {
    TableList,
    TableAdd
  },
  name: "TableMenu",
  data() {
    return {
      displayList: true,
      displayAdd: false
    };
  },
  methods: {
    menuAdd() {
      (this.displayAdd = true), (this.displayList = false);
    },
    menuList() {
      (this.displayAdd = false), (this.displayList = true);
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
