<template>
  <v-row class="ma-2">
    <v-col cols="12">
      <v-card>
        <v-toolbar class="gradient" tile dark>
          <h1 class="title">Devices</h1>
          <v-spacer></v-spacer>
          <v-btn icon @click="$router.push({ path: '/device/new' })">
            <v-icon>fa fa-plus</v-icon>
          </v-btn>
        </v-toolbar>
        <v-card-actions>
          <v-col cols="12">
            <v-data-table :headers="headers" :items="devices">
              <template v-slot:item.actions="{ item }">
                <v-btn @click="updateRecord(item)" icon>
                  <v-icon>fa fa-edit</v-icon>
                </v-btn>
                <v-btn @click="deleteRecord(item)" icon>
                  <v-icon>fa fa-trash</v-icon>
                </v-btn>
              </template>
            </v-data-table>
          </v-col>
        </v-card-actions>
      </v-card>
    </v-col>
  </v-row>
</template>

<script>
import {
  GET_DEVICES,
  DELETE_DEVICES,
} from "../../store/modules/device/actions.type";
import {
  ShowErrorMessage,
  ShowConfirmDialog,
  ShowSuccessMessage,
} from "../../common/Alerts";
export default {
  data: () => ({
    headers: [
      {
        text: "Device name",
        align: "left",
        value: "name",
      },
      {
        text: "Device Type",
        align: "left",
        value: "deviceTypeName",
      },
      {
        text: "Actions",
        align: "left",
        value: "actions",
      },
    ],
    devices: [],
  }),
  methods: {
    updateRecord(item) {
      console.log(item);
    },
    deleteRecord(item) {
      var index = this.devices.indexOf(item);
      console.log(index);
      ShowConfirmDialog("Are u Sure, Delete Item ?").then(() => {
        this.$store
          .dispatch(DELETE_DEVICES, item)
          .then((payload) => {
            ShowSuccessMessage(payload.message);
            this.devices.splice(index, 1);
          })
          .catch((err) => {
            ShowErrorMessage(err.message);
          });
      });
    },
  },
  created() {
    this.$store
      .dispatch(GET_DEVICES)
      .then(() => {
        this.devices = this.$store.getters.getDevices;
      })
      .catch((err) => {
        ShowErrorMessage(err.message);
      });
  },
};
</script>