<template>
 <v-app>
    <v-main>
      <arduino-toolbar :show="sidebarShow" v-on:sidebarClosed="sidebarStatusChanged"></arduino-toolbar>
      <arduino-sidebar :show="sidebarShow" v-on:sidebarClosed="sidebarClosed"></arduino-sidebar>
      <v-main class="pa-0">
        <router-view></router-view>
      </v-main>
    </v-main>
  </v-app>
</template>

<script>
export default{
  data:()=> ({
    sidebarShow : true
  }),
  methods:{
    sidebarStatusChanged(){
      this.sidebarShow = !this.sidebarShow;
    },
    sidebarClosed(val){
      this.sidebarShow = val;
    }
  }
}
</script>