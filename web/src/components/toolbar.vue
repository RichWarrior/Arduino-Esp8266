<template>
  <div>
    <v-app-bar class="gradient" height="52">
      <v-app-bar-nav-icon @click="sidebarStatusChange">
        <v-icon color="white">fa fa-bars</v-icon>
      </v-app-bar-nav-icon>
      <v-toolbar-title class="pa-0" v-if="!show">
        <span class="white--text">WFEngine</span>
      </v-toolbar-title>
      <v-row class="ml-2">
        <v-spacer></v-spacer>  
      </v-row>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  props: {
    show: {
      required: true,
      type: Boolean,
    },
  },
  methods:{
      sidebarStatusChange() {
      this.$emit("sidebarClosed");
    },
  }
};
</script>

<style scoped>
.v-toolbar__content {
  margin: 0px !important;
  padding: 0px !important;
}
.avatar {
  cursor: pointer;
}
.v-list-item {
  cursor: pointer;
}
</style>