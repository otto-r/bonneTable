<template>
  <div class="mt-3">
    <p>
      <b-button @click="setGuests(1)" class="btn btn-lg btn-outline-primary btn-pink mr-1">1</b-button>
      <b-button @click="setGuests(2)" class="btn btn-lg btn-outline-primary btn-pink mr-1">2</b-button>
      <b-button @click="setGuests(3)" class="btn btn-lg btn-outline-primary btn-pink mr-1">3</b-button>
    </p>
    <p>
      <b-button @click="setGuests(4)" class="btn btn-lg btn-outline-primary btn-pink mr-1">4</b-button>
      <b-button @click="setGuests(5)" class="btn btn-lg btn-outline-primary btn-pink mr-1">5</b-button>
      <b-button @click="setGuests(6)" class="btn btn-lg btn-outline-primary btn-pink mr-1">6</b-button>
    </p>
  </div>
</template>

<script>
export default {
  name: "GuestsSelect",
  data() {
    return {};
  },
  methods: {
    setGuests(guests) {
      this.$store.commit("setGuests", guests);
      this.$router.push({ path: "/book/time" });
    }
  }
};
</script>

<style scoped>
  @import url(https://fonts.googleapis.com/css?family=Open+Sans:400,600,700);

/* General Buttons */
button {
  width: 60px;
  height: 40px;
  background: linear-gradient(to bottom, lightpink 0%,rgb(253, 73, 100) 100%); /* W3C */
  border: none;
  border-radius: 5px;
  position: relative;
  border-bottom: 4px solid rgb(151, 3, 47);
  color: #fbfbfb;
  font-weight: 600;
  font-family: 'Open Sans', sans-serif;
  text-shadow: 1px 1px 1px rgba(0,0,0,.4);
  font-size: 15px;
  text-align: left;
  text-indent: 5px;
  box-shadow: 0px 3px 0px 0px rgba(0,0,0,.2);
  cursor: pointer;

/* Just for presentation */
  margin: 0 auto;
  margin-bottom: 20px;
}
button:active {
  box-shadow: 0px 2px 0px 0px rgba(0,0,0,.2);
  top: 1px;
}

button:after {
  content: "";
  width: 0;
  height: 0;
  display: block;
  border-top: 20px solid rgb(235, 36, 96);
  border-bottom: 20px solid rgb(235, 36, 96);
  border-left: 16px solid transparent;
  border-right: 20px solid rgb(235, 36, 96);
  position: absolute;
  opacity: 0.6; 
  right: 0;
  top: 0;
  border-radius: 0 5px 5px 0;  
}

/* Button pointing left */

button.back {
  text-align: right;
  padding-right: 12px;
  box-sizing: border-box;
}
button.back:after {
  content: "";
  width: 0;
  height: 0;
  display: block;
  border-top: 20px solid #187dbc;
  border-bottom: 20px solid #187dbc;
  border-right: 16px solid transparent;
  border-left: 20px solid #187dbc;
  position: absolute;
  opacity: 0.6; 
  left: 0;
  top: 0;
  border-radius: 5px 0 0 5px;    
}


/* Presentation stuff */
.holder {
  width: 400px;
  background: #efefef;
  padding: 30px 10px;
  box-sizing: border-box;
  margin: 0 auto;
  margin-top: 20px;  
  text-align: center;
}
</style>
