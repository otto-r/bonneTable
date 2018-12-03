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
      tables: [{ seats: 2, id: "52090b54-23d6-461c-8206-ff79de24f6f9" }]
    };
  },
  methods: {
    getAllTables() {
      getTables()
        .then(response => {
          this.tables = response.tables;
        })
        .catch(error => {
          console.log(error);
        });
    }
  },
  created() {
    // this.getAllTables();
  }
};
</script>
<style scoped>
</style>
