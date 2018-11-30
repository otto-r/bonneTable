<template>
  <div>
    <div class='container-fluid mt-3'>
        <div class='row'>
            <div class="col-4 mx-auto">
                <b-button-group>
                    <b-button :disabled="dateButtonDisabled" @click="dateClick()">Date</b-button>
                    <b-button :disabled="guestsButtonDisabled" @click="guestsClick()">Guests</b-button>
                    <b-button :disabled="timeButtonDisabled" @click="timeClick()">Time</b-button>
                    <b-button :disabled="confirmButtonDisabled" @click="confirmClick()">Confirm</b-button>
                <router-view></router-view>
            </div>
        </div>
    </div>
  </div>
</template>

<script>
import DateSelect from '../components/DateSelect.vue'
import GuestsSelect from '../components/GuestsSelect.vue'
import TimeSelect from '../components/TimeSelect.vue'
import ConfirmSelect from '../components/ConfirmSelect.vue'

export default {
  name: 'Book',
  data () {
    return {
        dateButtonDisabled: true,
        guestsButtonDisabled: false,
        timeButtonDisabled: false,
        confirmButtonDisabled: false,

    }
  },
  methods:{
      dateClick(){
          self = this;

          this.dateButtonDisabled = true;
          this.guestsButtonDisabled = false;
          this.timeButtonDisabled = false;
          this.confirmButtonDisabled = false;

          self.$router.push({path: '/book/date'});
      },
      guestsClick(){
          self = this;

          this.dateButtonDisabled = false;
          this.guestsButtonDisabled = true;
          this.timeButtonDisabled = false;
          this.confirmButtonDisabled = false;

          self.$router.push({path: '/book/guests'});
      },
      timeClick(){
          self = this;

          this.dateButtonDisabled = false;
          this.guestsButtonDisabled = false;
          this.timeButtonDisabled = true;
          this.confirmButtonDisabled = false;

          self.$router.push({path: '/book/time'});
      },
      confirmClick(){
          self = this;

          this.dateButtonDisabled = false;
          this.guestsButtonDisabled = false;
          this.timeButtonDisabled = false;
          this.confirmButtonDisabled = true;

          self.$router.push({path: '/book/confirm'});
      }
    }
}
</script>

<style scoped>

</style>
