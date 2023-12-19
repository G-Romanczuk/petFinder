<template>
  <div class="d-flex align-center flex-column" style=" margin: 0 auto; overflow: visible; position: relative; top: -10vh;">
      <!-- 1 -->
      <v-parallax src="@/assets/spaniel.jpg" style="height: 130vh; width: 100vw; ">
          <v-sheet height="100vh" style=" background: rgb(255, 255, 255, 0) ">
              <v-col style="height: 80vh; margin-top: 20vh; ">

                  <v-row style=" width: 40%; ">
                      <div style=" border-radius: 3%;  width: 90%; margin: 3vh auto ; "
                          class="d-flex align-center flex-column">
                          <div style=" ">
                              <h1 style="color: rgb(91, 30, 133); text-align: center; " class="font">
                                  Marzysz o przygarnięciu uroczego zwierzaka ze schroniska i
                                  ofiarowania mu kochającego domu ?
                              </h1>
                          </div>
                          <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                          <div style="background-color: #000000; width: 80%; height: 1px;"></div>
                          <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                          <div style="display: flex; width: 30vw; ">
                              <div class="scale" style="margin: auto;">
                                  <RegisterPopup />
                              </div>

                          </div>
                          <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                          <div style="background-color: #000000; width: 80%; height: 1px;"></div>
                          <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                          <div style=" ">
                              <h1 style="color: rgb(91, 30, 133); text-align: center; " class="font">
                                  Nasza aplikacja jest tutaj, aby uczynić proces adopcji łatwiejszym i
                                  bardziej emocjonującym niż kiedykolwiek wcześniej !
                              </h1>
                          </div>

                      </div>
                  </v-row>
                  <v-row>

                  </v-row>


              </v-col>
          </v-sheet>
      </v-parallax>






      <!-- 2 -->
      <v-parallax src="@/assets/cat.jpg" style="height: 130vh; width: 100vw; " >
        <div style="height: 10vh;"></div>
          <v-sheet height="100vh" style="width: 100vw; background: rgb(255, 255, 255,0) ">
              <v-row>
                  <v-col style="height: 90vh; margin-top: 3vh; width: 45vw; " class="reveal fade-left">

                      <v-row>
                          <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                          <div style=" border-radius: 3%;  width: 90%; margin: 1vh auto auto 3vh ; "
                              class="d-flex align-center flex-column">
                              <div style=" ">
                                  <p class=" font" style="font-size: 25px; font-weight: 800;">
                                      Dzięki naszej innowacyjnej platformie, możesz przeglądać profile
                                      różnorodnych zwierząt, które poszukują nowego domu. Czy to pies,
                                      kot, królik czy chomik, u nas znajdziesz szeroki wybór zwierzaków
                                      gotowych na nową przygodę. Możesz przeglądać zdjęcia, opisy i
                                      dowiedzieć się więcej o unikalnych cechach każdego zwierzęcia,
                                      takich jak wiek, rasa czy osobowość. <br />



                                  </p>
                              </div>
                          </div>
                      </v-row>
                      <v-row>

                      </v-row>


                  </v-col>

                  <v-col style="height: 90vh; margin-top: 3vh; width: 45vw;  " class="reveal fade-right">
                      <v-row style="height: 60vh;"></v-row>
                      <v-row style="">
                          <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                          <div style=" border-radius: 3%;  width: 90%;   " class="d-flex align-center flex-column">
                              <div style=" ">
                                  <p class=" font" style="font-size: 25px; font-weight: 800; color: beige;">


                                      Nasza aplikacja oferuje nie tylko możliwość przeglądania profili,
                                      ale także umożliwia bezpośredni kontakt z opiekunami
                                      schroniskowymi. Możesz zadawać pytania, dowiedzieć się więcej o
                                      zwierzęciu i ustalić spotkanie adopcyjne. Ponadto, nasza
                                      funkcjonalność przesyłania dokumentów adopcyjnych pozwoli Ci
                                      załatwić wszystkie formalności szybko i bez zbędnych trudności.
                                      <br />
                                  </p>
                              </div>
                          </div>
                      </v-row>
                      <v-row>

                      </v-row>


                  </v-col>
              </v-row>
          </v-sheet>
      </v-parallax>




      <v-parallax src="@/assets/pigs.jpg" style="height: 120vh; width: 100vw; ">
          <v-sheet height="100vh" style="width: 100vw; background: rgb(255, 255, 255,0) ">

              <v-col style="height: 90vh; margin-top: 10vh; width: 80vw; margin-left:  auto; margin-right: auto;  " class="reveal fade-bottom">

                  <v-row>
                      <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                      <div style=" border-radius: 3%;  width: 90%; margin: 1vh auto auto 3vh ; "
                          class="d-flex align-center flex-column">
                          <div style="font-size: 25px; font-weight: 800; text-align: center; " class="font">
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
                              <h3 class="font" style="color:rgb(106, 68, 58); font-weight:900; ">
                                  Nie czekaj dłużej - zarejestruj się już teraz i rozpocznij swoją
                                  przygodę z adopcją zwierzaka!
                              </h3>
                          </div>
                      </div>
                      <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                      <div class="scale" style="margin: auto;">

                          <RegisterPopup />

                      </div>
                  </v-row>
                  <v-row>

                  </v-row>


              </v-col>


          </v-sheet>
      </v-parallax>





