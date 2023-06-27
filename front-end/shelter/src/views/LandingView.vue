<template>
  <v-parallax src="@/assets/landing-pink-gradient.png" style="position: absolute; height: 100vh; top: 0; "></v-parallax>
  <div class="d-flex align-center flex-column" style="width: 80vw; margin-left: auto; margin-right: auto">
    <v-sheet style="position: relative; z-index: 1">
      <v-row no-gutters style="height: 0vh">
        <v-col cols="6">
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          <v-container style="background-color: rgb(35, 125, 100); border-radius: 3%"
            class="d-flex align-center flex-column">
            <div class="hello-message">
              <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="main-text">
                Czy marzysz o przygarnięciu uroczego zwierzaka ze schroniska i
                ofiarowania mu kochającego domu?
              </h1>
            </div>
            <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            <v-img src="@/assets/pets.png" width="200px" style="border-radius: 50%;"></v-img>
            <v-divider :thickness="30" class="border-opacity-0"></v-divider>
            <div style="display: flex">
              <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text">Rejestracja</v-btn>
              <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
              <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text">Logowanie</v-btn>
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            </div>
          </v-container>
        </v-col>

        <v-col>
          <div>
            <img src="@/assets/dog.png" style="position: relative; top: 5vh; left: 5vw" />
          </div>
        </v-col>
      </v-row>
    </v-sheet>
      <div style="height: 45vh;"></div>
    <v-sheet class="d-flex align-center flex-column" width="90vw" height="90vh">
      <v-parallax src="@/assets/landing-gradient-background.png">
        <v-sheet class="d-flex align-center flex-column" style="
            position: relative;
            height: 70%;
            top: 15vh;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
          ">
          <v-sheet style="opacity: 0.8" class="d-flex align-center flex-column" height="40%">
            <div class="hello-message">
              <v-sheet style="float: right; display: block; width: 33%; height: 180px"></v-sheet>
              <h3>
                Nasza aplikacja jest tutaj, aby uczynić ten proces łatwiejszym i
                bardziej emocjonującym niż kiedykolwiek wcześniej.
              </h3>

              Dzięki naszej innowacyjnej platformie, możesz przeglądać profile
              różnorodnych zwierząt, które poszukują nowego domu. Czy to pies,
              kot, królik czy chomik, u nas znajdziesz szeroki wybór zwierzaków
              gotowych na nową przygodę. Możesz przeglądać zdjęcia, opisy i
              dowiedzieć się więcej o unikalnych cechach każdego zwierzęcia,
              takich jak wiek, rasa czy osobowość. <br />

              Nasza aplikacja oferuje nie tylko możliwość przeglądania profili,
              ale także umożliwia bezpośredni kontakt z opiekunami
              schroniskowymi. Możesz zadawać pytania, dowiedzieć się więcej o
              zwierzęciu i ustalić spotkanie adopcyjne. Ponadto, nasza
              funkcjonalność przesyłania dokumentów adopcyjnych pozwoli Ci
              załatwić wszystkie formalności szybko i bez zbędnych trudności.
              <br />

              Wierzymy, że każde zwierzę zasługuje na kochający dom i
              troskliwego opiekuna. Dlatego stworzyliśmy tę aplikację, aby
              połączyć ludzi, którzy szukają zwierzaka do adopcji, z tymi,
              którzy starają się znaleźć bezpieczne i kochające środowisko dla
              swoich podopiecznych. <br />

              Dołącz do naszej społeczności i spraw, by Twoje serce zostało
              skradzione przez urocze zwierzaki! Zostań częścią naszego ruchu
              adopcyjnego i pomóż nam zwiększyć liczbę adopcji zwierząt ze
              schronisk. Razem możemy tworzyć prawdziwie szczęśliwe zakończenia
              dla tych wspaniałych istot. <br />
              <br />
              <h3>
                Nie czekaj dłużej - zarejestruj się już teraz i rozpocznij swoją
                przygodę z adopcją zwierzaka!
              </h3>
            </div>
          </v-sheet>
        </v-sheet>
      </v-parallax>
    </v-sheet>
    <div style="height: 1000px"></div>
  </div>

</template>

<script lang="ts">
import { setgroups } from "process";

export default {
  name: "LandingView",

  setup() { },
};
</script>

<style>
.hello-message {
  text-align: center;
  padding-left: 20px;
  padding-right: 20px;
  padding-top: 20px;
  padding-bottom: 20px;
}

.main-text {
  font: italic small-caps bold 20px/2 cursive;
}
</style>
