<template>
  <v-col cols="12" class="pa-0">
    <v-card>
      <v-toolbar>
        <v-spacer> </v-spacer>
        <v-dialog v-model="dialog" max-width="600px">
          <template v-slot:activator="{ on, attrs }">
            <v-btn icon v-bind="attrs" v-on="on">
              <v-icon>fa fa-plus</v-icon>
            </v-btn>
          </template>
          <v-card>
            <v-card-actions></v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-card-actions>
        <v-col cols="12">
          <v-data-table></v-data-table>
        </v-col>
      </v-card-actions>
    </v-card>
  </v-col>
</template>

<script>
import { GET_SENSORS } from "../../../store/modules/sensor/actions.type";
import { GET_AVAILABLE_PINS } from "../../../store/modules/pin/actions.type";
import { ShowErrorMessage } from "../../../common/Alerts";
import availablePinsDTO from "../../../dto/request/device/AvailablePins";
export default {
  props: {
    deviceItem: {
      required: true,
    },
  },
  data: () => ({
    sensors: [],
    availablePins: [],
  }),
  methods: {
    getSensors() {
      this.$store
        .dispatch(GET_SENSORS)
        .then(() => {
          this.sensors = this.$store.getters.getSensors;
        })
        .catch((err) => {
          ShowErrorMessage(err.message);
        });
    },
    getAvailablePins() {
      var dto = new availablePinsDTO();
      dto.Id = this.$route.params.id;
      this.$store
        .dispatch(GET_AVAILABLE_PINS, dto)
        .then(() => {
          this.availablePins = this.$store.getters.getAvailablePins;
        })
        .catch((err) => {
          ShowErrorMessage(err.message);
        });
    },
  },
  created() {
    this.getSensors();
    this.getAvailablePins();
  },
};
</script>