<!--

      <v-parallax src="@/assets/catdog.jpg" style="height: 12-vh; width: 100vw; ">
          <v-sheet style="background-color: rgb(255, 255, 255, 0);">
              <div style="height: 35vh;"></div>
              <v-row style="width: 60vw; margin: auto;">

                  <v-img cover src="@/assets/dogs-bars.jpg" class="reveal fade-left"
                      style="  margin: auto 0; border-radius: 5%;width: 15vw; height: 15vw;"></v-img>
                  <v-img cover src="@/assets/paw.png" class="reveal fade-back"
                      style="width: 15vw; height: 18vw; margin: auto 0; border-radius: 5%;"></v-img>
                  <v-img cover src="@/assets/cats-bars.png" class="reveal fade-right"
                      style="width: 15vw; height: 15vw; margin: auto 0; border-radius: 5%;"></v-img>
              </v-row>
              <h1 style="color: bisque; width: 80%; margin: auto; text-align: center; font-size: 30px; font-weight: 900;"
                  class="font">
                  W schroniskach dla zwierząt często znajdują się różnorodne gatunki zwierząt, które zostały
                  uratowane lub
                  porzucone. Warunki życia w schroniskach mogą być trudne, zwłaszcza ze względu na
                  ograniczenia
                  przestrzenne, brak zasobów i nadmiar populacji zwierząt. Oto ogólny opis zwierząt w
                  schronisku i trudnych
                  warunków, z jakimi mogą się borykać:
              </h1>



          </v-sheet>
      </v-parallax>

