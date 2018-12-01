<template>
  <div>
    <h1>Admin</h1>
  </div>
</template>

<script>
import { getAll, book, getByDate } from "@/api/BookingAPI";

export default {
  name: "Admin",
  data() {
    return {
      requestTest: {
        time: "12-11-2018 12:00:00",
        Seats: 2,
        customerName: "Otto",
        PhoneNumber: "0808076054",
        Email: "otto@emailz.gg"
      }
    };
  },
  methods: {
    async printReturnINfo() {
      console.log(this.requestTest.time);
      var data = await getByDate(this.requestTest.time);
      console.log(data);
    }
  },
  created() {
    this.printReturnINfo();
  }
};
</script>

<style scoped>
</style>
