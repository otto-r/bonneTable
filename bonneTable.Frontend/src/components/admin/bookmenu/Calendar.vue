<template>
  <div class="mt-3 mx-auto">
    <v-date-picker
      @click="$emit('toguests')"
      :pane-width="290"
      is-inline
      class="datepicker"
      mode="single"
      :theme-styles="themeStyles"
      v-model="$store.state.date"
      :min-date="today"
    ></v-date-picker>
  </div>
</template>

<script>
export default {
  name: "Calendar",
  data() {
    return {
      date: new Date(),
      today: new Date(this.getTodayDate()),
      displayCalendar: true,
      themeStyles: {
        wrapper: {
          background: "rgb(200, 200, 200)",
          color: "black",
          borderRadius: "0px",
          background: "white"
        },
        header: {
          color: "white",
          padding: `2px`,
          background: "rgba(0, 0, 0, 0.5)"
        },
        headerHorizontalDivider: {
          borderTop: "solid rgba(255, 255, 255, 0.2) 1px",
          width: "80%"
        },
        highlight: {
          backgroundColor: "black"
        }
      }
    };
  },
  methods: {
    getTodayDate() {
      var day = new Date().getDate();
      var month = new Date().getMonth() + 1;
      var year = new Date().getFullYear();

      if (day < 10) {
        day = "0" + day;
      }

      if (month < 10) {
        month = "0" + month;
      }

      var fullDateString = year + "-" + month + "-" + day;
      return fullDateString;
    }
  },
  created() {}
};
</script>
<style scoped>
.datepicker {
  border-style: solid;
  border-width: 3px;
  border-color: rgb(200, 200, 200) rgb(39, 39, 39) rgb(39, 39, 39)
    rgb(200, 200, 200);
}
</style>
