<template>
  
  <v-parallax src="@/assets/landing-pink-gradient.png"
    style="position: absolute; height: 80vh; width: 100vw; top: 0; "></v-parallax>
  <div class="d-flex align-center flex-column" style="width: 80vw; margin-left: auto; margin-right: auto">
    <v-sheet style="position: relative; z-index: 1">
      <v-row no-gutters style="height: 0vh">
        <v-col cols="6">
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          <v-container style="background-color: rgb(35, 125, 100); border-radius: 3%"
            class="d-flex align-center flex-column">
            <div>
              <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="main-text">
                Czy marzysz o przygarnięciu uroczego zwierzaka ze schroniska i
                ofiarowania mu kochającego domu?
              </h1>
            </div>
            <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            <v-img src="@/assets/pets.png" width="200px" style="border-radius: 50%;"></v-img>
            <v-divider :thickness="30" class="border-opacity-0"></v-divider>
            <div style="display: flex">
              <RegisterPopup />
              <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
              <LoginPopup  />
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            </div>
          </v-container>
        </v-col>

        <v-col>
          <div>
            <img src="@/assets/dog.png" style="position: relative; top: 5vh; left: 5vw; height: 690px;" />
          </div>
        </v-col>
      </v-row>
    </v-sheet>
    <div style="height: 38vh;"></div>
    <v-sheet class="d-flex align-center flex-column" width="90vw" height="90vh">
      <v-parallax src="@/assets/landing-gradient-background.png">
        <v-sheet class="d-flex align-center flex-column" style="
            position: relative;
            height: 70%;
            top: 15vh;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            border-radius: 10%;
          ">
          <v-sheet class="d-flex align-center flex-column" style="border-radius: 10%;">
            <div class="hello-message" style="border-radius: 10%;">
              <v-sheet style="float: right; display: block; width: 33%; height: 180px; border-radius: 10%;"></v-sheet>
              <h2 class="main-text"
                style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 22px; color: rgb(35, 125, 100);">
                Nasza aplikacja jest tutaj, aby uczynić proces adopcji łatwiejszym i
                bardziej emocjonującym niż kiedykolwiek wcześniej.
              </h2>
              <br><br>
              <p class="text">
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
              <h3 class="main-text" style="color: rgb(35, 125, 100);">
                Nie czekaj dłużej - zarejestruj się już teraz i rozpocznij swoją
                przygodę z adopcją zwierzaka!
              </h3>
              </p>
            </div>
            <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text" @click="$router.push('/register')">Rejestracja</v-btn>
          </v-sheet>
        </v-sheet>
      </v-parallax>
    </v-sheet>
    <v-divider :thickness="50" class="border-opacity-0"></v-divider>
    <v-sheet>
      <v-row>
        <v-img cover src="@/assets/dogs-bars.jpg" class="reveal fade-left"
          style=" width: 25vw; height: 25vh; margin: auto 0; border-radius: 5%;"></v-img>
        <v-img cover src="@/assets/paw.png" class="reveal fade-back" style="width: 30vw; margin: auto 0"></v-img>
        <v-img cover src="@/assets/cats-bars.png" class="reveal fade-right"
          style=" width: 25vw; height: 25vh; margin: auto 0; border-radius: 5%;"></v-img>
      </v-row>
    </v-sheet>
    <v-divider :thickness="50" class="border-opacity-0"></v-divider>
    <v-sheet style="position: relative; z-index: 2">
      <v-row no-gutters style="height: 0vh">

        <v-col>
          <div>
            <img src="@/assets/cat.png" style="position: relative;   height: 690px;" />
          </div>
        </v-col>

        <v-col cols="6">
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          <v-container style="background-color: rgb(175, 126, 158); border-radius: 3%"
            class="d-flex align-center flex-column">
            <v-divider :thickness="30" class="border-opacity-0"></v-divider>
            <div>
              <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="main-text">
                W schroniskach dla zwierząt często znajdują się różnorodne gatunki zwierząt, które zostały uratowane lub
                porzucone. Warunki życia w schroniskach mogą być trudne, zwłaszcza ze względu na ograniczenia
                przestrzenne, brak zasobów i nadmiar populacji zwierząt. Oto ogólny opis zwierząt w schronisku i trudnych
                warunków, z jakimi mogą się borykać:
              </h1>
            </div>

            <v-divider :thickness="30" class="border-opacity-0"></v-divider>

          </v-container>
        </v-col>
      </v-row>
    </v-sheet>
    <div style="height: 38vh;"></div>
    <v-sheet class="d-flex align-center flex-column" width="90vw" height="110vh" style="z-index: 1;">
      <v-parallax src="@/assets/landing-pink-gradient.png">
        <v-sheet class="d-flex align-center flex-column" style="
            position: relative;
            height: 70%;
            top: 15vh;
            width: 80%;
            margin-left: auto;
            margin-right: auto;
            border-radius: 10%;
          ">
          <v-sheet class="d-flex align-center flex-column" style="border-radius: 10%;">
            <div class="hello-message" style="border-radius: 10%;">
              <v-sheet style="float: left; display: block; width: 33%; height: 180px; border-radius: 10%;"></v-sheet>
              <h2 class="main-text"
                style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 22px; color: rgb(175, 126, 158);">
                Psy
              </h2>
              <p class="text">
                Psy są najczęściej spotykanymi zwierzętami w schroniskach. Są różnych ras, wielkości i wieku. W
                schroniskach może brakować miejsca, a psy mogą być umieszczone w małych klatkach lub boksach. Brak
                odpowiedniej ilości personelu może ograniczać czas spędzany na spacerach i interakcji z człowiekiem. <br>
              <h2 class="main-text"
                style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 22px; color: rgb(175, 126, 158);">
                Koty
              </h2>
              Koty również są często obecne w schroniskach. Mogą być dzikie, bezdomne lub opuszczone. Koty są bardziej
              niezależne niż psy, ale nadal wymagają odpowiedniej opieki. Brak wystarczających środków może prowadzić do
              przeludnienia i trudności w utrzymaniu czystości.<br>
              <h2 class="main-text"
                style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 22px; color: rgb(175, 126, 158);">
                Ptaki
              </h2>
              Schroniska mogą również przyjmować porzucone ptaki, takie jak papugi, kanarki czy gołębie. Ptaki potrzebują
              odpowiedniego miejsca do lotu, a także regularnego karmienia i opieki. Często są umieszczane w dużych
              klatkach, ale brak interakcji i swobody może być dla nich trudnym doświadczeniem.<br>
              <h2 class="main-text"
                style="text-shadow: 2px 2px 2px; font-weight: bold; font-size: 22px; color: rgb(175, 126, 158);">
                Gryzonie
              </h2>
              Często można spotkać króliki, chomiki, świnki morskie i inne gryzonie. Te zwierzęta potrzebują odpowiednich
              klatek, miejsca do aktywności i regularnej opieki weterynaryjnej. Brak odpowiedniej diety i brak środków
              może wpływać na ich zdrowie i dobre samopoczucie.<br>

              Zwierzęta gospodarskie: W niektórych schroniskach znajdują się również zwierzęta gospodarskie, takie jak
              kozy, świnie czy konie, które zostały uratowane z trudnych warunków hodowlanych. Te zwierzęta wymagają
              specjalistycznej opieki, odpowiedniego żywienia i warunków do życia.<br><br>

              Wszystkie zwierzęta w schroniskach często borykają się z ograniczeniem przestrzeni, brakiem odpowiedniej
              opieki weterynaryjnej, niedostatecznymi środkami finansowymi i brakiem stałych domów. Schroniska stawiają
              sobie za cel zapewnienie tym zwierzętom schronienia, opieki i możliwości adopcji przez odpowiedzialnych
              opiekunów. Jednakże, warunki życia w schroniskach mogą być trudne dla zwierząt i podkreślają potrzebę
              świadomości społecznej i wsparcia dla adopcji zwierząt ze schronisk oraz działań mających na celu
              zapobieganie porzucaniu i nadmiernemu rozmnażaniu się zwierząt. <br>

              <h3 class="main-text" style="color:rgb(175, 126, 158);">
                Nie czekaj dłużej - zarejestruj się już teraz i rozpocznij swoją
                przygodę z adopcją zwierzaka!
              </h3>
              </p>
            </div>
            <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text" @click="$router.push('/register')">Rejestracja</v-btn>
          </v-sheet>
        </v-sheet>
      </v-parallax>
    </v-sheet>

    <div style="height: 30vh;"></div>

  </div>
  <v-parallax src="@/assets/landing-gradient-background.png"
    style="position: absolute; height: 80vh; width: 100vw; bottom: 0; "></v-parallax>
</template>

<script lang="ts">
import LoginPopup from '@/components/LoginPopup.vue';
import RegisterPopup from '@/components/RegisterPopup.vue';

export default {
  name: "LandingView",
  components: {
    LoginPopup,
    RegisterPopup
  },

  setup() {


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

    return { reveal, }
  },
};
</script>

<script lang="js">


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
  text-align: center;
}

.text {
  text-align: justify;
  font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
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
