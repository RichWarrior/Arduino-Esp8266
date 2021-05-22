<template>
  <div>
    <v-navigation-drawer
      app
      fixed
      inset
      v-model="show"
      color="#34344C"
      @transitionend="sidebarClosed"
    >
      <v-app-bar height="52" elevation="2" color="#34344C">
        <v-toolbar-title class="pa-0">
          <span class="white--text">WFEngine</span>
        </v-toolbar-title>
      </v-app-bar>
      <v-list>
        <v-list-item @click="$router.push({ path: '/dashboard' })">
          <v-list-item-icon>
            <v-icon color="white">fa fa-tachometer-alt</v-icon>
          </v-list-item-icon>
          <span class="white--text"> Dashboard </span>
        </v-list-item>
        <v-list-item @click="$router.push({ path: '/device/list' })">
          <v-list-item-icon>
            <v-icon color="white">fas fa-microchip</v-icon>
          </v-list-item-icon>
          <span class="white--text"> Devices </span>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </div>
</template>

<style>
.v-list-item {
  cursor: pointer;
}
</style>

<script>
export default {
  props: {
    show: {
      required: true,
      type: Boolean,
    },
  },
  data: () => ({}),
  methods: {
    sidebarClosed() {
      if (!this.show) {
        this.$emit("sidebarClosed", this.show);
      }
    },
  },
};
</script>