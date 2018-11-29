<template>
  <div>
    <div class='container-fluid mt-3'>
        <div class='row'>
            <div class="col-4 mx-auto">
                <b-button-group>
                    <b-button click="dateClick(this)">Date</b-button>
                    <b-button>Guests</b-button>
                    <b-button>Time</b-button>
                    <b-button>Confirm</b-button>
                </b-button-group>
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
        date: 'no'

    }
  },
  methods:{
      dateClick(button){
          button.disabled = false;
      }
}
}
</script>

<style scoped>

</style>
