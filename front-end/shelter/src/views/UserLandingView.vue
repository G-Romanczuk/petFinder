<template>
  <v-parallax src="@/assets/mainBackground.png">
    <div class="d-flex align-center flex-column" style="width: 95vw; margin-left: auto; margin-right: auto">
      <div class="title" style="padding: 10px; margin: 0 auto">Adoptujący</div>

      <v-sheet class="d-flex align-center flex-column" width="90%" height="197vh" style="z-index: 1; border-radius: 5%">
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
                border-radius: 10%;
                background-color: rgb(143, 83, 122);
              ">
              <div>
                <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="main-text">
                  Witaj, {{ store.userData.name }}!
                </h1>
              </div>
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              <div style="padding: 10px">
                <h3 style="
                    color: white;
                    text-shadow: 2px 2px 4px #000000;
                    font-size: medium;
                  " class="main-text">
                  Witamy w naszym menu adopcyjnym! Odkryj niesamowitych
                  przyjaciół, którzy czekają na swoje wieczne domy. Przeglądaj
                  profile, wyszukuj według preferencji i zapisuj ulubione.
                  Skontaktuj się z opiekunami, uzgodnij spotkanie i rozpocznij
                  nową, pełną miłości przygodę. Znajdź swoje idealne zwierzę i
                  stwórzcie razem szczęśliwe zakończenie!
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
                background-color: rgb(252, 220, 240);
              ">
              <div>
                <h1 style="color: black" class="main-text">Menu</h1>
              </div>
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              <div style="padding: 10px">
                <h3 style="color: black; font-size: medium" class="text">
                  <v-row style="width: 100%; margin: 0 auto">
                    <v-btn elevation="8" class="text">
                      <v-icon color="rgb(143, 83, 122)" icon="mdi-paw"> </v-icon> Znajdź przyjaciela</v-btn>
                    <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                    <v-btn elevation="8" class="text">
                      <v-icon color="rgb(143, 83, 122)" icon="mdi-heart"> </v-icon>
                      Polubione</v-btn>
                    <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                    <UserForm />
                    <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                    <v-btn elevation="8" class="text"> <v-icon color="rgb(143, 83, 122)" icon="mdi-briefcase-variant-outline"></v-icon>Moje adopcje</v-btn>
                  </v-row>
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
import UserForm from "@/components/UserForm.vue";
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
  font-family: cursive;
  font-size: xxx-large;
  font-weight: bolder;
  font-stretch: wider;
  color: white;
  text-shadow: 5px 2px 4px #000000;
}

.little-title {
  font-family: cursive;
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
  font-family: "Gill Sans", "Gill Sans MT", Calibri, "Trebuchet MS", sans-serif;
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
