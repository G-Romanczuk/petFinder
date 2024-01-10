<template>
    <v-dialog v-model="dialog" width="98vw" height="98vh">
        <template v-slot:activator="{ props }">

            <v-btn elevation="0" class="text font-big" v-bind="props">
                <slot name="activator"> </slot>
            </v-btn>
        </template>

        <v-col>
       

<v-row>
            <v-card class="scrollbar" width="55%" height="98vh" style="overflow-y: scroll; border-radius: 10px; margin: auto;">
                <div style=" width: fit-content; margin: 0 auto; ">
                   
                    <v-btn style="float: right;" @click="dialog = false"><v-icon icon="mdi-window-close"></v-icon></v-btn>
                    <h1 class="title" style="text-align: center; color:  rgb(143, 83, 122); text-shadow:none;">
                        {{ props.user.name }}  {{ props.user.lname }}, <div style="font-size: medium; display: inline"
                            > {{props.user.email }}</div>
                    </h1>

                  
                          


                            <v-row
                                style="width: fit-content; margin: 1vh auto 0 auto; border-bottom:2px solid darkgray ; font-size: small; ">

                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.vaccination == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Szczepiony/a: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.castration == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;">
                                        Kastracja/Sterylizacja: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.childFriendly == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje dzieci:
                                    </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.basicTraining == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Tresowany: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.otherDogs == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje psy:
                                    </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.otherCats == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Akceptuje koty:
                                    </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                                <v-row style=" width: fit-content; margin: 0.5vh" v-if="(props.user.cuddly == 'Tak')">
                                    <div style="width: fit-content; border-radius: 7px; margin: 2px;"> Czuły: </div>
                                    <div style="width: 10%;"> <v-icon color="rgb(175, 126, 158)"
                                            icon="mdi-check-circle"></v-icon></div>
                                </v-row>
                            </v-row>




                            <p class="shelterText text-center" style="height: ; border-radius: 10px;"> Krótki opis: <br>
                                    {{ props.user.text }}</p>
                                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>



                           
                            <v-col class="text-center" style="height: fit-content; margin: auto;">
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.user.shelterModel.adress != '') || (props.user.shelterModel.town != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Adres:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.shelterModel.adress }}, {{
                                        props.user.shelterModel.town }}
                                    </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.user.shelterModel.email != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> E-Mail:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.shelterModel.email }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.user.shelterModel.phone != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Telefon:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.shelterModel.phone }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;"
                                    v-if="(props.user.shelterModel.url != '')">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Strona
                                        internetowa:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.shelterModel.url }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Rasa:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.breed }}</div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Płeć:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.gender }} </div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Wielkość:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.size }}</div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;">
                                        Przybliżony
                                        wiek:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.age }}</div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Poziom
                                        aktywności
                                        (1-10): </div>
                                    <div style="width: 60%;"> {{ props.user.activity }}</div>
                                </v-row>
                                <v-row style="border-bottom:2px solid darkgray ; width: 100%; margin: auto;">
                                    <div style="width: 40%; background-color: darkgrey; border-radius: 2px;"> Opis
                                        temperamentu:
                                    </div>
                                    <div style="width: 60%;"> {{ props.user.temper }}</div>
                                </v-row>
                            </v-col>

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
const props = defineProps({
    user: Object
})

const shelterStore = useShelterStore();
const animalsStore = useAnimalsStore();
const userStore = useUserStore();
var dialog = ref(false)



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