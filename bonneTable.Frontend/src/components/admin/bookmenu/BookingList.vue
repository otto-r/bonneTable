<template>
  <div>
    <div class="row">
      <div>
        <h1 class="page-header">Ｂｏｏｋｉｎｇｓ</h1>
      </div>
      <div class="row">
        <div class="star mx-3">★</div>
        <div class="mx-2">search by:</div>
        <div class="search" v-if="displayCalendarSearchPicker" @click="toggleSearch()">Ξｍａｉｌ</div>
        <div class="search">／</div>
        <div class="search" v-if="displayEmailSearchPicker" @click="toggleCalendarSearch()">Ｄａｔｅ</div>
      </div>
    </div>
    <div class="row">
      <div class="mt-3 mx-auto" v-if="displayCalendarSearch">
        <v-date-picker
          @click="getBookingsByDate()"
          :pane-width="290"
          is-inline
          class="datepicker"
          mode="single"
          :theme-styles="themeStyles"
          v-model="dateSelected"
        ></v-date-picker>
      </div>
    </div>

    <div class="row label-thing" v-if="displayEmailSearch">
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
    <EditModal v-if="displayModal" @save="updateAndSave()" @close="displayModal = false"/>
    <h1
      v-if="bookings.length < 1"
    >No Bookings on: {{ dateSelected.getDate() }} ／ {{ dateSelected.getMonth() +1 }}</h1>
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
          <td>{{convertDateTime(booking.time)}}</td>
          <td>{{booking.seats}}</td>
          <td>{{booking.customerName}}</td>
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
      searchEmail: "",
      displayEmailSearch: false,
      displayCalendarSearch: false,
      dateSelected: new Date(),
      displayEmailSearchPicker: true,
      displayCalendarSearchPicker: true,
      today: new Date(this.getTodayDate()),
      themeStyles: {
        wrapper: {
          background: "rgb(200, 200, 200)",
          color: "black",
          borderRadius: "0px",
          boxShadow:
            "0 4px 8px 0 rgba(0, 0, 0, 0.14), 0 6px 20px 0 rgba(0, 0, 0, 0.13)"
        },
        header: {
          color: "white",
          padding: `2px`,
          background: "linear-gradient(to right, #000099, #8080ff)"
        },
        headerHorizontalDivider: {
          borderTop: "solid rgba(255, 255, 255, 0.2) 1px",
          width: "80%"
        },
        highlight: {
          backgroundColor: "black"
        }
      }
    };
  },
  methods: {
    updateAndSave() {
      this.displayModal = false;
      this.getBookingsByDate();
    },
    toggleSearch() {
      if (this.displayEmailSearch) {
        this.displayEmailSearch = false;
      } else {
        this.displayEmailSearch = true;
      }
    },
    toggleCalendarSearch() {
      if (this.displayCalendarSearch) {
        this.displayCalendarSearch = false;
      } else {
        this.displayCalendarSearch = true;
      }
    },
    openModal(booking) {
      this.displayModal = true;
      this.$store.state.time = booking.time;
      this.$store.state.guests = booking.seats;
      this.$store.state.name = booking.customerName;
      this.$store.state.email = booking.email;
      this.$store.state.phoneNumber = booking.phoneNumber;
      this.$store.state.id = booking.id;
      console.log(this.$store.state.time);
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
          this.getBookingsByDate();
        })
        .catch(error => {
          console.log(error);
        });
    },
    getBookingsByDate() {
      console.log("date: " + this.dateSelected);
      getByDate(formatTime(this.dateSelected))
        .then(response => {
          this.bookings = response.bookings;
          console.log(this.bookings[0].time);
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
      var month = x.getMonth() + 1;
      var year = x.getFullYear();
      var weekday = new Array(7);
      weekday[0] = "Sund";
      weekday[1] = "Mon";
      weekday[2] = "Tue";
      weekday[3] = "Wed";
      weekday[4] = "Thu";
      weekday[5] = "Fri";
      weekday[6] = "Sat";
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
    },
    getTodayDate() {
      var day = new Date().getDate();
      var month = new Date().getMonth() + 1;
      var year = new Date().getFullYear();

      if (day < 10) {
        day = "0" + day;
      }

      if (month < 10) {
        month = "0" + month;
      }

      var fullDateString = year + "-" + month + "-" + day;
      return fullDateString;
    }
  },
  created() {
    this.getBookingsByDate(this.getTodayDate());
  },
  mounted() {
    self = this;
    self.$watch(
      () => {
        return this.dateSelected;
      },
      (newDate, oldDate) => {
        this.getBookingsByDate();
        this.displayCalendarSearch = false;
      }
    );
    this.$watch(
      () => {
        return this.bookings;
      },
      (newBooking, oldBooking) => {
        this.bookings.sort((b, a) => a.time.localeCompare(b.time));
      }
    );
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
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
  background: rgb(212, 45, 45);
  z-index: 100;
  position: absolute;
}

.headerbar {
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}

.search {
  font-size: 1.5em;
}

.star {
  font-size: 2em;
}
</style>
