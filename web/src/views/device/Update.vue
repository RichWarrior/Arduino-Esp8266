<template>
  <v-row class="ma-2">
    <v-col cols="12">
      <v-card>
        <v-tabs
          v-model="tab"
          background-color="gradient"
          centered
          dark
          icons-and-text
        >
          <v-tabs-slider></v-tabs-slider>

          <v-tab href="#device-info">
            Device Info
            <v-icon>fa fa-microchip</v-icon>
          </v-tab>

          <v-tab href="#device-detail">
            Device Details
            <v-icon>fa fa-info-circle</v-icon>
          </v-tab>
        </v-tabs>

        <v-tabs-items v-model="tab">
          <v-tab-item value="device-info">
            <device-info
              :deviceItem="device"
              v-on:saveDevice="saveDevice"
            ></device-info>
          </v-tab-item>
          <v-tab-item value="device-detail">
            <device-detail :deviceItem="device"></device-detail>
          </v-tab-item>
        </v-tabs-items> </v-card
    ></v-col>
  </v-row>
</template>

<script>
import {
  GET_DEVICE,
  UPDATE_DEVICE,
} from "../../store/modules/device/actions.type";
import { ShowErrorMessage, ShowSuccessMessage } from "../../common/Alerts";
import updateDTO from "../../dto/request/device/Update";
export default {
  data: () => ({
    tab: "",
    device: {},
  }),
  components: {
    "device-info": () => import("./Update/DeviceInfo"),
    "device-detail": () => import("./Update/DeviceDetail"),
  },
  methods: {
    saveDevice() {
      var dto = new updateDTO();
      dto.Id = this.device.id;
      dto.Name = this.device.name;
      this.$store
        .dispatch(UPDATE_DEVICE, dto)
        .then((payload) => {
          ShowSuccessMessage(payload.message);
        })
        .catch((err) => {
          ShowErrorMessage(err.message);
        });
    },
  },
  created() {
    var deviceId = this.$route.params.id;
    var req = {
      id: deviceId,
    };
    this.$store
      .dispatch(GET_DEVICE, req)
      .then(() => {
        this.device = this.$store.getters.getDevice;
      })
      .catch((err) => {
        ShowErrorMessage(err);
      });
  },
};
</script>