<template>
    <v-parallax src="@/assets/landing-gradient-background.png" style="height: 180vh; width: 150vw;">
      <div class="d-flex align-center flex-column" style="width: 95vw; margin-left: auto; margin-right: auto">
        <div class="title" style="padding: 10px; margin: 0 auto">Schronisko</div>
  
        <v-sheet class="d-flex align-center flex-column" width="90%" height="161vh" style="z-index: 1; border-radius: 5%">
          <v-sheet class="d-flex align-center flex-column" style="
              position: relative;
              height: 95%;
              top: 1%;
              width: 98%;
              margin-left: auto;
              margin-right: auto;
              border-radius: 5%;
            ">
            <div class="hello-message" style="border-radius: 10%; height: 100%; width: 100%">
              <v-sheet style="
                  float: left;
                  width: 40%;
                  border-radius: 60px;
                  background-color:  rgb(149, 108, 98);
                ">
                <div>
                  <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="main-text">
                    Witamy w menu dla schronisk!
                  </h1>
                </div>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <div style="padding: 10px">
                  <h3 style="
                      color: white;
                      text-shadow: 2px 2px 4px #000000;
                      font-size: medium;
                    " class="main-text">
                    
 Jesteśmy tu, by pomóc w znalezieniu domów pełnych miłości dla Państwa podopiecznych. Przeglądaj profile zwierząt, aktualizuj informacje, zarządzaj adopcjami. Twoje zaangażowanie i troska dają zwierzętom drugą szansę. Dziękujemy za wsparcie i wspólną walkę o lepsze życie dla nich!
                  </h3>
                </div>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <v-btn variant="tonal" color="white" class="main-text">
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
                  <h1 style="color: black" class="main-text">Menu Adopcji</h1>
                  <div style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;"></div>
                </div>
                <div style="padding: 10px">
                  <h3 style="color: black; font-size: medium" class="text">
                    <v-row style="width: fit-content; margin: 0 auto">
                      <PetForm/>
                      <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-heart"> </v-icon>
                        Podopieczni</v-btn>
                      <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                      <ShelterForm />
                      <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text"> <v-icon color="rgb(143, 83, 122)" icon="mdi-briefcase-variant-outline"></v-icon>Adopcje</v-btn>
                    </v-row>
                    
                  </h3>
                </div>
              </v-sheet>
  
              
              
  
              <v-sheet style="
                  float: right;
                  width: 58%;
                  border-radius: 50px;
                  padding-bottom: 10px;
                  position: relative;
                  top: 4vh;
                  height: 140vh;
                  border-color:  rgb(149, 108, 98) ;
                  border-style: solid;
                  border-width: 2px;
                ">
                <div>
                  <h1 style="color: black" class="main-text"><v-icon color="rgb(143, 83, 122)" icon="mdi-filter-outline"></v-icon>Powiadomienia</h1>
                  <div style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;"></div>
                </div>
                <div style="padding: 10px; text-align: center;" >
                  <h3 style="color: black; font-size: medium; text-align: center;" class="text">
                    TUTAJ DODAJ MENU PODOPIECZNYCH
                  </h3>
                </div>
              </v-sheet>
  
              <v-sheet style="
                  float: left;
                  width: 40%;
                  border-radius: 10%;
                  padding-bottom: 10px;
                  position: relative;
                  top: 2vh;
                ">
                <div>
                  <h1 style="color: black" class="main-text">Ustawiena</h1>
                  <div style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;"></div>
                </div>
                <div style="padding: 10px">
                  <h3 style="color: black; font-size: medium" class="text">
                    <v-row style="width: fit-content; margin: 0 auto">
                      <v-btn elevation="8" class="text">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-paw"> </v-icon> Zmień hasło</v-btn>
                      <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text">
                        <v-icon color="rgb(143, 83, 122)" icon="mdi-heart"> </v-icon>
                        Zmień Język</v-btn>
                      <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                      <v-btn elevation="8" class="text"> <v-icon color="rgb(143, 83, 122)" icon="mdi-briefcase-variant-outline"></v-icon>Usuń konto</v-btn>
                    </v-row>
                    
                  </h3>
                </div>
              </v-sheet>
  
  
              <v-sheet style="
                  float: left;
                  width: 40%;
                  background-color: rgb(149, 108, 98, 0.2);
                  padding-bottom: 10px;
                  position: relative;
                  top: 4vh;
                  height: 102vh;
                ">
                <div>
                  <h1 style="color: black" class="main-text"><v-icon color="rgb(143, 83, 122)" icon="mdi-filter-outline"></v-icon>Powiadomienia</h1>
                  <div style="height: 2px; width: 80%; background-color: rgb(143, 83, 122) ; margin: 0 auto; opacity: 0.5;"></div>
                </div>
                <div style="padding: 10px">
                  <h3 style="color: black; font-size: medium; text-align: center;" class="text">
                    TUTAJ DODAJ POWIADOMIENIA
                  </h3>
                </div>
              </v-sheet>
  
  
  
            </div>
          </v-sheet>
        </v-sheet>
      </div>
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
  .title {
    font-family:'Courier New', Courier, monospace;
    font-size: xxx-large;
    font-weight: bolder;
    font-stretch: wider;
    color: white;
    text-shadow: 5px 2px 4px #000000;
  }
  
  .little-title {
    font-family: 'Courier New', Courier, monospace;
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
  
  .main-text {
    font: italic small-caps bold 20px/2 cursive;
    text-align: center;
  }
  
  .text {
    text-align: justify;
    font-family: 'Courier New', Courier, monospace;
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
  </style>
  