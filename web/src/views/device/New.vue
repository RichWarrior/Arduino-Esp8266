<template>
  <v-row class="ma-2">
    <v-col cols="12" md="4" lg="4" xl="4">
      <v-card>
        <v-toolbar class="gradient" tile dark>
          <v-btn icon @click="$router.go(-1)">
            <v-icon>fa fa-arrow-left</v-icon>
          </v-btn>
          <h1 class="title">New Device</h1>
        </v-toolbar>
        <v-card-actions>
          <v-col cols="12">
            <v-form v-model="formValid">
              <v-row>
                <v-col cols="12">
                  <v-text-field
                    v-model="device.Name"
                    :rules="validations.name"
                    label="Device Name"
                  ></v-text-field>
                </v-col>
                <v-col cols="12">
                  <v-select
                    v-model="device.DeviceTypeId"
                    :rules="validations.deviceTypeId"
                    label="Device Type"
                    :items="deviceTypes"
                    item-text="name"
                    item-value="id"
                  ></v-select>
                </v-col>
              </v-row>
              <v-row>
                <v-spacer></v-spacer>
                <v-btn :disabled="!formValid" color="primary" @click="saveDevice">
                  <v-icon left>fa fa-save</v-icon>
                  <span>Save</span>
                </v-btn>
              </v-row>
            </v-form>
          </v-col>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import newDevice from "../../dto/request/device/New";
import { GET_DEVICE_TYPES } from "../../store/modules/devicetype/actions.type";
import { INSERT_DEVICE } from "../../store/modules/device/actions.type";
import { ShowErrorMessage, ShowSuccessMessage } from "../../common/Alerts";
export default {
  data: () => ({
    formValid: false,
    device: Object.assign({}, new newDevice()),
    validations: {
      name: [
        (v) => !!v || "This field is required",
        (v) => !v || v.length <= 255 || "Can have a maximum of 255 characters",
      ],
      deviceTypeId: [(v) => v > 0 || "This field is required"],
    },
    deviceTypes: [],
  }),
  methods: {
    saveDevice() {
      this.$store.dispatch(INSERT_DEVICE,this.device).then((payload)=>{
        ShowSuccessMessage(payload.message);
        this.$router.go(-1)
      }).catch((err)=>{
        ShowErrorMessage(err.message);
      })
    },
  },
  created() {
    this.$store
      .dispatch(GET_DEVICE_TYPES)
      .then(() => {
        this.deviceTypes = this.$store.getters.getDeviceTypes;
      })
      .catch((err) => {
        ShowErrorMessage(err.message);
      });
  },
};
</script>