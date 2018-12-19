<template>
  <div>
    <div>
      <div class="row">
        <div class>Hej</div>
        <div class="col-4">
          <div class="form-group" :class="{'has-error': errors.any() }">
            <label class="control-label" for="Name">Name</label>
            <input
              class
              :class="{'input': true, 'is-invalid': errors.has('Name') }"
              v-model="$store.state.name"
              v-validate="'required'"
              name="Name"
              type="text"
              placeholder="Name"
            >
            <p class="text-danger" v-if="errors.has('Name')">{{ errors.first('Name') }}</p>
          </div>
          <div class :class="{'has-error': errors.any() }">
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
          <div class :class="{'has-error': errors.any() }">
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
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "EditWindow",
  data() {
    return {};
  },
  methods: {},
  created() {}
};
</script>

<style scoped>
</style>
