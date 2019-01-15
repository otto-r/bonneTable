<template>
  <div>
    <div class="mx-auto">
      <div class="footer float-right">
        Ｂｅｓｔ　Ｖｉｅｗｅｄ　Ｉｎ　ほベゖ
        <a
          href="https://www.microsoft.com/en-us/download/internet-explorer-7-details.aspx"
        >
          <b-img class="logo" src="/static/ie4.gif"/>
        </a>
        <a
          href="https://en.wikipedia.org/wiki/Netscape"
        >
          <b-img class="logo netscape" src="/static/netscape.gif"/>
        </a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Footer",
  data() {
    return {};
  },
  methods: {},
  created() {}
};
</script>

<style scoped>
.netscape {
  height: 31px;
}
.footer {
  color: pink;
  margin: 15px;
  padding-bottom: 15px;
  }
</style>
