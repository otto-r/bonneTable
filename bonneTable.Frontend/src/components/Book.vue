<template>
  <div>
    <b-container fluid class="mt-3">
      <b-row>
        <b-col cols="5" id="cols" class="mx-auto">
          <h5>BonneTable</h5>
          <div class="breadcrumb flat">
            <b-button @click="dateClick()">{{dateDisplay}}</b-button>
            <b-button @click="guestsClick()">{{guestsDisplay}}</b-button>
            <b-button @click="timeClick()">{{timeDisplay}}</b-button>
            <b-button @click="confirmClick()">Confirm</b-button>
          </div>
          <router-view></router-view>
        </b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script>
import DateSelect from "../components/DateSelect.vue";
import GuestsSelect from "../components/GuestsSelect.vue";
import TimeSelect from "../components/TimeSelect.vue";
import ConfirmSelect from "../components/ConfirmSelect.vue";

export default {
  name: "Book",
  data() {
    return {
      
    };
  },
  created() {
    this.$router.push({ path: "/book/date" });
  },
  computed:{
    dateDisplay: function () {
      if (!this.$store.state.date){
        return 'Date';
      }
      var date = this.$store.state.date;
      var formattedDate = date.toDateString();
      return formattedDate;
    },
    guestsDisplay: function () {
      if (!this.$store.state.guests){
        return 'Guests';
      }
      var guests = this.$store.state.guests;
      return 'Guests: ' + guests;
    },
    timeDisplay: function () {
      if (!this.$store.state.time){
        return 'Time';
      }
      var time = this.$store.state.time.hours + ':' + this.$store.state.time.minutes;
      return time;
    }
  },
  methods: {
    dateClick() {
      self = this;

      self.$router.push({ path: "/book/date" });
    },
    guestsClick() {
      self = this;

      self.$router.push({ path: "/book/guests" });
    },
    timeClick() {
      self = this;

      self.$router.push({ path: "/book/time" });
    },
    confirmClick() {
      self = this;

      self.$router.push({ path: "/book/confirm" });
    }
  }
};
</script>

<style>


/*custom font*/
@import url(https://fonts.googleapis.com/css?family=Merriweather+Sans);



.breadcrumb {
	/*centering*/
	display: inline-block;
	overflow: hidden;
	border-radius: 5px;
	/*Lets add the numbers for each link using CSS counters. flag is the name of the counter. to be defined using counter-reset in the parent element of the links*/
	counter-reset: flag;
  padding: 0;
}

.breadcrumb button {
	text-decoration: none;
	outline: none;
	display: block;
	float: left;
	font-size: 1rem;
	line-height: 36px;
	color: white;
	/*need more margin on the left of links to accomodate the numbers*/
	padding: 0 0.5rem 0 1.4rem;
	background: #666;
	background: linear-gradient(#666, #333);
	position: relative;
}
/*since the first link does not have a triangle before it we can reduce the left padding to make it look consistent with other links*/
.breadcrumb button:first-child {
	padding: 0 0.5rem 0 1rem;
	border-radius: 5px 0 0 5px; /*to match with the parent's radius*/
}
.breadcrumb button:first-child:before {
	left: 14px;
}
.breadcrumb button:last-child {
	border-radius: 0 5px 5px 0; /*this was to prevent glitches on hover*/
}

/*hover/active styles*/
.breadcrumb button.active, .breadcrumb a:hover{
	background: #333;
	background: linear-gradient(#333, #000);
}
.breadcrumb button.active:after, .breadcrumb a:hover:after {
	background: #333;
	background: linear-gradient(135deg, #333, #000);
}

/*adding the arrows for the breadcrumbs using rotated pseudo elements*/
.breadcrumb button:after {
	content: '';
	position: absolute;
	top: 0; 
	right: -18px; /*half of square's length*/
	/*same dimension as the line-height of .breadcrumb a */
	width: 36px; 
	height: 36px;
	/*as you see the rotated square takes a larger height. which makes it tough to position it properly. So we are going to scale it down so that the diagonals become equal to the line-height of the link. We scale it to 70.7% because if square's: 
	length = 1; diagonal = (1^2 + 1^2)^0.5 = 1.414 (pythagoras theorem)
	if diagonal required = 1; length = 1/1.414 = 0.707*/
	transform: scale(0.707) rotate(45deg);
	/*we need to prevent the arrows from getting buried under the next link*/
	z-index: 1;
	/*background same as links but the gradient will be rotated to compensate with the transform applied*/
	background: #666;
	background: linear-gradient(135deg, #666, #333);
	/*stylish arrow design using box shadow*/
	box-shadow: 
		2px -2px 0 2px rgba(0, 0, 0, 0.4), 
		3px -3px 0 2px rgba(255, 255, 255, 0.1);
	/*
		5px - for rounded arrows and 
		50px - to prevent hover glitches on the border created using shadows*/
	border-radius: 0 5px 0 50px;
}
/*we dont need an arrow after the last link*/
.breadcrumb button:last-child:after {
	content: none;
}
/*we will use the :before element to show numbers*/
.breadcrumb button:before {
	/*some styles now*/
	border-radius: 100%;
	width: 20px;
	height: 20px;
	line-height: 20px;
	margin: 8px 0;
	position: absolute;
	top: 0;
	left: 30px;
	background: #444;
	background: linear-gradient(#444, #222);
	font-weight: bold;
}


.flat button, .flat button:after {
	background: white;
	color: black;
	transition: all 0.5s;
}
.flat button:before {
	background: white;
	box-shadow: 0 0 0 1px #ccc;
}
.flat button:hover, .flat button.active, 
.flat button:hover:after, .flat button.active:after{
	background: rgb(243, 81, 105);
}

#cols{
    text-align:center;
    border: 2px solid lightpink;
    border-radius: 12px;
    margin: 0 auto;
    padding: 10px 0 20px;
    margin-top: 10px;
}
h5{
    width:10rem;
    background:white;
    margin-top:-1.5rem;
    margin-left:5px;
}

.btn-pink {
  color: white !important;
  background-color: #ff66b3 !important;
  border-color: #ff66b3 !important;
}
.btn-pink:hover {
  color: #ff66b3 !important;
  background-color: white !important;
  border-color: #ff66b3 !important;
}
.btn-pink-filled{
  color: white !important;
  background-color: #ff66b3 !important;
  border-color: #ff66b3 !important;
}
.btn-pink-filled:hover{
  background-color: white !important;
  border-color: #fd3d9d !important;
}
</style>
