<template>
  <div>
    <h1>Table Menu</h1>
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
      displayAdd: false,
    };
  }
};
</script>

<style scoped>
</style>