-->

      <v-carousel cycle show-arrows="hover" hide-delimiters style="height: 120vh; width: 100vw;">
          <v-carousel-item cover>
              <v-parallax src="@/assets/golden.jpg" style="height: 120vh; width: 100vw; ">
                  <div style="height: 80vh; width: 70vw; margin: auto; margin-top: 10vh; ">
                      <h2 class="font"
                          style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 35px; text-align: center;">
                          Psy
                      </h2>
                      <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                      <p class="font" style="font-size: 30px; font-weight: 900;">
                          Psy są najczęściej spotykanymi zwierzętami w schroniskach. Są różnych ras, wielkości i
                          wieku. W
                          schroniskach może brakować miejsca, a psy mogą być umieszczone w małych klatkach lub
                          boksach. Brak
                          odpowiedniej ilości personelu może ograniczać czas spędzany na spacerach i interakcji z
                          człowiekiem.


                      </p>
                  </div>
              </v-parallax>
          </v-carousel-item>

          <v-carousel-item cover>
              <v-parallax src="@/assets/cat-cream.jpg" style="height: 120vh; width: 100vw; ">
                  <div style="height: 80vh; width: 70vw; margin: auto; margin-top: 10vh; ">
                      <h2 class="font"
                          style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 35px; text-align: center;">
                          Koty
                      </h2> <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                      <p class="font" style="font-size: 30px; font-weight: 900;">
                          Koty również są często obecne w schroniskach. Mogą być dzikie, bezdomne lub opuszczone. Koty są
                          bardziej
                          niezależne niż psy, ale nadal wymagają odpowiedniej opieki. Brak wystarczających środków może
                          prowadzić do
                          przeludnienia i trudności w utrzymaniu czystości.

                      </p>
                  </div>
              </v-parallax>

          </v-carousel-item>

          <v-carousel-item cover>
              <v-parallax src="@/assets/parrot.jpg" style="height: 120vh; width: 100vw; ">
                  <div style="height: 80vh; width: 70vw; margin: auto; margin-top: 10vh; ">
                      <h2 class="font"
                          style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 35px; text-align: center;">
                          Ptaki
                      </h2> <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                      <p class="font" style="font-size: 30px; font-weight: 900;">

                          Schroniska mogą również przyjmować porzucone ptaki, takie jak papugi, kanarki czy gołębie. Ptaki
                          potrzebują
                          odpowiedniego miejsca do lotu, a także regularnego karmienia i opieki. Często są umieszczane w
                          dużych
                          klatkach, ale brak interakcji i swobody może być dla nich trudnym doświadczeniem.

                      </p>
                  </div>
              </v-parallax>

          </v-carousel-item>

          <v-carousel-item cover>
              <v-parallax src="@/assets/hamster.jpg" style="height: 120vh; width: 100vw; ">
                  <div style="height: 80vh; width: 70vw; margin: auto; margin-top: 10vh; ">
                      <h2 class="font"
                          style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 35px; text-align: center;">
                          Gryzonie
                      </h2> <v-divider :thickness="40" class="border-opacity-0"></v-divider>
                      <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                      <p class="font" style="font-size: 30px; font-weight: 900;">
                          Często można spotkać króliki, chomiki, świnki morskie i inne gryzonie. Te zwierzęta potrzebują
                          odpowiednich
                          klatek, miejsca do aktywności i regularnej opieki weterynaryjnej. Brak odpowiedniej diety i brak
                          środków
                          może wpływać na ich zdrowie i dobre samopoczucie.


                      </p>
                  </div>

              </v-parallax>
          </v-carousel-item>
      </v-carousel>






      <v-img src="@/assets/lineup.jpg" style="height: 100vh; width: 100vw; ">

          <div style=" width: 60%; margin: auto; margin-top: 15vh;">

              <p class="font reveal fade-bottom" style="text-align: center; font-size: 25px; font-weight: 900;" >




                  Wszystkie zwierzęta w schroniskach często borykają się z ograniczeniem przestrzeni, brakiem
                  odpowiedniej
                  opieki weterynaryjnej, niedostatecznymi środkami finansowymi i brakiem stałych domów. Schroniska
                  stawiają
                  sobie za cel zapewnienie tym zwierzętom schronienia, opieki i możliwości adopcji przez
                  odpowiedzialnych
                  opiekunów. Jednakże, warunki życia w schroniskach mogą być trudne dla zwierząt i podkreślają
                  potrzebę
                  świadomości społecznej i wsparcia dla adopcji zwierząt ze schronisk oraz działań mających na
                  celu
                  zapobieganie porzucaniu i nadmiernemu rozmnażaniu się zwierząt. <br>
                  <v-divider :thickness="80" class="border-opacity-0"></v-divider>
              <h3 class="font" style="color:rgb(175, 126, 158); font-size: 30px; font-weight: 900;">
                  Nie czekaj dłużej - zarejestruj się już teraz i rozpocznij swoją
                  przygodę z adopcją zwierzaka!
              </h3>
              </p>
              <v-divider :thickness="80" class="border-opacity-0"></v-divider>
              <div class="scale reveal fade-bottom">
                  <RegisterPopup />
              </div>
              

          </div>

      </v-img>

  </div>
</template>

<script setup lang="ts">
import LoginPopup from '@/components/LoginPopup.vue';
import RegisterPopup from '@/components/RegisterPopup.vue';
import { useNotificationsStore } from '@/store/notifications';
import { shallowEqual } from '@babel/types';
import test from 'node:test';
import { onMounted, ref } from 'vue';


const notifStore = useNotificationsStore();

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

<script lang="js">


</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');


.font {
  font-family: 'Gruppo', sans-serif;
}

.scale :hover {
  transform: scale(1.45);
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

.active.fade-bottom {
  animation: fade-bottom 2s ease-in;
}

.active.swing-in{
  animation: swing-in 1.5s ease-in 0s 1 normal forwards;
}

.active.swing-out{
  animation: swing-out 1.5s ease-in 0s 1 normal forwards;
}

@keyframes swing-in {
0% {
  opacity: 0;
  transform: rotateY(-70deg);
  transform-origin: left;
}

100% {
  opacity: 1;
  transform: rotateY(0);
  transform-origin: left;
}
}

@keyframes swing-out {
0% {
  opacity: 1;
  transform: rotateY(0);
  transform-origin: left;
}

100% {
  opacity: 0;
  transform: rotateY(-70deg);
  transform-origin: left;
}
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


@keyframes fade-bottom {
  0% {
      transform: translateY(200px);
      opacity: 0;
  }

  100% {
      transform: translateX(0);
      opacity: 1;
  }
}
</style>
