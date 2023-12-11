<template>
    <v-dialog v-model="dialog" max-width="60vw"  >
        <template v-slot:activator="{ props }">
            <div elevation="7" class="d-flex align-center flex-column font circle circle-hover" v-bind="props" style="border-radius: 50%;"><v-icon  icon="mdi-help-circle-outline" size="x-large"></v-icon></div>
        </template>
        
      
        <div class="d-flex align-center flex-column" style="width: 50vw; height: 70vh; margin-left: auto; margin-right: auto;">
            <v-sheet style="
                  float: left;
                  width: 100%;
                  border-radius: 60px;
                  background-color:  rgb(149, 108, 98);
                ">
                <div style="margin: 0 auto; width: fit-content;">
                  <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="font">
                    Witamy w menu dla schronisk!
                  </h1>
                </div>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <div style="padding: 5px; text-align: center;">
                  <h3 style="
                      color: white;
                      text-shadow: 2px 2px 4px #000000;
                      font-size: large;
                    " class="font">

                    Jesteśmy tu, by pomóc w znalezieniu domów pełnych miłości dla Państwa podopiecznych. Przeglądaj
                    profile zwierząt, aktualizuj informacje, zarządzaj adopcjami. Twoje zaangażowanie i troska dają
                    zwierzętom drugą szansę. Dziękujemy za wsparcie i wspólną walkę o lepsze życie dla nich!
                  </h3>
                </div>
                <div  style="margin: 0 auto; width: fit-content;">
                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <v-btn variant="tonal" color="white" class="font">
                  Instrukcja</v-btn>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                </div>
              </v-sheet>

        </div>
    </v-dialog>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import { useUserStore } from '@/store/user';
 
        var dialog = ref(false)
  
  
  
  
    
  
  
  </script>
  
  <style lang="css">
  @import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');
  
  
  .font {
    font-family: 'Gruppo', sans-serif;
    text-decoration: none;
  font-weight:900;
  }
  
  
  
  .scale :hover {
    transform: scale(1.2);
  }
  
  
  
  
  .title {
    font-family: 'Gruppo', sans-serif;
    font-size: xxx-large;
    font-weight: bolder;
    font-stretch: wider;
    color: white;
    text-shadow: 5px 2px 4px #000000
  }
  
  .little-title {
    font-family: 'Gruppo', sans-serif;
    font-weight: bold;
    font-size: medium;
    color: rgb(175, 126, 158);
  }
  
  
  .scrollbar::-webkit-scrollbar-track {
    -webkit-box-shadow: inset 0 0 0px rgba(0, 0, 0, 0.3);
    background-color: transparent;
    border-radius: 10px;
  }
  
  .scrollbar::-webkit-scrollbar {
    display: block;
    width: 15px;
  }
  
  .scrollbar::-webkit-scrollbar-thumb {
    border-radius: 10px;
    background-image: -webkit-gradient(linear,
            left bottom,
            left top,
            color-stop(0.14, rgb(235, 196, 222)),
            color-stop(0.24, rgb(221, 167, 202)),
            color-stop(0.52, rgb(175, 126, 158)),
            color-stop(0.86, rgb(131, 70, 109)));
  }
  
  .scrollbar::-webkit-scrollbar-track-piece:end {
    background: transparent;
    margin-bottom: 3vh;
  }
  
  .scrollbar::-webkit-scrollbar-track-piece:start {
    background: transparent;
    margin-top: 3vh;
  }

  .circle{
    border-radius: 50%;
  }

  .circle-hover :hover {
    opacity: 0.5;
  }
  </style>