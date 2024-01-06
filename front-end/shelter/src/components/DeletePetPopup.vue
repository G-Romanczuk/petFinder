<template>
    <v-dialog v-model="dialog" max-width="60vw"  >
        <template v-slot:activator="{ props }">
           
            <v-btn elevation="8" class="text font-big" v-bind="props">Usuń</v-btn>
        </template>
        
      
        <div class="d-flex align-center flex-column" style="width: 50vw; height: fit-content; margin: auto;">
            <v-sheet  style="
                float: left;
                width: 100%;
                border-radius: 60px;
                background-color: rgb(61, 50, 53);
              ">
             
              <div style="padding: 10px; margin: auto; width: fit-content; text-align: center;">
                <h3 style="
                    color: white;
                    text-shadow: 2px 2px 4px #000000;
                    font-size: x-large;
                  " class="font">
                    Uwaga! <br> usunięcie zwierzęcia z listy jest trwałe! Czy na pewno chcesz usunąć? <br> 

                   
                </h3>
              </div>
              <div style="width: fit-content; margin: 0 auto;">
                <v-btn   class="little-title" @click="shelterStore.deletePet(props.id), dialog = false">USUŃ</v-btn>
                <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                    <v-btn  class="little-title" @click="dialog = false">Zrezygnuj</v-btn>
              </div>
             
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            </v-sheet>

        </div>
    </v-dialog>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue'
  import { useShelterStore } from '@/store/shelter';
  const props = defineProps({
    id: Number
})


        var dialog = ref(false)
        const shelterStore = useShelterStore();
  
  
  
    
  
  
  </script>
  
  <style lang="css">
  @import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');
  
  
  .font {
    font-family: 'Gruppo', sans-serif;
    text-decoration: none;
  font-weight:900;
  }
  
  
/*   
  .scale :hover {
    transform: scale(1.2);
  }
   */
  
  
  
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