<template>
    <v-app-bar :elevation="2" app  dark scroll-behavior="hide" >
        <div class="d-flex align-center">
            <a href="http://127.0.0.1:3000/">
        <img src="/homeIcon.png" style="height: 120px;" alt="logo" class="shrink mr-2" transition="scale-transition" height="150">   
        </a>         
        </div>
        <v-app-bar-title style="position: relative; left: -1%; font-size: 40px;">
            <a href="http://127.0.0.1:3000/" class="link"> ShelterFinder</a>
           
        </v-app-bar-title>
  <template v-slot:append>
    <v-btn icon="mdi-heart"></v-btn>

    <v-btn icon="mdi-magnify"></v-btn>

    <v-btn icon="mdi-dots-vertical"></v-btn>
  </template>
</v-app-bar>
  </template>
  
  <script lang="ts">
  
  export default {
    name: "AppHeader",
  
    components: {
     
    },
  };
  </script>

  <style lang="css" scoped>
.link{
    text-decoration: none;
    font-weight: bolder;
    font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
}


</style>
  