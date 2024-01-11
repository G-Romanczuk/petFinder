<template>
    <v-dialog v-model="dialog" width="98vw" height="98vh">
        <template v-slot:activator="{ props }">

            <v-btn elevation="0" class="text font-big" v-bind="props" >
                <slot name="activator" > </slot>
            </v-btn>
        </template>

        <v-col>


            <v-row>
                <v-card class="scrollbar" width="1240px" height="98vh"
                    style="overflow-y: scroll; border-radius: 10px; margin: auto;">
                    <div style=" width: 1240px;  margin: 0 auto; ">
                        
                        <v-btn style="float: right;" @click="dialog = false"><v-icon
                                icon="mdi-window-close"></v-icon></v-btn>
                                <v-btn style="float: right;" @click="exportToPdf()"><v-icon icon="mdi-download"></v-icon></v-btn>

                        <div id="element-to-convert" style="width: 800px; min-height: 875px; margin: auto;  ">

                            <div style="width: 150px; float: left;">
                                <v-img cover src="@/assets/home.png"></v-img>
                                <div style="font-size: 24px; margin-top: -25px;">ShelterFinder</div>
                            </div>
                            <v-card-title class="form-title font center-text" style="margin: auto; width: fit-content; ">
                                Ankieta przedadopcyjna schroniska: <br>{{ shelterStore.shelterData.name }} w {{
                                    shelterStore.shelterData.town }}

                                <div style="font-size: large;">

                                     <br> dotycząca: {{ props.pet.name }}, {{ props.pet.age }} <br> o numerze id: {{
                                        props.pet.id }} <br>

                                </div>
                            </v-card-title>

                            <v-card-subtitle class="font">


                                <div class="main-data">


                                    <v-col class="text-center" style="height: fit-content; margin: auto;">

                                        <div style="width: 100%; background-color: darkgrey; border-radius: 2px; text-wrap: pretty;">Dane
                                            osobowe:
                                        </div>
                                        <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                            <div
                                                class= "question-small">
                                                Imie i
                                                Nazwisko:
                                            </div>
                                            <div style="width: 60%; height: fit-content; margin: auto;"> {{ props.user.name
                                            }} {{ props.user.lname }} </div>
                                        </v-row>

                                        <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                            <div
                                                class= "question-small">
                                                E-Mail:
                                            </div>
                                            <div style="width: 60%; height: fit-content; margin: auto;"> {{ props.user.email
                                            }} </div>
                                        </v-row>
                                        <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                            <div
                                                class= "question-small">
                                                Adres:
                                            </div>
                                            <div style="width: 60%; height: fit-content; margin: auto;"> {{
                                                props.user.adress }} </div>
                                        </v-row>
                                        <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                            <div
                                                class= "question-small">
                                                Miasto:
                                            </div>
                                            <div style="width: 60%; height: fit-content; margin: auto;"> {{
                                                props.user.postCode }} {{ props.user.town }} </div>
                                        </v-row>
                                        <v-row style="border-bottom:5px solid darkgray ; width: 100%; margin: auto;">
                                            <div
                                                class= "question-small">
                                                Telefon kontaktowy:
                                            </div>
                                            <div style="width: 60%; height: fit-content; margin: auto;"> {{ props.user.phone
                                            }} </div>
                                        </v-row>

                                    </v-col>


                                </div>



                                <div style=" width: 90%;  margin: auto; font-size: small; ">

                                  



                                    <v-row v-if="shelterStore.shelterData.incomeSource"
                                        style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            1. Jakie jest Pana(i) główne źródło utrzymania? :
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.incomeSource }} </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.lifestyle" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            2. Jaki tryb życia Pan(i) prowadzi?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.lifestyle }} </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.housingType" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            3. Gdzie Pan(i) mieszka?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.housingType }} </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.houseOwner" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            4. Kto jest właścicielem mieszkania lub domu?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.houseOwner }} </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.hoursAlone" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            style="width: 40%; text-wrap:pretty ; background-color: darkgrey; border-radius: 2px; ">
                                            5. Ile maksymalnie godzin w ciągu doby pies będzie zostawał sam w
                                            domu?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.hoursAlone }} </div>
                                    </v-row>


                                    <v-row v-if="shelterStore.shelterData.careAlone" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            6. Czy podczas dłuższej nieobecności (wakacje, sanatorium, pobyt w
                                    szpitalu) będzie Pan(i) w stanie zapewnić zastępczą właściwą
                                    opiekę nad zwierzęciem ?
                                        </div>
                                        <div class= "answer"> {{ props.user.careAlone }} </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.houseMates" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            7. Kto mieszka razem z Panem(ią)?
                                        </div>
                                        <div class= "answer"> {{ props.user.houseMates }} </div>
                                    </v-row>

                                    <v-row v-if="shelterStore.shelterData.animals" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            8. Czy w miejscu zamieszkania psa są obecnie inne zwierzęta?
                                        </div>
                                        <div class= "answer"> {{ props.user.animals }} </div>
                                    </v-row>

                                    <v-row v-if="shelterStore.shelterData.animalsBefore" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            9. Jeśli kiedykolwiek w przeszłości posiadał(a) Pan(i) psa (psy)?
                                        </div>
                                        <div class= "answer"> {{ props.user.animalsBefore }} </div>
                                    </v-row>








                                    <div style="height: 10px;"></div>
                                    <v-row  style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div style="width: 100%; background-color: darkgrey; border-radius: 2px; text-wrap: pretty;"> 10. Jeśli
                                            mieszka Pan(i) w bloku/ kamienicy lub w mieszkaniu z
                                            dostępem do ogródka (parter) proszę odpowiedzieć na następujące
                                            pytania:
                                        </div>

                                    </v-row>




                                    <v-row v-if="shelterStore.shelterData.floor" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Na którym piętrze Pan(i) mieszka?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.floor }} </div>
                                    </v-row>

                                    <v-row v-if="shelterStore.shelterData.elevator" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Czy w budynku jest winda?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.elevator }} </div>
                                    </v-row>

                                    <v-row v-if="shelterStore.shelterData.walksNumber" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Jak często pies będzie wychodził na spacer? (na dzień)
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.walksNumber }} </div>
                                    </v-row>

                                    <v-row v-if="shelterStore.shelterData.walksTime" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Ile czasu będzie trwał najdłuższy spacer z psem?
                                        </div>
                                        <div class= "answer"> {{
                                            props.user.walksTime }} min </div>
                                    </v-row>

                                 
                                    <div style="height: 10px;"></div>
                                    <v-row  style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div style="width: 100%; background-color: darkgrey; border-radius: 2px; text-wrap: pretty;"> 
                                            11. Jeśli mieszka Pan(i) w domu z ogrodem/podwórkiem proszę
                                    odpowiedzieć na następujące pytania:
                                        </div>

                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.fence" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Czy dom jest ogrodzony?
                                        </div>
                                        <div class= "answer"> {{ props.user.fence }}  </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.fenceHeight" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Jeśli dom jest ogrodzony to jaką wysokość ma ogrodzenie?
                                        </div>
                                        <div class= "answer"> {{ props.user.fenceHeight }} cm </div>
                                    </v-row>
                                    <v-row v-if="shelterStore.shelterData.propertySize" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Jaka jest powierzchnia podwórka/ogrodu?
                                        </div>
                                        <div class= "answer"> {{ props.user.propertySize }} (m<sup>2</sup>) </div>
                                    </v-row>

                                  


                                    <v-row v-if="shelterStore.shelterData.petPlace" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Gdzie pies będzie przebywał w ciągu całej doby?
                                        </div>
                                        <div class= "answer"> {{ props.user.petPlace }} </div>
                                    </v-row>

                                    <v-row v-if="shelterStore.shelterData.petPlaceAlone" style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                        <div
                                            class= "question-small">
                                            Gdzie będzie przebywał pies w czasie Pana(i) nieobecności oraz
                                    innych domowników jeśli nie mieszka Pan(i) sam(a)?
                                        </div>
                                        <div class= "answer"> {{ props.user.petPlaceAlone }} </div>
                                    </v-row>
                                    <div style="height: 10px;"></div>

                                  <br>
                                    <div id="page2el"
                                        style="width: 100%; text-align: center; border-bottom: 2px solid darkgray ; border-radius: 2px;">
                                        Kilka słow o mnie:
                                    </div>
                                    <div style="width: 100%;   min-height: 100px;"> <br> {{ props.user.text
                                    }}<br> <br></div>

                                    <br> <br>

                                </div>
                            </v-card-subtitle>



                        </div>








                    </div>
                </v-card>




            </v-row>
        </v-col>
    </v-dialog>
