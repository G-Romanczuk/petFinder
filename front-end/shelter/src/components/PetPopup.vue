<template>
    <v-dialog v-model="dialog" width="98vw" height="98vh">
        <template v-slot:activator="{ props }">

            <v-btn elevation="0" class="text font-big" v-bind="props">
                <slot name="activator"> </slot>
            </v-btn>
        </template>


        <div class="d-flex align-center flex-column" style="width: 100%; margin: auto; height: 100%; display: flex; ">

            <v-card class="scrollbar" width="55%" height="98vh" style="overflow-y: scroll; border-radius: 10px;">

                <v-btn style="float: right;" @click="dialog = false"><v-icon icon="mdi-window-close"></v-icon></v-btn>

                <div style=" width: fit-content; margin: 0 auto; ">

                    <h1 class="title" style="text-align: center; color:  rgb(143, 83, 122); text-shadow:none;">
                        {{ props.pet.name }}, <div style="font-size: medium; display: inline"
                            v-if="(props.pet.shelterModel.name != '')"> {{
                                props.pet.shelterModel.name }}</div>
                    </h1>

                  


                            <v-carousel
                                style="border-radius: 10px; width: 95%; margin: auto;  border: 1px solid rgb(143, 83, 122);">
                                <v-carousel-item v-for="(img, i) in props.pet.images" cover>

                                    <v-img v-bind:src="props.pet.images[i]" cover>
                                        <BigImagePopup :img="props.pet.images[i]" />
                                    </v-img>

                                </v-carousel-item>
                            </v-carousel>

                            <v-row
                                style="width: fit-content; margin: 1vh auto 0 auto; border-bottom:2px solid darkgray ; font-size: small; ">

                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.vaccination == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Szczepiony/a: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.castration == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;">
                                        Kastracja/Sterylizacja: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.childFriendly == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje dzieci:
                                    </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.basicTraining == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Tresowany: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.otherDogs == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje psy:
                                    </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.otherCats == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje koty:
                                    </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.pet.cuddly == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Czuły: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                            </v-row>

                            <p class="shelterText text-center" style="height: ; border-radius: 10px;"> Krótki opis: <br>
                                    {{ props.pet.text }}</p>

                            <v-divider :thickness="20" class="border-opacity-0"></v-divider>

                            <v-col class="text-center" style="height: fit-content; margin: auto;">
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.pet.shelterModel.adress != '') || (props.pet.shelterModel.town != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Adres:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.shelterModel.adress }}, {{
                                        props.pet.shelterModel.town }}
                                    </div>

                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.pet.shelterModel.email != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> E-Mail:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.shelterModel.email }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.pet.shelterModel.phone != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Telefon:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.shelterModel.phone }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.pet.shelterModel.url != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Strona
                                        internetowa:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.shelterModel.url }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Rasa:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.breed }}</div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Płeć:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.gender }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Wielkość:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.size }}</div>
                                </v-row>







                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;">
                                        Przybliżony
                                        wiek:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.age }}</div>
                                </v-row>


                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Poziom
                                        aktywności
                                        (1-10): </div>
                                    <div style="width: 60%;"> {{ props.pet.activity }}</div>
                                </v-row>


                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Opis
                                        temperamentu:
                                    </div>
                                    <div style="width: 60%;"> {{ props.pet.temper }}</div>
                                </v-row>

                               

                            </v-col>



                      




                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                </div>
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
import BigImagePopup from './BigImagePopup.vue';
const props = defineProps({
    pet: Object
})

const store = usePetStore();


var dialog = ref(false)

console.log(props.pet.shelterModel.adress)


</script>

<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');


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
}</style>