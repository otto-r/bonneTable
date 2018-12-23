<template>
  <div class="mx-auto col-7 fontz">
    <div class="form-group" :class="{'has-error': errors.any() }">
      <label class="control-label" for="Name">Name</label>
      <input
        class="w98input"
        :class="{'input': true, 'is-invalid': errors.has('Name') }"
        v-model="confirmInfo.customerName"
        v-validate="'required'"
        name="Name"
        type="text"
        placeholder="Name"
      >
      <p class="text-danger" v-if="errors.has('Name')">{{ errors.first('Name') }}</p>
    </div>
    <div class="form-group" :class="{'has-error': errors.any() }">
      <label class="control-label" for="Email">Email</label>
      <input
        class="w98input"
        :class="{'input': true, 'is-invalid': errors.has('Email') }"
        v-model="confirmInfo.email"
        v-validate="'required|email'"
        name="Email"
        type="text"
        placeholder="Email"
      >
      <p class="text-danger" v-if="errors.has('Email')">{{ errors.first('Email') }}</p>
    </div>
    <div class="form-group" :class="{'has-error': errors.any() }">
      <label class="control-label" for="PhoneNumber">Phone Number</label>
      <input
        class="w98input"
        :class="{'input': true, 'is-invalid': errors.has('PhoneNumber') }"
        v-model="confirmInfo.phoneNumber"
        v-validate="'required|numeric'"
        name="PhoneNumber"
        type="text"
        placeholder="PhoneNumber"
      >
      <p class="text-danger" v-if="errors.has('PhoneNumber')">{{ errors.first('PhoneNumber') }}</p>
    </div>
    <button class="mx-auto" @click="book()">Book</button>
  </div>
</template>

<script>
import { book } from "@/api/BookingAPI";

export default {
  name: "Confirm",
  data() {
    return {
      confirmInfo: {
        customerName: "",
        phoneNumber: "",
        email: ""
      }
    };
  },
  methods: {
    book() {
      this.$emit("finalizeBooking", this.confirmInfo);
    }
  },
  created() {}
};
</script>

<style scoped>
.w98input {
  margin: 0px 0px 0px 0px;
  width: 100%;
  padding: 5px;
  background: white;
  color: black;
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}

.fontz {
  color: black;
  font-family: Helvetica, Arial, sans-serif;
}
</style>
