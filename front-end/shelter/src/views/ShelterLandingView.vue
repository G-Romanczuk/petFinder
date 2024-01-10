<template>
  <v-parallax src="@/assets/spaniel-background.jpg" style=" width: 100vw; height: 100vh;">
    <v-row style="width: 100vw; background-color: rgb(255, 255, 255, 0);">
      <v-col style="width: 70vw; height: 100vh; background-color: rgb(255, 255, 255, 0);">
        <div class="d-flex align-center flex-column" style="width: 75vw; margin-left: auto; margin-right: auto;">
          <div class="title" style="padding: 5px; margin: 0 auto; color: rgb(255, 255, 255); "> Menu <div
              style="display: inline-block; font-size: small; margin-bottom: auto; ">
              <ShelterInfo />
            </div>
          </div>

        </div>
        <v-sheet class="d-flex align-center flex-column" style="background-color: rgb(255, 255, 255, 0);">
          <div class="hello-message" style="border-radius: 10px;  width: 99%; ">



            <v-card>
              <v-tabs v-model="tab" color="rgb(143, 83, 122)" class="text cards">
                <v-tab value="one" class="cards font-bigger">Podopieczni</v-tab>
                <v-tab value="two" class="cards font-bigger">Potencjalne Adopcje</v-tab>
                <v-tab value="three" class="cards font-bigger">Konto</v-tab>
              </v-tabs>
              <div style="height: 2px; width: 100%; background-color:rgb(143, 83, 122) ; margin-right: auto; ">
              </div>
              <v-card-text>

                <v-window v-model="tab" class="text">
                  <v-window-item value="one">

                    <div style="height: 78vh; ">
                      <v-row style="width: fit-content; margin: 0 auto; padding-bottom: 10px; height: 6vh; ">
                        <PetForm />
                        <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                        <v-btn elevation="8" class="text font-big">
                          <v-icon color="rgb(143, 83, 122)" icon="mdi-dog"> </v-icon>
                          Psy</v-btn>
                        <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                        <v-btn elevation="8" class="text font-big">
                          <v-icon color="rgb(143, 83, 122)" icon="mdi-cat"> </v-icon>
                          Koty</v-btn>
                        <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                        <v-btn elevation="8" class="text font-big">
                          <v-icon color="rgb(143, 83, 122)" icon="mdi-rodent"> </v-icon>
                          Gryzonie</v-btn>
                        <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                        <v-btn elevation="8" class="text font-big">
                          <v-icon color="rgb(143, 83, 122)" icon="mdi-bird"> </v-icon>
                          Ptaki</v-btn>
                        <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                        <v-btn elevation="8" class="text font-big">
                          <v-icon color="rgb(143, 83, 122)" icon="mdi-heart"> </v-icon>
                          Inne</v-btn>
                        <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>

                      </v-row>



                      <div
                        style="width: 100%; display: grid; grid-template-columns:repeat(4, 25% [col-start]); height: 72vh; overflow-y: scroll; overflow-x: hidden; margin: auto; "
                        class="scrollbar">



                        <div v-for="(pet, i) in shelterStore.shelterData.pets"
                          style="width: 300px; height: 370px; padding: 10px;" class="scale"  >
                          <PetPopup :pet="pet" >
                            <template #activator>
                              <div style="height: 10px;"></div>
                              <v-card class="mx-auto dontscale" width="260" height="350">
                                <v-img cover v-bind:src="pet.images[0]"
                                  style="margin: auto; width: 90%; border-radius: 10px; height: 80%;" />

                                <v-card-title class="font">

                                  {{ pet.name }} , {{ pet.age }}
                                </v-card-title>

                                <v-card-subtitle class="font">
                                 Wykastrowany/a: {{ pet.castration}}
                                </v-card-subtitle>


                              </v-card>


                            </template>
                          </PetPopup>
                        </div>



                      </div>
                    </div>








                  </v-window-item>

                  <v-window-item value="two">
                    <v-row style="width: fit-content; margin: 0 auto; padding-bottom: 10px; height: 78vh;">



                    </v-row>
                  </v-window-item>

                  <v-window-item value="three">
                    <v-row style="width: fit-content; margin: 0 auto; padding-bottom: 10px; height: 78vh;">

                      <ShelterForm />
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text font-big">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-lock-reset"> </v-icon> Zmień hasło</v-btn>
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text font-big">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-translate"> </v-icon>
                        Zmień Język</v-btn>
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text font-big"> <v-icon color="rgb(143, 83, 122)"
                          icon="mdi-delete-empty"></v-icon>Usuń konto</v-btn>

                    </v-row>
                  </v-window-item>
                </v-window>
              </v-card-text>
            </v-card>


          </div>
        </v-sheet>

      </v-col>
      <v-col style="max-width: 27vw; ">
        <v-sheet class="d-flex align-center flex-column"
          style="margin-top: 2vh; background-color: rgb(255, 255, 255, 0);">
          <v-sheet class="scrollbar" style="
                  float: right;
                  width: 90%;
                  border-radius: 10px;
                  padding-bottom: 10px;
                  border-color:  rgb(149, 108, 98, 0.5) ;
                  border-style: solid;
                  border-width: 2px;
                  height: 50vh;
                  overflow-y: scroll;
                  background-color: rgba(255, 255, 255, 0.5) ;
                  
                ">
            <div style="width: fit-content; margin: 0 auto;">
              <h1 style="color: black; font-size:large;" class="font"><v-icon color="rgb(143, 83, 122)"
                  icon="mdi-filter-outline"></v-icon>Powiadomienia</h1>

            </div>
            <div style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;">
            </div>
            <div style="padding: 5px; text-align: center;">
              <h3 style="color: black; font-size: medium; text-align: center; height: fit-content; padding: 10px;"
                class="text">
                TUTAJ DODAJ POWIADOMIENIA

             





              </h3>
            </div>
          </v-sheet>
        </v-sheet>
      </v-col>

    </v-row>





  </v-parallax>
