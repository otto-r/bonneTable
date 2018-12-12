<template>
  <div>
    <div class="container-fluid mt-3">
      <div class="row">
        <div class="col-4 mx-auto">
          <h5>BonneTable</h5>
          <b-button-group>
            <b-button @click="dateClick()">{{dateDisplay}}</b-button>
            <b-button @click="guestsClick()">{{guestsDisplay}}</b-button>
            <b-button @click="timeClick()">{{timeDisplay}}</b-button>
            <b-button @click="confirmClick()">Confirm</b-button>
          </b-button-group>
          <router-view></router-view>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DateSelect from "../components/DateSelect.vue";
import GuestsSelect from "../components/GuestsSelect.vue";
import TimeSelect from "../components/TimeSelect.vue";
import ConfirmSelect from "../components/ConfirmSelect.vue";

export default {
  name: "Book",
  data() {
    return {
      
    };
  },
  created() {
    this.$router.push({ path: "/book/date" });
  },
  computed:{
    dateDisplay: function () {
      if (!this.$store.state.date){
        return 'Date';
      }
      var date = this.$store.state.date;
      var formattedDate = date.toDateString();
      return formattedDate;
    },
    guestsDisplay: function () {
      if (!this.$store.state.guests){
        return 'Guests';
      }
      var guests = this.$store.state.guests;
      return 'Guests: ' + guests;
    },
    timeDisplay: function () {
      if (!this.$store.state.time){
        return 'Time';
      }
      var time = this.$store.state.time.hours + ':' + this.$store.state.time.minutes;
      return time;
    }
  },
  methods: {
    dateClick() {
      self = this;

      self.$router.push({ path: "/book/date" });
    },
    guestsClick() {
      self = this;

      self.$router.push({ path: "/book/guests" });
    },
    timeClick() {
      self = this;

      self.$router.push({ path: "/book/time" });
    },
    confirmClick() {
      self = this;

      self.$router.push({ path: "/book/confirm" });
    }
  }
};
</script>

<style>
.col-4{
    text-align:center;
    border: 2px solid blue;
    border-radius: 12px;
    margin: 0 auto;
    padding: 10px 0 20px;
    margin-top: 10px;
}
h5{
    width:25%;
    background:white;
    margin-top:-1.5rem;
    margin-left:5px;
}

.btn-pink {
  color: #ff66b3 !important;
  border-color: #ff66b3 !important;
}
.btn-pink:hover {
  color: #ffffff !important;
  background-color: #ff66b3 !important;
}
.btn-pink-filled{
  color: #ffffff !important;
  border-color: #ff66b3 !important;
  background-color: #ff66b3 !important;
}
.btn-pink-filled:hover{
  background-color: #fd3d9d !important;
  border-color: #fd3d9d !important;
}
</style>
