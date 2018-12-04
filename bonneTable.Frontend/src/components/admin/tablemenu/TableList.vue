<template>
  <div>
    <h1 class="page-header">Table List</h1>
    <table v-if="removedTable > 0" class="table table-striped table-sm table-md mt-2">
      <thead>
        <tr>
          <th>Id</th>
          <th>Seats</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="table in removedTable" :key="table.id">
          <td>{{table.Id}}</td>
          <td>{{table.seats}}</td>
        </tr>
      </tbody>
    </table>
    <table v-if="tables.length > 0" class="table table-striped table-sm table-md mt-2">
      <thead>
        <tr>
          <th>Id</th>
          <th>Seats</th>
          <th>Edit</th>
          <th>Delete</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="table in tables" :key="table.id">
          <td>{{table.id}}</td>
          <td>{{table.seats}}</td>
          <td>
            <b-button>Edit</b-button>
          </td>
          <td>
            <b-button @click="deleteTable(table)">Delete</b-button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { getTables } from "@/api/TableAPI";
import { removeTable } from "@/api/TableAPI";

export default {
  name: "TableList",
  data() {
    return {
      removedTable: [{}],
      deleteSuccessful: false,
      tables: [{}]
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
    },
    deleteTable(table) {
      removeTable(table.id)
        .then(response => {
          this.deleteSuccessful = response.success;
          this.removedTable = table;
          this.getAllTables();
        })
        .catch(error => {
          console.log(error);
        });
    }
  },
  created() {
    this.getAllTables();
  },
  beforeCreate() {}
};
</script>
<style scoped>
</style>
