<template>
  <div class="mt-3">
    <div class="form-group" :class="{'has-error': errors.any() }">
      <label class="control-label" for="Name">Name</label>
      <input
        class="form-control"
        :class="{'input': true, 'is-invalid': errors.has('Name') }"
        v-model="name"
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
        class="form-control"
        :class="{'input': true, 'is-invalid': errors.has('Email') }"
        v-model="email"
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
        class="form-control"
        :class="{'input': true, 'is-invalid': errors.has('PhoneNumber') }"
        v-model="phoneNumber"
        v-validate="'required|numeric'"
        name="PhoneNumber"
        type="text"
        placeholder="PhoneNumber"
      >
      <p class="text-danger" v-if="errors.has('PhoneNumber')">{{ errors.first('PhoneNumber') }}</p>
    </div>
    <button class="btn btn-pink-filled submit" @click="validateInput">Book</button>
  </div>
</template>

<script>
import { book } from "@/api/BookingAPI";

export default {
  name: "ConfirmSelect",
  data() {
    return {
      name: null,
      email: null,
      phoneNumber: null,
      bookingRequestModel: { 
        time: null, 
        seats: null, 
        customerName: null, 
        phoneNumber: null, 
        email: null 
      }
    };
  },
  methods: {
    validateInput() {
      let self = this;
      self.$validator.validate().then(result => {
        if (result) {
          self.confirmBook();
        }
      });
    },
    confirmBook() {
      self = this;
      self.bookingRequestModel.time = self.$store.state.date;
      self.bookingRequestModel.time.setHours(self.$store.state.time.hours + 1);
      self.bookingRequestModel.time.setMinutes(self.$store.state.time.minutes);
      self.bookingRequestModel.seats = self.$store.state.guests;
      self.bookingRequestModel.customerName = self.name;
      self.bookingRequestModel.phoneNumber = self.phoneNumber;
      self.bookingRequestModel.email = self.email;

      console.log(self.bookingRequestModel);
      
      book(self.bookingRequestModel)
      .then(response => {
          console.log(response);
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style scoped>
input{
  margin: 0 100px 0 0px;
}
</style>
