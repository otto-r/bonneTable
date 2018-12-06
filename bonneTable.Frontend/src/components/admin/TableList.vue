<template>
  <div>
    <h1 class="page-header">Table List</h1>
    <b-table striped hover :items="tables"></b-table>
    <!-- https://bootstrap-vue.js.org/docs/components/table/ -->
  </div>
</template>

<script>
import { getTables } from "@/api/TableAPI";

export default {
  name: "TableList",
  data() {
    return {
      tables: [{ seats: "-", id: "Loading.." }]
    };
  },
  methods: {
    getAllTables() {
      getTables()
        .then(response => {
          if (response.tables < 1) {
            this.tables = [{ seats: 0, id: "Empty" }];
          } else {
            this.tables = response.tables;
          }
        })
        .catch(error => {
          console.log(error);
        });
    }
  },
  created() {
    this.getAllTables();
  }
};
</script>
<style scoped>
</style>
