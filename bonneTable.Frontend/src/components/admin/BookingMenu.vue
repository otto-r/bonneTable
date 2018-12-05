<template>
  <div>
    <h1>Booking Menu</h1>

    <button @click="consoleSeats()">TEST</button>
          <div>
            <input
              type="text"
              placeholder="Name"
              name="numberOfSeats"
              v-model="numberOfseats"
              v-validate="'required|numeric'"
            >

            <span v-if="errors.has('name')">{{ errors.first('name') }}</span>
          </div>
  </div>
</template>

<script>
export default {
  name: 'BookingMenu',
  data () {
    return {

    }
  }
}
</script>

<style scoped>

</style>
