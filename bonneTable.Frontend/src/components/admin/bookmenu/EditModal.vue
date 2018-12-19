<template>
  <transition name="modal">
    <div class="modal-mask">
      <div class="modal-wrapper">
        <div class="modal-container">
          <div class="modal-body t55">
            <div class="row headerw95">
              <div class>Edit Booking</div>
              <div class="xbutton float-right">x</div>
            </div>
            <div class="edit-input">
              <div class="form-group" :class="{'has-error': errors.any() }">
                <label class="control-label" for="Name">Name</label>
                <input
                  class="w98input"
                  :class="{'input': true, 'is-invalid': errors.has('Name') }"
                  v-model="$store.state.name"
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
                  v-model="$store.state.email"
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
                  v-model="$store.state.phoneNumber"
                  v-validate="'required|numeric'"
                  name="PhoneNumber"
                  type="text"
                  placeholder="PhoneNumber"
                >
                <p
                  class="text-danger"
                  v-if="errors.has('PhoneNumber')"
                >{{ errors.first('PhoneNumber') }}</p>
              </div>
              <div class="row">
                <button class="btn float-left" @click="$emit('save')">Save</button>
                <button class="btn float-right" @click="$emit('close')">Close</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </transition>
</template>

<script>
export default {
  name: "EditModal",
  data() {
    return {};
  },
  methods: {},
  created() {}
};
</script>

<style scoped>
.logo {
  max-width: 100%;
  height: auto;
}
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-container {
  background-position: center center;
  width: 300px;
  margin: 0px auto;
  padding: 0px 0px;
  background-color: rgb(200, 200, 200);
  border-radius: 0px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
  color: black;
  z-index: 9999;
  font-family: Helvetica, Arial, sans-serif;
}

.modal-header h3 {
  margin-top: 0;
  color: #42b983;
}

.modal-body {
  margin: 0px 0;
  padding: 0;
}

.modal-default-button {
  float: right;
}

.modal-enter {
  opacity: 0;
}

.modal-leave-active {
  opacity: 0;
}

.modal-enter .modal-container,
.modal-leave-active .modal-container {
  -webkit-transform: scale(1.1);
  transform: scale(1.1);
}

.headerw95 {
  margin: 0px 0px 0px 0px;
  padding: 5px 5px;
  color: white;
  background: linear-gradient(to right, #000099, #8080ff);
  /* font-weight: bold; */
  font-size: 1.2em;
  line-height: 16px;
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}

.xbutton {
  padding: 5px;
  background: rgb(200, 200, 200);
  color: black;
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}

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

.edit-input {
  padding: 10px 10px 10px 10px;
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}
</style>
