<template>
    <v-app-bar :elevation="2" app  dark scroll-behavior="hide" >
        <div class="d-flex align-center">
            <a href="http://127.0.0.1:3000/">
        <img src="/homeIcon.png" style="height: 120px;" alt="logo" class="shrink mr-2" transition="scale-transition" height="150">   
        </a>  
            
        </div>
        <v-app-bar-title style="position: relative; left: -1%; font-size: 40px;">
            <a href="http://127.0.0.1:3000/" class="link"> ShelterFinder</a>
              
        </v-app-bar-title>
       
  <template v-slot:append>
    <h5>{{ store.loggedUser + store.loggedShelter }}</h5>
        <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
    <LoginPopup v-if="loggedUser == '' && loggedShelter == ''" />
    <v-btn target="_blank" elevation="8" class="d-flex align-center flex-column main-text main-text" v-else @click=" $router.push('/'), logout()"> Wyloguj się</v-btn>
  </template>
</v-app-bar>
  </template>
  
  <script setup lang="ts">
 import { useUserStore } from '@/store/user';
 import LoginPopup from './LoginPopup.vue';
import { ref, watch } from 'vue';
import { storeToRefs } from 'pinia'

  const store = useUserStore();

const {loggedUser} = storeToRefs(store)
const {loggedShelter} = storeToRefs(store)

  function logout() {
    store.$reset()
  }
  


  </script>

  <style lang="css" scoped>
.link{
    text-decoration: none;
    font-weight: bolder;
    font-family:'Courier New', Courier, monospace;
}


</style>
  