</template>

<script setup lang="js">
import { ref } from 'vue'
import BigImagePopup from './BigImagePopup.vue';
import { useShelterStore } from '@/store/shelter';
import { useAnimalsStore } from '@/store/animals';
import { useUserStore } from '@/store/user';
import DeletePetPopup from './DeletePetPopup.vue';
import UpdatePetForm from './UpdatePetForm.vue';

import html2pdf from 'html2pdf.js'
const props = defineProps({
    user: Object,
    pet: Object
})

const shelterStore = useShelterStore();
const animalsStore = useAnimalsStore();
const userStore = useUserStore();
var dialog = ref(false)



function exportToPdf(){



html2pdf(document.getElementById('element-to-convert'), {
    margin:       [0.1, 1],
  filename:     'test.pdf',
}).set({
  pagebreak: { mode: 'avoid-all', before: '#page2el' }
});



}

</script>

<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');

.answer{
    width: 60%; height: fit-content; margin: auto; text-align: center;
}

.question-small{
    width: 40%; text-wrap:pretty ; background-color: darkgrey; border-radius: 2px;
}

.row-q{}

.center-text {
    text-align: center;
}

.main-data {
    font-size: small;
    font-weight: 900;
    line-height: 150%;
    color: #000000;
}

.scale :hover {
    transform: scale(1.1);
}

.dontscale :hover {
    transform: scale(1);
}


.form-title {
    font-size: x-large;

}




.title-form {
    font-family: 'Gruppo', sans-serif;
    font-size: x-large;
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
}</style>