</template>
  
<script setup lang="ts">
import ShelterForm from "@/components/ShelterForm.vue";
import PetForm from "@/components/PetForm.vue";
import ShelterInfo from "@/components/ShelterInfo.vue";
import PetPopup from "@/components/PetPopup.vue";
import { ref } from "vue";
import { useShelterStore } from '@/store/shelter';

const shelterStore = useShelterStore();
shelterStore.getShelterPets(shelterStore.shelterData.email)

async function showPet(pet){

}

var tab = ref(null)
function reveal() {
  var reveals = document.querySelectorAll(".reveal");

  for (var i = 0; i < reveals.length; i++) {
    var windowHeight = window.innerHeight;
    var elementTop = reveals[i].getBoundingClientRect().top;
    var elementVisible = 150;

    if (elementTop < windowHeight - elementVisible) {
      reveals[i].classList.add("active");
    } else {
      reveals[i].classList.remove("active");
    }
  }
}

window.addEventListener("scroll", reveal);
</script>
  
<script lang="js"></script>
  
<style>
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');

.cards {
  font-size: large;
  font-weight: 900;
}

.font {
  font-family: 'Gruppo', sans-serif;
  text-decoration: none;
  font-weight: 900;
}

.title {
  font-family: 'Gruppo', sans-serif;
  font-size: xxx-large;
  font-weight: bolder;
  font-stretch: wider;
  color: rgb(255, 255, 255);
  text-shadow: 4px 2px 2px #000000;
}



.hello-message {
  text-align: center;
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 20px;
  padding-bottom: 20px;
}

.scale :hover {
  transform: scale(1.1);
  z-index: 1;
}

.dontscale :hover {
  transform: scale(1);
  z-index: 1;
}
.text {
  text-align: justify;
  font-family: 'Gruppo', sans-serif;
}

.reveal {
  position: relative;
  opacity: 0;
}

.reveal.active {
  opacity: 1;
}

.active.fade-left {
  animation: fade-left 2s ease-in;
}

.active.fade-right {
  animation: fade-right 2s ease-in;
}

.active.fade-back {
  animation: fade-back 2s ease-in;
}

@keyframes fade-left {
  0% {
    transform: translateX(-100px);
    opacity: 0;
  }

  100% {
    transform: translateX(0);
    opacity: 1;
  }
}

@keyframes fade-right {
  0% {
    transform: translateX(100px);
    opacity: 0;
  }

  100% {
    transform: translateX(0);
    opacity: 1;
  }
}

@keyframes fade-back {
  0% {
    transform: translateZ(-100px);
    opacity: 0;
  }

  100% {
    transform: translateX(0);
    opacity: 1;
  }

}

.font-big {
  font-size: large;
  font-weight: 600;
}

.font-bigger {
  font-size: x-large;
  font-weight: 900;
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
</style>
  