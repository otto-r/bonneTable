<template>
  <div class="mt-3 mx-auto">
    <p>
      <b-button @click="setTime('16:00:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">16:00</b-button>
      <b-button @click="setTime('16:30:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">16:30</b-button>
      <b-button @click="setTime('17:00:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">17:00</b-button>
    </p>
    <p>
      <b-button @click="setTime('17:30:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">17:30</b-button>
      <b-button @click="setTime('18:00:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">18:00</b-button>
      <b-button @click="setTime('18:30:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">18:30</b-button>
    </p>
    <p>
      <b-button @click="setTime('19:00:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">19:00</b-button>
      <b-button @click="setTime('19:30:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">19:30</b-button>
      <b-button @click="setTime('20:00:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">20:00</b-button>
    </p>
    <p>
      <b-button @click="setTime('20:30:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">20:30</b-button>
      <b-button @click="setTime('21:00:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">21:00</b-button>
      <b-button @click="setTime('21:30:00')" class="btn btn-lg btn-outline-primary btn-pink mr-1">21:30</b-button>
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
