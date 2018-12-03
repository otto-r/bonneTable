<template>
  <div>
    <label for="seats">Seats</label>
    <input
      v-validate="'numeric'"
      v-model="seats"
      data-vv-as="field"
      name="seats_field"
      type="text"
      :class="{'has-error': errors.has('seats_field')}"
    >
    <button class="btn btn-secondary" @click="onClickAddTable()">Add</button>
    <div class="alert-success" v-if="showSuccess"></div>
    <div class="alert-warning" v-if="!showSuccess"></div>
    <span class="has-error">{{ errors.first('seats_field') }}</span>
  </div>
</template>

<script>
import { addTable } from "@/api/TableAPI";

export default {
  name: "TableAdd",
  data() {
    return {
      seats: 0,
      success: false,
      showSuccess: false
    };
  },
  methods: {
    onClickAddTable() {
      addTable(this.seats)
        .then(response => {
          console.log(this.seats)
          this.success = response.success;
          this.showSuccess = true
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
.has-error {
  border: 1;
  border-color: red;
}
</style>
