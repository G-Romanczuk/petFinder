<template>
  <v-parallax src="@/assets/spaniel-background.jpg" style="height: 100vh; width: 100vw; ">
    <v-row style="width: 100vw; background-color: rgb(255, 255, 255, 0);">
      <v-col style="width: 70vw; height: 90vh; background-color: rgb(255, 255, 255, 0);">  
        <div class="d-flex align-center flex-column" style="width: 75vw; margin-left: auto; margin-right: auto; ">
      <div class="title" style="padding: 5px; margin: 0 auto">Schronisko</div>
    </div>
          <v-sheet class="d-flex align-center flex-column" style="background-color: rgb(255, 255, 255, 0);">
            <div class="hello-message" style="border-radius: 10px;  width: 99%; background-color: rgb(255, 255, 255, 0);">
              <v-sheet style="
                  float: left;
                  width: 40%;
                  border-radius: 60px;
                  background-color:  rgb(149, 108, 98);
                ">
                <div>
                  <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="font">
                    Witamy w menu dla schronisk!
                  </h1>
                </div>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <div style="padding: 5px">
                  <h3 style="
                      color: white;
                      text-shadow: 2px 2px 4px #000000;
                      font-size: medium;
                    " class="font">

                    Jesteśmy tu, by pomóc w znalezieniu domów pełnych miłości dla Państwa podopiecznych. Przeglądaj
                    profile zwierząt, aktualizuj informacje, zarządzaj adopcjami. Twoje zaangażowanie i troska dają
                    zwierzętom drugą szansę. Dziękujemy za wsparcie i wspólną walkę o lepsze życie dla nich!
                  </h3>
                </div>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <v-btn variant="tonal" color="white" class="font">
                  Instrukcja</v-btn>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              </v-sheet>

              <v-sheet style="
                  float: right;
                  width: 58%;
                  border-radius: 10%;
                  padding-bottom: 10px;
                ">
                <div>
                  <h1 style="color: black" class="font">Menu Adopcji</h1>
                  <div
                    style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;">
                  </div>
                </div>
                <div style="padding: 5px">
                  <h3 style="color: black; font-size: medium" class="text">
                    <v-row style="width: fit-content; margin: 0 auto">
                      <PetForm />
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-heart"> </v-icon>
                        Podopieczni</v-btn>
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <ShelterForm />
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text"> <v-icon color="rgb(143, 83, 122)"
                          icon="mdi-briefcase-variant-outline"></v-icon>Adopcje</v-btn>
                    </v-row>

                  </h3>
                </div>
              </v-sheet>





              <v-sheet style="
                  float: left;
                  width: 40%;
                  border-radius: 10%;
                  position: relative;
                  top: 2vh;
                ">
                <div>
                  <h1 style="color: black" class="font">Ustawiena</h1>
                  <div
                    style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;">
                  </div>
                </div>
                <div style="padding: 5px">
                  <h3 style="color: black; font-size: medium" class="text">
                    <v-row style="width: fit-content; margin: 0 auto">
                      <v-btn elevation="8" class="text">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-paw"> </v-icon> Zmień hasło</v-btn>
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-heart"> </v-icon>
                        Zmień Język</v-btn>
                      <v-divider vertical :thickness="10" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text"> <v-icon color="rgb(143, 83, 122)"
                          icon="mdi-briefcase-variant-outline"></v-icon>Usuń konto</v-btn>
                    </v-row>

                  </h3>
                </div>
              </v-sheet>


              



            </div>
          </v-sheet>
       
      </v-col >
      <v-col style="max-width: 27vw; ">
        <v-sheet class="d-flex align-center flex-column" style="margin-top: 2vh; background-color: rgb(255, 255, 255, 0);">
             <v-sheet style="
                  float: right;
                  width: 90%;
                  border-radius: 10px;
                  padding-bottom: 10px;
                  border-color:  rgb(149, 108, 98) ;
                  border-style: solid;
                  border-width: 2px;
                  height: 50vh;
                  overflow-y: scroll;
                ">
                <div>
                  <h1 style="color: black" class="font"><v-icon color="rgb(143, 83, 122)"
                      icon="mdi-filter-outline"></v-icon>Powiadomienia</h1>
                  <div
                    style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;">
                  </div>
                </div>
                <div style="padding: 5px; text-align: center;">
                  <h3 style="color: black; font-size: medium; text-align: center;" class="text">
                    TUTAJ DODAJ MENU PODOPIECZNYCH
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
import { useUserStore } from "@/store/user";
const store = useUserStore();

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
  color: white;
  text-shadow: 5px 2px 4px #000000;
}

.little-title {
  font-family: 'Gruppo', sans-serif;
  font-weight: bold;
  font-size: medium;
  color: rgb(175, 126, 158);
  text-shadow: 1px 2px 2px #000000;
}

.hello-message {
  text-align: center;
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 20px;
  padding-bottom: 20px;
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
}</style>
  