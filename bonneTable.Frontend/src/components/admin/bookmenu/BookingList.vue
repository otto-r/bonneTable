<template>
  <div>
    <h1 class="page-header">Bookings</h1>
    <!-- <h4 v-if="removedTable.length > 0">Deleted:</h4> -->
    <!-- <table v-if="removedTable.length > 0" class="table table-hover danger">
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
    </table>-->
    <table v-if="bookings.length > 0" class="table table-striped table-sm table-md mt-2">
      <thead>
        <tr>
          <th>Date</th>
          <th>Guests</th>
          <th>Name</th>
          <th>E-mail</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="booking in bookings" :key="booking.id">
          <td>{{booking.time}}</td>
          <!-- <td v-if="!booking.editing">{{booking.seats}}</td>
          <td v-if="booking.editing">
            <input
              v-validate="'numeric'"
              v-model="booking.seats"
              data-vv-as="field"
              name="seats_field"
              type="text"
              class="form-control"
              :class="{'has-error': errors.has('seats_field')}"
            >
          </td>-->
          <td>
            {{booking.seats}}
            <!-- <b-button v-if="!booking.editing" @click="activateEditing(booking)">Edit</b-button> -->
            <!-- <b-button v-if="booking.editing" @click="saveEditing(booking)">Save</b-button> -->
          </td>
          <td>
            {{ booking.customerName}}
            <!-- <b-button @click="deleteTable(booking)">Delete</b-button> -->
          </td>
          <td>{{booking.email}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { getByDate, getAll } from "@/api/BookingAPI";

export default {
  name: "BookingList",
  data() {
    return {
      deletedBooking: [],
      deleteSuccessful: false,
      bookings: [{}]
    };
  },
  methods: {
    getAllBookings() {
      console.log("Get all bookings!");
      getAll(Date.now())
        .then(response => {
          this.bookings = response.bookings;
          console.log(this.bookings);
          // this.tables = this.addEditProperty();
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
    this.getAllBookings();
  },
  beforeCreate() {}
};
</script>
<style scoped>
</style>
