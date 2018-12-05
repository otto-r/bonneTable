<template>
  <div>
    <b-button @click="logIn()">Log In!</b-button>
  </div>
</template>

<script>
import { getToken } from "@/api/Authentication";

export default {
  name: "LogIn",
  data() {
    return {
      userInfo: { username: "test", password: "test" }
    };
  },
  methods: {
    logIn() {
      getToken(this.userInfo)
        .then(response => {
          console.log(response);

          $store.state.loggedIn = true;
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style scoped>
</style>
