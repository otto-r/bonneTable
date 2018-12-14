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
          <th>Delete / Edit</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="booking in bookings" :key="booking.id">
          <td>{{ convertDateTime(booking.time)}}</td>
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
          <td>
            <b-button @click="edit(booking)">Edit</b-button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { getByDate, getAll, cancel } from "@/api/BookingAPI";
import { formatTime } from "@/api/TimeFormatter";

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
    edit() {
      console.log("clicked");
    },
    getAllBookings() {
      getAll(Date.now())
        .then(response => {
          this.bookings = response.bookings;
        })
        .catch(error => {
          console.log(error);
        });
    },
    deleteBooking(booking) {
      cancel(booking.id)
        .then(response => {
          this.deleteSuccessful = response.success;
          if (response.success) {
            this.removedTable.push(table);
          }
          this.getAllBookings();
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
    },
    convertDateTime(date) {
      var x = new Date(date);
      var hours = x.getHours();
      if (hours < 10) {
        hours += "0";
      }
      var min = x.getMinutes();
      if (min < 10) {
        min += "0";
      }
      var day = x.getDay();
      var date = x.getDate();
      if (date < 10) {
        date += "0";
      }
      var month = x.getMonth() + 1;
      if (month < 10) {
        month += "0";
      }
      var year = x.getFullYear();
      var weekday = new Array(7);
      weekday[0] = "Sunday";
      weekday[1] = "Monday";
      weekday[2] = "Tuesday";
      weekday[3] = "Wednesday";
      weekday[4] = "Thursday";
      weekday[5] = "Friday";
      weekday[6] = "Saturday";
      return (
        date +
        "/" +
        month +
        "/" +
        year +
        " - " +
        weekday[day] +
        " " +
        hours +
        ":" +
        min
      );
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
