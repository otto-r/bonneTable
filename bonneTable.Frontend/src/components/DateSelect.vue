<template>
  <div class="mt-3">
    <v-date-picker :pane-width='290' is-inline :theme-styles='themeStyles' mode='single' v-model='$store.state.date' :min-date='today'></v-date-picker>
  </div>
</template>

<script>
export default {
  name: 'DateSelect',
  data () {
    const hSpacing = '15px';
    return {
        date: new Date(),
        today: new Date(this.getTodayDate()),
        themeStyles: {
          wrapper: {
            background: 'linear-gradient(to bottom right, #ff5050, #ff66b3)',
            color: '#fafafa',
            border: '0',
            borderRadius: '5px',
            boxShadow: '0 4px 8px 0 rgba(0, 0, 0, 0.14), 0 6px 20px 0 rgba(0, 0, 0, 0.13)'
          },
          header: {
            padding: `20px ${hSpacing}`,
          },
          headerHorizontalDivider: {
            borderTop: 'solid rgba(255, 255, 255, 0.2) 1px',
            width: '80%',
          },
          weekdays: {
            color: '#6eded1',
            fontWeight: '600',
            padding: `20px ${hSpacing} 5px ${hSpacing}`,
          },
          weeks: {
            padding: `0 ${hSpacing} ${hSpacing} ${hSpacing}`,
          },
          dayContent: {
            fontSize: '0.9rem'
          },
          dayCellNotInMonth: {
            opacity: 0,
          }
        }
    }
  },
  methods:{
    getTodayDate(){
      var day = new Date().getDate();
      var month = new Date().getMonth() + 1;
      var year = new Date().getFullYear();

      if(day < 10) {
        day = '0' + day
      } 

      if(month < 10) {
        month = '0' + month
      } 

      var fullDateString = year + '-' + month + '-' + day;
      return fullDateString;
    }
  },
  created(){
    self = this;
  },
}
</script>

<style scoped>

</style>
