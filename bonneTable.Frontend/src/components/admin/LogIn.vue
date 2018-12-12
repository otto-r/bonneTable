<template>
  <div>
    <div class="form">
    <div class="form-group">
      <label for="username">Username:</label>
      <input
        v-validate="'alpha|required'"
        v-model="userInfo.username"
        data-vv-as="field"
        name="username"
        placeholder="Username"
        type="text"
        class="form-control"
        :class="{'alert-danger': errors.has('username')}"
      >
    </div>
    <div class="form-group">
      <label for="password">Password:</label>
      <input
        v-validate="'required'"
        v-model="userInfo.password"
        data-vv-as="field"
        name="password"
        placeholder="Password"
        type="text"
        class="form-control"
        :class="{'alert-danger': errors.has('password')}"
      >
    </div>
    <b-button class="btn btn-default" @click="validateInput()">Log In</b-button>
    </div>
  </div>
</template>

<script>
import { getToken } from "@/api/Authentication.js";

export default {
  name: "LogIn",
  data() {
    return {
      logInFailure: false,
      userInfo: { username: "", password: "" }
    };
  },
  methods: {
    logIn() {
      getToken(this.userInfo)
        .then(response => {
          console.log(response);
          localStorage.token = response.token
          localStorage.loggedIn = true;
          console.log(localStorage.loggedIn)
          this.$router.push({ path: "/admin" });
        })
        .catch(error => {
          console.log("ERRRRRRORROROROR or failed login")
          console.log(error);
        });
    },
    validateInput() {
      let self = this;
      self.$validator.validate().then(result => {
        if (result) {
          self.logIn();
        }
      });
    }
  }
};
</script>

<style scoped>
</style>
