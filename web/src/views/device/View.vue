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
import jwtService from "../../common/JwtService";
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
      var token = jwtService.getToken().token;
      var deviceDetailId = parseInt(this.$route.params.id);
      connection = new HubConnectionBuilder()
        .withUrl(
          `http://192.168.2.216/sensorhub?token=${token}&sensorId=${deviceDetailId}`,
          {
            skipNegotiation: true,
            transport: HttpTransportType.WebSockets,
          }
        )
        .build();

      connection
        .start()
        .then(() => {
          connection.on("getData",(data)=>{
            var date = this.$moment(new Date()).format('DD/MM/YYYY hh:mm:ss');
            if(this.labels.length == 25){
              this.labels = [];
              this.datasets[0].data = []
            }
            this.labels.push(date); 
            this.datasets[0].data.push(data.value);  
            this.$refs.chart.ardRender();         
          })
        })
        .catch((err) => {
          console.log(err);
        });
    },
  },
  created() {
    this.labels = [
    ];

    this.datasets = [
      {
        label: "Sensor Data",
        backgroundColor: "#1797BE",
        data: [],
      },
    ];

    this.connect();

    setTimeout(()=>{
      window.location.reload();
    },600000)
  },
};
</script>