<template>
  <v-form v-model="formValid">
    <v-row class="ma-2">
      <v-col cols="12" md="6" lg="6" xl="6">
        <v-text-field
          v-model="deviceItem.name"
          :rules="validations.name"
          label="Device Name"
        ></v-text-field>
      </v-col>
      <v-col cols="12" md="6" lg="6" xl="6">
        <v-select
          v-model="deviceItem.deviceTypeId"
          :items="deviceTypes"
          :rules="validations.deviceTypeId"
          item-text="name"
          item-value="id"
          label="Device Type"
          :disabled="true"
        ></v-select>
      </v-col>
    </v-row>
    <v-row class="ma-2">
      <v-spacer></v-spacer>
      <v-btn :disabled="!formValid" color="primary" @click="saveRecord">
        <v-icon left>fa fa-save</v-icon>
        <span>Save</span>
      </v-btn>
    </v-row>
  </v-form>
</template>

<script>
import { GET_DEVICE_TYPES } from "../../../store/modules/devicetype/actions.type";
import { ShowErrorMessage } from "../../../common/Alerts";
export default {
  props: {
    deviceItem: {
      required: true,
    },
  },
  data: () => ({
    formValid: false,
    deviceTypes: [],
    validations: {
      name: [
        (v) => !!v || "This field is required",
        (v) => !v || v.length <= 255 || "Can have a maximum of 255 characters",
      ],
      deviceTypeId: [(v) => v > 0 || "This field is required"],
    },
  }),
  methods: {
    saveRecord() {
        this.$emit('saveDevice')
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