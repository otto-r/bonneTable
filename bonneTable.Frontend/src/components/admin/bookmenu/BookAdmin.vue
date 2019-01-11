<template>
  <div class="container-fluid col-8">
    <div class="centered" v-if="loading">
      <div class="headerw95">Ｌｏａｄｉｎｇ．．</div>.
      <div class="bgloading">
        <b-img src="/static/win.png"/>
      </div>
      <br>
    </div>
    <div class="headerw95 row mt-3">
      <div class="col-12 px-1">
        <div class="float-left">Ｂｏｏｋ</div>
        <div class="float-right">
          <span class="clickable" @click="changeStep(1)">
            <span class="slash">📅:</span>
            {{convertDateTime(bookingRequest.time)}}
          </span>
          <span class="clickable" @click="changeStep(2)">
            <span class="slash">{{guestsEmoji()}}:</span>
            {{guestsToDisplay()}}
          </span>
          <span class="clickable" @click="changeStep(3)">
            <span class="slash">{{clockEmoji()}}:</span>
            {{timeDisplay()}}
          </span>
        </div>
      </div>
    </div>
    <div class="row bgbody pt-2">
      <Calendar v-if="displayCalendar" @toguests="pickDate($event)"></Calendar>
      <Guests v-if="displayGuests" @toTime="pickGuests($event)"></Guests>
      <Time v-if="displayTime" @toConfirm="pickTime($event)"></Time>
      <Confirm
        :confProp="confirmInfo"
        v-if="displayConfirm"
        @updateConfInfo="onChangeUpdate($event)"
        @finalizeBooking="pickConfirmInfo($event)"
      ></Confirm>
      <div v-if="bookingSuccess">
        <div class="row">
          <div class="mx-4">
            <h2 style="color: black">Ｂｏｏｋｉｎｇ Ｓｕｃｃｅｓｓｆｕｌ</h2>
          </div>
          <button class="mx-auto" @click="newBooking()">Ｎｅｗ Ｂｏｏｋｉｎｇ</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Calendar from "../bookmenu/Calendar";
import Guests from "../bookmenu/Guests";
import Time from "../bookmenu/Time";
import Confirm from "../bookmenu/Confirm";
import { adminBook } from "@/api/BookingAPI";
import { getClockEmoji } from "@/api/EmojiHelper";

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
      confirmBooking: "",
      loading: false,
      bookingSuccess: false,
      displayCalendar: true,
      displayGuests: false,
      displayTime: false,
      displayConfirm: false,
      timeToAppend: new Date(),
      confirmInfo: {
        customerName: "",
        phoneNumber: "",
        email: ""
      },
      bookingRequest: {
        time: null,
        seats: null,
        customerName: null,
        phoneNumber: null,
        email: null
      }
    };
  },
  methods: {
    newBooking() {
      this.$emit("newBooking");
      this.displayCalendar = true;
      this.bookingSuccess = false;
    },
    changeStep(step) {
      if (step === 1) {
        this.displayCalendar = true;
        this.displayGuests = false;
        this.displayTime = false;
        this.displayConfirm = false;
      }
      if (step === 2) {
        this.displayCalendar = false;
        this.displayGuests = true;
        this.displayTime = false;
        this.displayConfirm = false;
      }
      if (step === 3) {
        this.displayCalendar = false;
        this.displayGuests = false;
        this.displayTime = true;
        this.displayConfirm = false;
      }
    },
    pickDate(datePicked) {
      this.bookingRequest.time = datePicked;
      this.toGuests();
    },
    pickGuests(guests) {
      this.bookingRequest.seats = guests;
      this.toTime();
    },
    pickTime(timeToAppend) {
      this.bookingRequest.time.setHours(timeToAppend.hours + 1);
      this.bookingRequest.time.setMinutes(timeToAppend.minutes);
      this.toConfirm();
    },
    pickConfirmInfo(Info) {
      this.bookingRequest.customerName = Info.customerName;
      this.bookingRequest.email = Info.email;
      this.bookingRequest.phoneNumber = Info.phoneNumber;

      this.loading = true;
      adminBook(this.bookingRequest)
        .then(response => {
          this.bookingSuccess = true;
          this.displayConfirm = false;
          this.loading = false;
          this.resetBookingRequest();
          console.log(response.data);
        })
        .catch(error => {
          this.loading = false;
          console.log(error);
        });
    },
    onChangeUpdate(Info) {
      this.bookingRequest.customerName = Info.customerName;
      this.bookingRequest.email = Info.email;
      this.bookingRequest.phoneNumber = Info.phoneNumber;

      this.confirmInfo.customerName = Info.customerName;
      this.confirmInfo.phoneNumber = Info.phoneNumber;
      this.confirmInfo.email = Info.email;
    },
    resetBookingRequest() {
      (this.bookingRequest.time = null),
        (this.bookingRequest.seats = null),
        (this.bookingRequest.customerName = null),
        (this.bookingRequest.phoneNumber = null),
        (this.bookingRequest.email = null);
    },
    toGuests() {
      this.displayCalendar = false;
      this.displayGuests = true;
    },
    toTime() {
      (this.displayGuests = false), (this.displayTime = true);
    },
    toConfirm() {
      (this.displayTime = false), (this.displayConfirm = true);
    },
    toSuccess() {},
    convertDateTime(date) {
      if (date == null) {
        return "~";
      }
      var x = new Date(date);
      var date = x.getDate();
      var month = x.getMonth() + 1;
      return date + "/" + month;
    },
    timeDisplay() {
      if (
        this.bookingRequest.time === null ||
        this.bookingRequest.time === undefined
      ) {
        return "~";
      }
      if (this.bookingRequest.time.getHours() === 0) {
        return "~";
      }

      let time =
        this.bookingRequest.time.getHours() -
        1 +
        ":" +
        this.bookingRequest.time.getMinutes();

      if (this.bookingRequest.time.getMinutes() === 0) {
        time += "0";
      }

      return time;
    },
    guestsToDisplay() {
      if (this.bookingRequest.seats == null) {
        return "~";
      }
      return this.bookingRequest.seats;
    },
    clockEmoji() {
      return getClockEmoji(this.bookingRequest.time);
    },
    guestsEmoji() {
      if (this.bookingRequest.seats > 1) {
        return "👥";
      }
      return "👤";
    }
  },
  created() {},
  mounted() {}
};
</script>

<style scoped>
.bgbody {
  /* height: auto; */
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
  /* padding: 0 0 0 0; */
  background-color: rgb(200, 200, 200);
  min-height: 300px;
}

.bgloading {
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
  /* padding: 0 0 0 0; */
  background-color: rgb(200, 200, 200);
  z-index: 11999;
  margin: 0 0 0 0;
}

.backdrop {
  /* margin: 5px; */
  background-color: rgb(200, 200, 200);
  padding: 0 0 0 0;
}

.headerw95 {
  height: auto;
  /* margin: 0px 0px 0px 0px; */
  padding: 5px 0px 5px 0px;
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

.clickable {
  cursor: pointer;
}

.clickable:hover {
  opacity: 0.5;
}

.centered {
  position: fixed;
  top: 50%;
  left: 50%;
  margin-top: -74px;
  margin-left: -92px;
  z-index: 11000;
  font-weight: bold;
  color: black;
}
</style>
