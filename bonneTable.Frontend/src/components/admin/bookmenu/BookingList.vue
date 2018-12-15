<template>
  <div>
    <h1 class="page-header">Ｂｏｏｋｉｎｇｓ</h1>
    <div class="mt-3">
      <v-date-picker
        class="datepicker"
        @click="toGuests()"
        :pane-width="290"
        is-inline
        mode="single"
        v-model="$store.state.date"
        :min-date="today"
      ></v-date-picker>
    </div>
    <div class="row label-thing">
      <div class="form-group mx-auto">
        <label class="control-label label-thing" for="Email">Σｍａｉｌ</label>
        <input
          class="input-thing"
          :class="{'input': true, 'is-invalid': errors.has('Email') }"
          v-model="searchEmail"
          name="Email"
          type="text"
          placeholder="Email"
        >
        <p class="text-danger" v-if="errors.has('Email')">{{ errors.first('Email') }}</p>
        <b-button @click="getBookingsEmail()">Search</b-button>
      </div>
    </div>
    <EditModal v-if="displayModal" @close="displayModal = false"/>
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
          <td>{{booking.seats}}</td>
          <td>{{ booking.customerName}}</td>
          <td>{{booking.email}}</td>
          <td>
            <button class="btn" @click="openModal(booking)">Edit</button>
            <button class="btn" @click="deleteBooking(booking)">Del</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import { getByDate, getAll, getByEmail, cancel } from "@/api/BookingAPI";
import EditModal from "../bookmenu/EditModal";
import { formatTime } from "@/api/TimeFormatter";

export default {
  components: {
    EditModal
  },
  name: "BookingList",
  data() {
    return {
      deletedBooking: [],
      deleteSuccessful: false,
      bookings: [],
      displayModal: false,
      searchEmail: ""
    };
  },
  methods: {
    openModal(booking) {
      this.displayModal = true;
      this.$store.state.time = booking.time;
      this.$store.state.guests = booking.seats;
      this.$store.state.name = booking.customerName;
      this.$store.state.email = booking.email;
      this.$store.state.phoneNumber = booking.phoneNumber;
    },
    edit() {
      console.log("clicked");
    },
    getBookingsEmail() {
      getByEmail(this.searchEmail)
        .then(response => {
          this.bookings = response.bookings;
        })
        .catch(error => {
          console.log(error);
        });
    },
    getAllBookings() {
      getAll()
        .then(response => {
          this.bookings = response.bookings;
          this.bookings.sort((b, a) => a.time.localeCompare(b.time));
        })
        .catch(error => {
          console.log(error);
        });
    },
    deleteBooking(booking) {
      cancel(booking.id)
        .then(response => {
          this.deleteSuccessful = response.success;
          this.getAllBookings();
        })
        .catch(error => {
          console.log(error);
        });
    },
    getBookingsByDate(booking) {
      getByDate(booking.time)
        .then(response => {
          this.bookings = response.bookings;
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
      var hours = x.getUTCHours();
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
.label-thing {
  font-size: 1.2em;
}

.input-thing {
  color: #ffe6ff;
  border: none;
  background: none;
  border-bottom: #ffe6ff;
  border-bottom-color: #ffe6ff;
  border-bottom-width: 3px;
  border-bottom: 4px solid #ffe6ff;
  outline: none;
}

.datepicker {
  font-family: sans-serif;
  /* background: rgb(7, 7, 7); */
  background: rgb(212, 45, 45);
}
</style>
