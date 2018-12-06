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
export default {
  name: "ConfirmSelect",
  data() {
    return {
      name: null,
      email: null,
      phoneNumber: null
    };
  },
  methods: {
    validateInput() {
      let self = this;
      self.$validator.validate().then(result => {
        if (result) {
          self.book();
        }
      });
    },
    book() {
      console.log('booked');
    }
  }
};
</script>

<style scoped>
</style>
