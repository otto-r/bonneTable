<template>
  <div>
    <div class="container-fluid mt-3">
      <div class="row">
        <div class="col-4 mx-auto">
          <glitch-image/>
          <br>
          <br>
          <div class="form">
            <div class="form-group row">
              <div class="mx-auto">
                <label class="label-thing mx-auto" for="username">★Username:</label>
                <input
                  v-validate="'alpha|required'"
                  v-model="userInfo.username"
                  data-vv-as="field"
                  name="username"
                  placeholder="Username"
                  type="text"
                  class="input-thing"
                  :class="{'alert-danger': errors.has('username')}"
                >
              </div>
            </div>
            <div class="form-group row">
              <div class="mx-auto">
                <label class="label-thing" for="password">Password:</label>
                <input
                  v-validate="'required'"
                  v-model="userInfo.password"
                  data-vv-as="field"
                  name="password"
                  placeholder="Password"
                  type="password"
                  class="input-thing"
                  :class="{'alert-danger': errors.has('password')}"
                >
              </div>
            </div>
            <div class="row">
              <b-button class="btn mx-auto login" @click="validateInput()">
                <div v-if="!loading">Log In</div>
                <div v-if="loading" class="loader"></div>
              </b-button>
            </div>
            <div class="row">
              <div class="mx-auto" v-if="validationFailed">⚠️Please enter username and password.</div>
              <div class="mx-auto" v-if="logInFailure">⚠️Login failed : {{ errorMsg }}</div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { getToken } from "@/api/Authentication.js";
import { decode } from "@/Helper/JWT.js";
import glitchImage from "../admin/glitchImage";

export default {
  components: {
    glitchImage
  },
  name: "LogIn",
  data() {
    return {
      errorMsg: "",
      logInFailure: false,
      loading: false,
      validationFailed: false,
      userInfo: { username: "", password: "" }
    };
  },
  methods: {
    logIn() {
      this.loading = true;
      getToken(this.userInfo)
        .then(response => {
          this.loading = false;
          console.log(response);
          localStorage.token = response.token;

          localStorage.loggedIn = true;
          console.log(localStorage.loggedIn);
          this.$router.push({ path: "/admin" });
        })
        .catch(error => {
          this.logInFailure = true;
          this.errorMsg = "Incorrect username or password";
          console.log("Error: " + this.errorMsg);
        });
    },
    validateInput() {
      let self = this;
      self.$validator.validate().then(result => {
        this.validationFailed = false;
        if (result) {
          self.logIn();
        } else {
          this.validationFailed = true;
        }
      });
    }
  }
};
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Arizonia");

.label-thing {
  font-size: 1.2em;
}

.input-thing {
  color: #ffe6ff;
  border: none;
  background: none;
  border-bottom: #ffe6ff;
  border-bottom-color: #ffe6ff;
  border-bottom-width: 3px;
  border-bottom: 4px solid #ffe6ff;
  outline: none;
}

html,
body {
  background: linear-gradient(
    to bottom right,
    #f056ff 0%,
    #2989d8 50%,
    #00fffa 100%
  );
  color: pink;
  background-attachment: fixed;
  height: 100%;
}

.loader {
  border: 3px solid #ffe6ff;
  border-radius: 50%;
  border-top: 3px solid #00fffa;
  width: 25px;
  height: 25px;
  -webkit-animation: spin 2s linear infinite; /* Safari */
  animation: spin 2s linear infinite;
}

@keyframes spin {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}
</style>
