<template>
    <v-dialog v-model="dialog" width="98vw" height="98vh">
        <template v-slot:activator="{ props }">
            
                <v-btn elevation="8" class="text font-big" v-bind="props" >
                      <v-icon color="rgb(143, 83, 122)" icon="mdi-paw" > </v-icon> Znajdź przyjaciela</v-btn>
        </template>
        <div class="d-flex align-center flex-column" style="width: 100%; margin: auto; height: 100%;">


            <v-card class="scrollbar" width="100%" height="98vh" style="overflow-y: scroll; border-radius: 10px;">
                <v-btn style="float: right;" @click="dialog = false">Close</v-btn>
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                <v-row style="height: 93%; width: 98%; margin: auto;  ">
                    <v-col style="height: 100%; ">
                        <h1 class="title" style="text-align: center; color:  rgb(143, 83, 122); text-shadow:none;">{{store.petData.name}}</h1>
                       

<v-btn @click="Show()">zobacz</v-btn>
<p class="pet-text"> Miasto: {{ store.city }}</p>
                        <p class="pet-text"> Schronisko: {{ store.shelterName }}</p>
                    </v-col>
                    <v-divider vertical :thickness="20" class="border-opacity-0"></v-divider>
                    <v-col class="scrollbar" style="max-height: 100%; overflow-y: auto; ">
                        
<p class="pet-text" style="height: ;"> Krótki opis: {{ store.petData.text }}</p>
                        <p class="pet-text"> Płeć: {{ store.petData.gender }}</p>
                        <p class="pet-text"> Kastracja/Sterylizacja: {{ store.petData.castration }}</p>
                        <p class="pet-text"> Rasa: {{ store.petData.breed }}</p>
                        <p class="pet-text"> Wielkość: {{ store.petData.size }}</p>
                        <p class="pet-text"> Przybliżony wiek: {{ store.petData.age }}</p>
                        <p class="pet-text"> Szczepiony/a: {{ store.petData.vaccination }}</p>
                        <p class="pet-text"> Przyjazność dziecion: {{ store.petData.childFriendly }}</p>
                        <p class="pet-text"> Zna podstawowe komendy: {{ store.petData.basicTraining }}</p>
                        <p class="pet-text"> Poziom aktywności (1-10): {{ store.petData.activity }}</p>
                        <p class="pet-text"> Akceptuje inne psy: {{ store.petData.otherDogs }}</p>
                        <p class="pet-text"> Akceptuje inne koty: {{ store.petData.otherCats }}</p>
                        <p class="pet-text"> Lubi czułości: {{ store.petData.cuddly }}</p>
                        <p class="pet-text"> Opis temperamentu: {{ store.petData.temper }}</p>
                       




                    </v-col>

                </v-row>
                
               <v-divider :thickness="20" class="border-opacity-0"></v-divider>
            </v-card>


        </div>
    </v-dialog>
</template>

<script setup lang="js">
import { ref } from 'vue'
import LoginPopup from '@/components/LoginPopup.vue';
import { useForm } from 'vee-validate';
import * as yup from 'yup';
import { usePetStore } from '@/store/pet';


const store = usePetStore();




var dialog = ref(false)

function Show() {
    console.log(store.petData.images)
}

</script>

<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');

.pet-text{
    font-family: 'Gruppo', sans-serif;
    font-size: large;
    display: block;
    padding: 5px;
    border: 1px solid rgb(143, 83, 122) ;
    text-align: center;
    margin-top: 1vh;
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
</style>