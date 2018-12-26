<template>
  <div class="mt-3">
    <div class="form-group" :class="{'has-error': errors.any() }">
      <input
        class="form-control"
        :class="{'input': true, 'is-invalid': errors.has('Name') }"
        v-model="name"
        v-validate="'required'"
        name="Name"
        required=''
        type="text"
      >
      <label alt='Enter Your Name' placeholder='Name' class="control-label" for="Name"></label>
      <p class="text-danger" v-if="errors.has('Name')">{{ errors.first('Name') }}</p>
    </div>
    <div class="form-group" :class="{'has-error': errors.any() }">
      <input
        class="form-control"
        :class="{'input': true, 'is-invalid': errors.has('Email') }"
        v-model="email"
        v-validate="'required|email'"
        name="Email"
        required=''
        type="text"
      >
      <label alt='Type your Email' placeholder='Email' class="control-label" for="Email"></label>
      <p class="text-danger" v-if="errors.has('Email')">{{ errors.first('Email') }}</p>
    </div>
    <div class="form-group" :class="{'has-error': errors.any() }">
      <input
        class="form-control"
        :class="{'input': true, 'is-invalid': errors.has('PhoneNumber') }"
        v-model="phoneNumber"
        v-validate="'required|numeric'"
        name="PhoneNumber"
        required=''
        type="text"
      >
      <label alt='Enter Your PhoneNumber' placeholder='Phone Number' class="control-label" for="PhoneNumber"></label>
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

html, body {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 100%;
}

input[type="text"] {
  box-sizing: border-box;
  width: 100%;
  height: calc(4em + 1px);
  margin: 0 0 1em;
  padding: 1em;
  border: 1px solid #ccc;
  background: #fff;
  resize: none;
  outline: none;
}

input[type="text"][required]:focus {
  border-color: rgb(243, 81, 105);
  box-shadow: 0 0 10px rgb(243, 81, 105);
}
input[type="text"][required]:focus + label[placeholder]:before {
  color: rgb(243, 81, 105);
}
input[type="text"][required]:focus + label[placeholder]:before,
input[type="text"][required]:valid + label[placeholder]:before {
  transition-duration: .2s;
  transform: translate(0, -1.5em) scale(0.9, 0.9);
}

input[type="text"][required]:invalid + label[placeholder][alt]:before {
  content: attr(alt);
}

input[type="text"][required] + label[placeholder] {
  display: block;
  pointer-events: none;
  line-height: 1em;
  margin-top: calc(-3em - 2px);
  margin-bottom: calc((3em - 1em) + 2px);
}

input[type="text"][required] + label[placeholder]:before {
  content: attr(placeholder);
  display: inline-block;
  margin: 0 calc(1em + 2px);
  padding: 0 2px;
  color: #898989;
  white-space: nowrap;
  transition: 0.3s ease-in-out;
  background-image: linear-gradient(to bottom, #fff, #fff);
  background-size: 100% 5px;
  background-repeat: no-repeat;
  background-position: center;
}
</style>
