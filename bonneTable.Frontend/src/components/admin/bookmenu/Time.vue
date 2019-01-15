<template>
  <div class="mx-auto fontz">
    <p>
      <button @click="setTime({hours: 16, minutes: 0})">16:00</button>
      <button @click="setTime({hours: 16, minutes: 30})">16:30</button>
      <button @click="setTime({hours: 17, minutes: 0})">17:00</button>
    </p>
    <p>
      <button @click="setTime({hours: 17, minutes: 30})">17:30</button>
      <button @click="setTime({hours: 18, minutes: 0})">18:00</button>
      <button @click="setTime({hours: 18, minutes: 30})">18:30</button>
    </p>
    <p>
      <button @click="setTime({hours: 19, minutes: 0})">19:00</button>
      <button @click="setTime({hours: 19, minutes: 30})">19:30</button>
      <button @click="setTime({hours: 20, minutes: 0})">20:00</button>
    </p>
    <p>
      <button @click="setTime({hours: 20, minutes: 30})">20:30</button>
      <button @click="setTime({hours: 21, minutes: 0})">21:00</button>
      <button @click="setTime({hours: 21, minutes: 30})">21:30</button>
    </p>
  </div>
</template>

<script>
export default {
  name: "Time",
  data() {
    return {};
  },
  methods: {
    setTime(time) {
      this.$emit("toConfirm", time);
    }
  },
  created() {}
};
</script>

<style scoped>
</style>
