<template>
  <div>
    <h1>Admin</h1>
    <h3>{{ date }}</h3>
    <div class="List">
      <!-- <input type="text" placeholder="Enter item name here..." v-model="item"> -->
      <ul>
        <li
          v-for="(list, index) in list"
          :key="index"
        >{{ list.customerName }} - {{ convertDate(list.time) }}</li>
      </ul>
    </div>
  </div>
</template>

<script>
import { getAll, book, getByDate, getByEmail, cancel } from "@/api/BookingAPI";
import { formatTime } from "@/api/TimeFormatter";

export default {
  name: "Admin",
  data() {
    return {
      date: " ",
      list: [{ item: "hej" }, { item: "hej2" }],
      requestTest: {
        // time: "12-11-2018 12:00:00",
        time: formatTime(new Date()),
        Seats: 2,
        customerName: "Otto",
        PhoneNumber: "0808076054",
        Email: "otto@emailz.gg"
      }
    };
  },
  methods: {
    async deleter() {
      await cancel("639d6164!c010!487f!9a13!6a53707b644e");
    },
    async printReturnINfo() {
      console.log(formatTime(new Date()))
      var data = await getByEmail(this.requestTest.Email)
      // var data = await getByDate(this.requestTest.time);
      // var data = await getAll();
      console.log(data.bookings);
      this.list = data.bookings;
    },
    convertDate(dateTime) {
      var date = new Date(dateTime);
      var hours = date.getHours();
      var minutes = date.getMinutes();
      if (minutes < 10) {
        minutes += "0";
      }
      return hours + ":" + minutes;
    }
  },
  created() {
    this.printReturnINfo();
    // this.deleter();
  }
};
</script>

<style scoped>
@import "https://cdn.jsdelivr.net/npm/animate.css@3.5.1";
@import "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css";

.holder {
  background: #fff;
}

ul {
  margin: 0;
  padding: 0;
  list-style-type: none;
}

ul li {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  border-left: 5px solid #3eb3f6;
  margin-bottom: 2px;
  color: #3e5252;
}

p {
  text-align: center;
  padding: 30px 0;
  color: gray;
}

.container {
  box-shadow: 0px 0px 40px lightgray;
}

input {
  width: calc(100% - 40px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  background-color: #323333;
  color: #687f7f;
}
.alert {
  background: #fdf2ce;
  font-weight: bold;
  display: inline-block;
  padding: 5px;
  margin-top: -20px;
}

.alert-in-enter-active {
  animation: bounce-in 0.5s;
}
.alert-in-leave-active {
  animation: bounce-in 0.5s reverse;
}

@keyframes bounce-in {
  0% {
    transform: scale(0);
  }
  50% {
    transform: scale(1.5);
  }
  100% {
    transform: scale(1);
  }
}

i {
  float: right;
  cursor: pointer;
}
</style>
