<template>
  <div class="mt-3 mx-auto">
    <p>
      <b-button @click="setTime({hours: 16, minutes: 0})" class="btn btn-lg btn-outline-primary btn-pink mr-1">16:00</b-button>
      <b-button @click="setTime({hours: 16, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">16:30</b-button>
      <b-button @click="setTime({hours: 17, minutes: 0})" class="btn btn-lg btn-outline-primary btn-pink mr-1">17:00</b-button>
    </p>
    <p>
      <b-button @click="setTime({hours: 17, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">17:30</b-button>
      <b-button @click="setTime({hours: 18, minutes: 0})" class="btn btn-lg btn-outline-primary btn-pink mr-1">18:00</b-button>
      <b-button @click="setTime({hours: 18, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">18:30</b-button>
    </p>
    <p>
      <b-button @click="setTime({hours: 19, minutes: 0})" class="btn btn-lg btn-outline-primary btn-pink mr-1">19:00</b-button>
      <b-button @click="setTime({hours: 19, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">19:30</b-button>
      <b-button @click="setTime({hours: 20, minutes: 0})" class="btn btn-lg btn-outline-primary btn-pink mr-1">20:00</b-button>
    </p>
    <p>
      <b-button @click="setTime({hours: 20, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">20:30</b-button>
      <b-button @click="setTime({hours: 21, minutes: 0})" class="btn btn-lg btn-outline-primary btn-pink mr-1">21:00</b-button>
      <b-button @click="setTime({hours: 21, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">21:30</b-button>
    </p>
  </div>
</template>

<script>
export default {
  name: 'TimeSelect',
  data () {
    return {

    }
  },
  methods: {
    setTime(time) {
      this.$store.commit("setTime", time);
      this.$router.push({ path: "/book/confirm" });
    }
  }
}
</script>

<style scoped>

</style>
