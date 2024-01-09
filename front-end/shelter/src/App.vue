<template>
  <v-row>
    <v-col>
  <div v-show="loading" close-delay="1000"  style="width: fit-content;  margin-right: auto;  " class="slide-left" >
   <v-img  src="@/assets/loading.gif" style="height: 100vh;" ></v-img>
  </div>
</v-col >
<v-col v-show="loading" close-delay="1000" class="fade-out" style="position:relative; z-index: 1;">
  <v-img  src="@/assets/home.png" style="height: 70vh;" ></v-img>
</v-col>
<v-col>
  <div v-show="loading" close-delay="1000"  style="width: fit-content; margin-left: auto; " class="slide-right"  >
   <v-img  src="@/assets/loading-flip.gif" style="height: 100vh;" ></v-img>
  </div>
</v-col>
</v-row>
  <v-app v-show="!loading" class="reveal fade-back">
    <NotificationsPopup></NotificationsPopup>
    <AppHeader app ></AppHeader>
    <v-main >
      <router-view ></router-view>
   
    </v-main>
    <!-- <AppFooter app style="opacity: 0.8;"></AppFooter> -->
    
  </v-app>
</template>

<script setup lang="ts">
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";
import NotificationsPopup from "@/components/NotificationsPopup.vue"
import { defineComponent, onMounted, ref } from "vue";
import router from "./router";
const loading = ref(true)

const onLoad = () => {
  
  setTimeout(() => {
    loading.value = false
  }, 4500)
}


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

  window.addEventListener("load", onLoad);
    window.addEventListener("load", reveal);


</script>

<style>

.reveal {
  position: relative;
  opacity: 0;
}

.reveal.active {
  opacity: 1;
}

.slide-left {
  animation: slide-left 3s ease 1s 1 normal forwards;
}

.slide-right {
  animation: slide-right 3s ease 1s 1 normal forwards;
}

@keyframes slide-left {
	0% {
		opacity: 1;
		transform: translateX(0);
	}

	100% {
		opacity: 0;
		transform: translateX(300px);
	}
}


@keyframes slide-right {
	0% {
		opacity: 1;
		transform: translateX(0);
	}

	100% {
		opacity: 0;
		transform: translateX(-300px);
	}
}

@keyframes fade-left {
  0% {
    transform: translateX(0);
    opacity: 1;
  }

  100% {
    transform: translateX(2000px);
    opacity: 1;
  }
}


.fade-in-out {
  opacity: 0;
  animation: fade-out 3s  ease-out forwards;
}

.fade-out {
  animation: fade-out 2s  ease-out 2.5s 1 normal forwards;
}


@keyframes fade-out {
  0% {
    
    opacity: 1;
  }
  100% {
    opacity: 0;
  }
}
</style>
