<template>
  <div class="mx-auto fontz">
    <p>
      <button @click="toTime(1)">１</button>
      <button @click="toTime(2)">２</button>
      <button @click="toTime(3)">３</button>
    </p>
    <p>
      <button @click="toTime(4)">４</button>
      <button @click="toTime(5)">５</button>
      <button @click="toTime(6)">６</button>
    </p>
    <p>
      <button @click="toTime(7)">７</button>
      <button @click="toTime(8)">８</button>
      <button @click="toTime(9)">９</button>
    </p>
  </div>
</template>

<script>
export default {
  name: "Guests",
  data() {
    return {};
  },
  methods: {
    toTime(guests) {
      this.$emit("toTime", guests);
    }
  },
  created() {}
};
</script>

<style scoped>
.fontz {
  font-size: 2em;
}
</style>
