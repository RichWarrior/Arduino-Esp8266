<template>
  <v-row class="ma-2">
    <v-col cols="12">
      <v-card>
        <v-toolbar class="gradient" dark>
          <h1 class="title">Sensor Info</h1>
        </v-toolbar>
        <v-card-actions>
          <v-col>
            <bar-chart
              ref="chart"
              :labels="labels"
              :datasets="datasets"
            ></bar-chart>
          </v-col>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import bar from "../../components/chart/bar.vue";
import { HubConnectionBuilder, HttpTransportType } from "@aspnet/signalr";
let connection = null;
export default {
  components: {
    "bar-chart": bar,
  },
  data: () => ({
    labels: [],
    datasets: [],
  }),
  methods: {
    connect() {
      connection = new HubConnectionBuilder()
        .withUrl("http://localhost:42192/sensorhub", {
          skipNegotiation: true,
          transport: HttpTransportType.WebSockets,
        })
        .build();

      connection
        .start()
        .then(() => {})
        .catch((err) => {
          console.log(err);
        })
    },
  },
  created() {
    this.labels = [
      "January",
      "February",
      "March",
      "April",
      "May",
      "June",
      "July",
    ];

    this.datasets = [
      {
        label: "Visitors",
        backgroundColor: "#1797BE",
        data: [40, 39, 10, 40, 39, 80, 40],
      },
    ];

    this.connect();
  },
};
</script>