<template>
  <div>
    <div class="float-left mx-auto">
      <b-img
        @mouseenter="toolTip=true"
        @mouseleave="toolTip=false"
        class="img float-left"
        src="/static/token.jpg"
      />
      <div v-if="toolTip" class="bgtp float-left px-1">
        <div class="title">Token</div>
        <div class="dev">Devs only</div>
        <div>
          <span class="exp" v-if="timeLeft <= 0">Expired</span>
          <span class="notexp" v-if="timeLeft != null">{{ timeLeft }}</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { decode } from "@/Helper/JWT.js";

export default {
  name: "tokentimer",
  data() {
    return {
      timeLeft: null,
      toolTip: false
    };
  },
  methods: {
    timer() {
      this.timeLeft = decode(localStorage.token);

      setInterval(this.setTimer, 10000);
    },
    setTimer() {
      var time = decode(localStorage.token);
      if (localStorage.token == null) {
        this.timeLeft = "no token";
      } else if (time <= 0) {
        this.timeLeft = null;
        localStorage.token = null;
      } else {
        var min0 = "";
        if (new Date(time).getUTCMinutes() < 9) {
          min0 = "0";
        }
        this.timeLeft =
          "Expires in: " +
          "0" +
          new Date(time).getUTCHours() +
          ":" +
          min0 +
          new Date(time).getUTCMinutes();
      }
    }
  },
  created() {
    this.timer();
    this.setTimer();
  }
};
</script>

<style scoped>
.bgtp {
  background: black;
  border: 2px solid white;
  border-radius: 5px;
  color: white;
  /* width: auto; */
  padding: 2px;
}

.img {
  border: 2px solid white;
  border-radius: 5px;
  width: 45px;
  height: auto;
}

.notexp {
  color: rgb(255, 209, 0);
}

.exp {
  color: red;
}

.title {
  font-size: 1.2em;
}

.dev {
  color: rgb(0, 145, 0);
  font-size: 0.8em;
}
</style>
