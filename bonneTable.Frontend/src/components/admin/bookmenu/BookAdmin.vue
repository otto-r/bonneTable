<template>
  <div class="backdrop col-8 mx-auto">
    <div class="headerw95">Ｂｏｏｋ
      <div class="float-right">
        -
        <span class="slash">／</span>
        {{convertDateTime($store.state.date)}}
        <span class="slash">／</span>
        {{$store.state.guests}}
        <span class="slash">／</span>
        {{timeDisplay()}}
      </div>
    </div>
    <div class="bgbody">
      <div class="row">
        <Calendar v-if="displayCalendar" @toguests="toGuests()"></Calendar>
        <Guests v-if="displayGuests" @toTime="toTime()"></Guests>
        <Time v-if="displayTime" @toConfirm="toConfirm()"></Time>
        <Confirm v-if="displayConfirm"></Confirm>
      </div>
    </div>
  </div>
</template>

<script>
import Calendar from "../bookmenu/Calendar";
import Guests from "../bookmenu/Guests";
import Time from "../bookmenu/Time";
import Confirm from "../bookmenu/Confirm";

export default {
  name: "BookAdmin",
  components: {
    Calendar,
    Guests,
    Time,
    Confirm
  },
  data() {
    return {
      displayCalendar: true,
      displayGuests: false,
      displayTime: false,
      displayConfirm: false
    };
  },
  methods: {
    toGuests() {
      console.log("to guests!");
      console.log(this.$store.state.date);
      this.displayCalendar = false;
      this.displayGuests = true;
    },
    toTime() {
      (this.displayGuests = false), (this.displayTime = true);
    },
    toConfirm() {
      (this.displayTime = false), (this.displayConfirm = true);
    },
    convertDateTime(date) {
      var x = new Date(date);
      var date = x.getDate();
      var month = x.getMonth() + 1;
      return date + "/" + month + "/";
    },
    timeDisplay() {
      let time =
        this.$store.state.time.hours + ":" + this.$store.state.time.minutes;

      return time;
    }
  },
  created() {},
  mounted() {
    this.$watch(
      () => {
        return this.$store.state.date;
      },
      (newDate, oldDate) => {
        (this.displayCalendar = false), (this.displayGuests = true);
      }
    );
  }
};
</script>

<style scoped>
.bgbody {
  height: auto;
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
  padding: 0 0 0 0;
}

.backdrop {
  background-color: rgb(200, 200, 200);
  padding: 0 0 0 0;
  height: 350px;
}

.headerw95 {
  height: auto;
  margin: 0px 0px 0px 0px;
  padding: 5px 5px;
  color: white;
  background: linear-gradient(to right, #000099, #8080ff);
  font-size: 1.2em;
  line-height: 16px;
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}

.slash {
  color: black;
  font-weight: bold;
}
</style>
