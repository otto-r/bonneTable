<template>
  <div class="mx-auto fontz col-8">
    <div class="form-group" :class="{'has-error': errors.any() }">
      <label class="control-label mb-0" for="Name">Name</label>
      <input
        class="w98input"
        :class="{'input': true, 'is-invalid': errors.has('Name') }"
        v-model="confirmInfo.customerName"
        v-validate="'required|min:2'"
        name="Name"
        type="text"
        placeholder="Name"
      >
      <p class="text-danger" v-if="errors.has('Name')">{{ errors.first('Name') }}</p>
    </div>
    <div class="form-group" :class="{'has-error': errors.any() }">
      <label class="control-label mb-0" for="Email">Email</label>
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
      <label class="control-label mb-0" for="PhoneNumber">Phone Number</label>
      <input
        class="w98input"
        :class="{'input': true, 'is-invalid': errors.has('PhoneNumber') }"
        v-model="confirmInfo.phoneNumber"
        v-validate="'required|numeric|min:6'"
        name="PhoneNumber"
        type="text"
        placeholder="PhoneNumber"
      >
      <p class="text-danger" v-if="errors.has('PhoneNumber')">{{ errors.first('PhoneNumber') }}</p>
    </div>
    <button class="mx-auto mb-3" @click="book()">Book</button>
    <div v-if="!errorMsg.success">⚠️Error: {{errorMsg.text}}</div>
  </div>
</template>

<script>
import { book } from "@/api/BookingAPI";

export default {
  name: "Confirm",
  props: {
    confProp: { type: Object },
    errorMsg: { type: Object }
  },
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
      console.log("BOOK: " + this.confirmInfo.email);
      this.$emit("finalizeBooking", this.confirmInfo);
    }
  },
  created() {},
  mounted() {
    this.confirmInfo.customerName = this.confProp.customerName;
    this.confirmInfo.phoneNumber = this.confProp.phoneNumber;
    this.confirmInfo.email = this.confProp.email;
    this.$watch(
      () => {
        return this.confirmInfo.customerName;
      },
      (newConf, oldConf) => {
        this.$emit("updateConfInfo", this.confirmInfo);
      }
    );
    this.$watch(
      () => {
        return this.confirmInfo.phoneNumber;
      },
      (newConf, oldConf) => {
        this.$emit("updateConfInfo", this.confirmInfo);
      }
    );
    this.$watch(
      () => {
        return this.confirmInfo.email;
      },
      (newConf, oldConf) => {
        this.$emit("updateConfInfo", this.confirmInfo);
      }
    );
  }
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
