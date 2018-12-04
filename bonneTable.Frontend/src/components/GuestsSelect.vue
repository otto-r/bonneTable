<template>
  <div class="mt-3">
    <p>
      <b-button @click="setGuests(1)" class="btn btn-lg btn-outline-primary btn-pink mr-1">1</b-button>
      <b-button @click="setGuests(2)" class="btn btn-lg btn-outline-primary btn-pink mr-1">2</b-button>
      <b-button @click="setGuests(3)" class="btn btn-lg btn-outline-primary btn-pink mr-1">3</b-button>
    </p>
    <p>
      <b-button @click="setGuests(4)" class="btn btn-lg btn-outline-primary btn-pink mr-1">4</b-button>
      <b-button @click="setGuests(5)" class="btn btn-lg btn-outline-primary btn-pink mr-1">5</b-button>
      <b-button @click="setGuests(6)" class="btn btn-lg btn-outline-primary btn-pink mr-1">6</b-button>
    </p>
  </div>
</template>

<script>
export default {
  name: "GuestsSelect",
  data() {
    return {};
  },
  methods: {
    setGuests(guests) {
      this.$store.commit("setGuests", guests);
      this.$router.push({ path: "/book/time" });
    }
  }
};
</script>

<style scoped>
</style>
