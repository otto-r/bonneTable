<template>
  <div class="mt-3 mx-auto">
    <p>
      <b-button @click="setTime({hours: 16, minutes: '00'})" class="btn btn-lg btn-outline-primary btn-pink mr-1">16:00</b-button>
      <b-button @click="setTime({hours: 16, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">16:30</b-button>
      <b-button @click="setTime({hours: 17, minutes: '00'})" class="btn btn-lg btn-outline-primary btn-pink mr-1">17:00</b-button>
    </p>
    <p>
      <b-button @click="setTime({hours: 17, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">17:30</b-button>
      <b-button @click="setTime({hours: 18, minutes: '00'})" class="btn btn-lg btn-outline-primary btn-pink mr-1">18:00</b-button>
      <b-button @click="setTime({hours: 18, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">18:30</b-button>
    </p>
    <p>
      <b-button @click="setTime({hours: 19, minutes: '00'})" class="btn btn-lg btn-outline-primary btn-pink mr-1">19:00</b-button>
      <b-button @click="setTime({hours: 19, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">19:30</b-button>
      <b-button @click="setTime({hours: 20, minutes: '00'})" class="btn btn-lg btn-outline-primary btn-pink mr-1">20:00</b-button>
    </p>
    <p>
      <b-button @click="setTime({hours: 20, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">20:30</b-button>
      <b-button @click="setTime({hours: 21, minutes: '00'})" class="btn btn-lg btn-outline-primary btn-pink mr-1">21:00</b-button>
      <b-button @click="setTime({hours: 21, minutes: 30})" class="btn btn-lg btn-outline-primary btn-pink mr-1">21:30</b-button>
    </p>
  </div>
</template>

<script>
export default {
  name: 'TimeSelect',
  data () {
    return {

    }
  },
  methods: {
    setTime(time) {
      this.$store.commit("setTime", time);
      this.$router.push({ path: "/book/confirm" });
    }
  }
}
</script>

<style scoped>
    @import url(https://fonts.googleapis.com/css?family=Open+Sans:400,600,700);

/* General Buttons */
button {
  width: 90px;
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
