<template>
    <v-dialog v-model="dialog" width="98vw" height="100vh">
        <template v-slot:activator="{ props }">

            <v-btn elevation="0" class="text font-big" v-bind="props">
                <v-icon color="rgb(143, 83, 122)" icon="mdi-paw" > </v-icon> Znajdź przyjaciela
            </v-btn>
        </template>

        <div style="width: 100%; height: 100%; background-color: aqua;">

    
  <img slot="like" src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" />
  <img slot="nope" src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" />
  <img slot="super" src="@/assets/loading-flip.gif" />
            
            
            
       



        </div>


    </v-dialog>
</template>

<script setup lang="js">
import { ref } from 'vue'
import { useUserStore } from '@/store/user';
import { useAnimalsStore} from '@/store/animals';
import TinderPetsComponent from './TinderPetsComponent.vue';
const userStore = useUserStore();
const animalsStore = useAnimalsStore()
animalsStore.getPets();
var dialog = ref(false)





</script>

<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');

.vue-tinder {
  width: 335px;
  height: 447px;
}


.shelterText {
    font-family: 'Gruppo', sans-serif;
    font-size: large;
    font-weight: 900;
    display: block;
    padding: 5px;
}


.center-text {
    text-align: center;
}


.scale :hover {
    transform: scale(1.1);
}

.dontscale :hover {
    transform: scale(1);
}

.title {
    font-family: 'Gruppo', sans-serif;
    font-size: xxx-large;
    font-weight: bolder;
    font-stretch: wider;
    color: white;
}

.little-title {
    font-family: 'Gruppo', sans-serif;
    font-weight: bold;
    font-size: medium;
    color: rgb(175, 126, 158);
    text-shadow: 1px 2px 2px #000000
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