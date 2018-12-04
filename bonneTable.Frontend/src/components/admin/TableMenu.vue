<template>
  <div>
    <h1>Table Menu</h1>
    <div>
      <b-nav fill tabs>
        <b-nav-item @click="menuAdd()">Add</b-nav-item>
        <b-nav-item @click="menuList()">List</b-nav-item>
      </b-nav>
    </div>
    <TableList v-if="displayList"></TableList>
    <TableAdd v-if="displayAdd"></TableAdd>
  </div>
</template>

<script>
import TableList from "../admin/TableList";
import TableAdd from "../admin/TableAdd";

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
    }
  }
};
</script>

<style scoped>
</style>
