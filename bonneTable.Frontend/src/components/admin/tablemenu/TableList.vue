<template>
  <div>
    <h1 class="page-header">Table List</h1>
    <h4 v-if="removedTable.length > 0">Deleted:</h4>
    <table v-if="removedTable.length > 0" class="table table-hover danger">
      <thead class="danger">
        <tr>
          <th>Id</th>
          <th>Seats</th>
        </tr>
      </thead>
      <tbody>
        <tr class="table-danger" v-for="table in removedTable" :key="table.id">
          <td>{{table.id}}</td>
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
          <td v-if="!table.editing">{{table.seats}}</td>
          <td v-if="table.editing">
            <input
              v-validate="'numeric'"
              v-model="table.seats"
              data-vv-as="field"
              name="seats_field"
              type="text"
              class="form-control"
              :class="{'has-error': errors.has('seats_field')}"
            >
          </td>
          <td>
            <b-button v-if="!table.editing" @click="activateEditing(table)">Edit</b-button>
            <b-button v-if="table.editing" @click="saveEditing(table)">Save</b-button>
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
import { getTables, removeTable, editTable } from "@/api/TableAPI";

export default {
  name: "TableList",
  data() {
    return {
      removedTable: [],
      deleteSuccessful: false,
      tables: [{}]
    };
  },
  methods: {
    getAllTables() {
      getTables()
        .then(response => {
          this.tables = response.tables;
          this.tables = this.addEditProperty();
        })
        .catch(error => {
          console.log(error);
        });
    },
    deleteTable(table) {
      removeTable(table.id)
        .then(response => {
          this.deleteSuccessful = response.success;
          if (response.success) {
            this.removedTable.push(table);
          }
          this.getAllTables();
        })
        .catch(error => {
          console.log(error);
        });
    },
    addEditProperty() {
      var newList = [];
      this.tables.forEach(table => {
        newList.push({ id: table.id, seats: table.seats, editing: false });
      });
      return newList;
    },
    activateEditing(table) {
      table.editing = true;
    },
    saveEditing(table) {
      editTable(table);
      table.editing = false;
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
