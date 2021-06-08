<template>
  <v-col cols="12" class="pa-0">
    <v-card>
      <v-toolbar>
        <h1 class="title">Device Pin Mapping</h1>
        <v-spacer> </v-spacer>
        <v-dialog v-model="dialog" max-width="600px">
          <template v-slot:activator="{ on, attrs }">
            <v-btn icon v-bind="attrs" v-on="on">
              <v-icon>fa fa-plus</v-icon>
            </v-btn>
          </template>
          <v-card>
            <v-toolbar class="gradient" dark>
              <h1 class="title">New Device Item</h1>
            </v-toolbar>
            <v-card-actions>
              <v-form v-model="formValid">
                <v-row class="ma-2">
                  <v-col cols="12">
                    <v-select
                      v-model="deviceDetail.SensorId"
                      :items="sensors"
                      item-text="name"
                      item-value="id"
                      label="Sensor"
                      :rules="validations.sensor"
                    ></v-select>
                  </v-col>
                  <v-col cols="12">
                    <v-select
                      v-model="deviceDetail.PinId"
                      :items="availablePins"
                      item-text="pinName"
                      item-value="id"
                      label="Pin"
                      :rules="validations.pin"
                    ></v-select>
                  </v-col>
                  <v-col cols="12">
                    <v-text-field
                      v-model="deviceDetail.Description"
                      label="Description"
                    ></v-text-field>
                  </v-col>
                  <v-row>
                    <v-spacer></v-spacer>
                    <v-btn
                      :disabled="!formValid"
                      color="primary"
                      @click="saveDeviceDetail"
                    >
                      <v-icon left>fa fa-save</v-icon>
                      <span>Save</span>
                    </v-btn>
                  </v-row>
                </v-row>
              </v-form>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
      <v-card-actions>
        <v-col cols="12">
          <v-data-table :items="deviceDetails" :headers="headers">
            <template v-slot:item.actions="{ item }">
              <v-btn icon @click="show(item)">
                <v-icon>fa fa-eye</v-icon>
              </v-btn>
              <v-btn icon @click="deleteDetail(item)">
                <v-icon>fa fa-trash</v-icon>
              </v-btn>
            </template>
          </v-data-table>
        </v-col>
      </v-card-actions>
    </v-card>
  </v-col>
</template>

<script>
import { GET_SENSORS } from "../../../store/modules/sensor/actions.type";
import { GET_AVAILABLE_PINS } from "../../../store/modules/pin/actions.type";
import {
  INSERT_DEVICE_DETAIL,
  GET_DEVICE_DETAILS,
} from "../../../store/modules/devicedetail/actions.type";
import { ShowErrorMessage, ShowSuccessMessage } from "../../../common/Alerts";
import availablePinsDTO from "../../../dto/request/device/AvailablePins";
import deviceDetailDTO from "../../../dto/request/device/NewDeviceDetail";
export default {
  props: {
    deviceItem: {
      required: true,
    },
  },
  data: () => ({
    dialog: false,
    sensors: [],
    availablePins: [],
    deviceDetail: new deviceDetailDTO(),
    formValid: false,
    validations: {
      sensor: [(v) => v > 0 || "This field is required"],
      pin: [(v) => v > 0 || "This field is required"],
    },
    deviceDetails: [],
    headers: [
      {
        value: "sensorName",
        align: "center",
        text: "Sensor Name",
      },
      {
        value: "pin",
        align: "center",
        text: "Pin",
      },
      {
        value: "actions",
        align: "center",
        text: "Actions",
      },
    ],
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
    saveDeviceDetail() {
      this.deviceDetail.DeviceId = parseInt(this.$route.params.id);
      this.$store
        .dispatch(INSERT_DEVICE_DETAIL, this.deviceDetail)
        .then((payload) => {
          ShowSuccessMessage(payload.message);
          this.getAvailablePins();
        })
        .catch((err) => {
          ShowErrorMessage(err.message);
        })
        .finally(() => {
          this.deviceDetail = new deviceDetailDTO();
          this.deviceDetail.DeviceId = parseInt(this.$route.params.id);
          this.getDeviceDetails();
        });
    },
    getDeviceDetails() {
      var deviceId = parseInt(this.$route.params.id);
      this.$store
        .dispatch(GET_DEVICE_DETAILS, deviceId)
        .then(() => {
          this.deviceDetails = this.$store.getters.getDeviceDetails;
        })
        .catch((err) => {
          ShowErrorMessage(err.message);
        });
    },
    show(deviceDetail) {
      console.log(deviceDetail);
    },
    deleteDetail(deviceDetail) {
      console.log(deviceDetail);
    },
  },
  created() {
    this.getSensors();
    this.getAvailablePins();
    this.getDeviceDetails();
  },
};
</script>