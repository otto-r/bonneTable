import { Bar } from "vue-chartjs";

export default {
  props: ["dataArray"],
  extends: Bar,
  mounted() {
    // this.defaults.global.elements.line.backgroundColor = "#ffffff";
    this.renderChart(
      {
        labels: [
          "16:00",
          "16:30",
          "17:00",
          "17:30",
          "18:00",
          "18:30",
          "19:00",
          "19:30",
          "20:00",
          "20:30",
          "21:00",
          "21:30"
        ],
        datasets: [
          {
            label: "Bookings",
            backgroundColor: "#05CBE1",
            data: this.dataArray
          }
        ],
        options: [
          {
            scales: {
              xAxes: [
                {
                  gridLines: {
                    color: "rgba(0, 0, 0, 0)",
                    display: true
                  }
                }
              ],
              yAxes: [
                {
                  gridLines: {
                    color: "rgba(0, 0, 0, 0)",
                    display: true
                  }
                }
              ]
            }
          }
        ]
      },
      { responsive: true, maintainAspectRatio: false }
    );
  }
};
