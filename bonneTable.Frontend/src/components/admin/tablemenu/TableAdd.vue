<template>

  <div class="form-group" :class="{'has-error': errors.any() }">
    <label for="seats">Seats</label>
    <input
      v-validate="'numeric|required|min_value:1'"
      v-model="tableRequest.numberOfSeats"
      data-vv-as="field"
      name="seats_field"
      type="text"
      class="form-control"
      :class="{'input': true, 'is-invalid': errors.has('seats_field') }"
    >
    <button class="btn btn-secondary" @click="validateInput()">Add</button>
    <div class="alert-success" v-if="showSuccess">Added table with {{ tableRequest.numberOfSeats }} seats</div>
    <div class="alert-warning" v-if="!showSuccess"></div>
    <span class="text-danger">{{ errors.first('seats_field') }}</span>
  </div>
</template>


<script>
import { addTable } from "@/api/TableAPI";

export default {
  name: "TableAdd",
  data() {
    return {
      tableRequest: { numberOfSeats: 0 },
      seats: 0,
      success: false,
      showSuccess: false
    };
  },
  methods: {
    validateInput() {
      let self = this;
      self.$validator.validate().then(result => {
        if (result) {
          self.onClickAddTable();
        }
      });
    },
    onClickAddTable() {
      addTable(this.tableRequest)
        .then(response => {
          console.log(this.tableRequest);
          this.success = response.success;
          this.showSuccess = true;
          this.seats = 0;
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
