<template>
    <v-dialog v-model="dialog" width="98vw" height="98vh">
        <template v-slot:activator="{ props }">

            <v-btn elevation="0" class="text font-big" v-bind="props">
                <slot name="activator"> </slot>
            </v-btn>
        </template>

        <v-col>
            <v-row>



                <v-card class="scrollbar" width="100%" height="98vh"
                    style="overflow-y: scroll; border-radius: 10px; margin: auto; ">
                    <div style=" width: 95%; margin: 0 auto; ">

                        <v-btn style="float: right;" @click="dialog = false"><v-icon
                                icon="mdi-window-close"></v-icon></v-btn>

                               <div >
                        <h1 class="title" style="text-align: center; color:  rgb(143, 83, 122); text-shadow:none;">
                            {{ props.pet.name }}, <div style="font-size: medium; display: inline"
                                v-if="(props.pet.shelterModel.name != '')"> {{
                                    props.pet.shelterModel.name }}</div>
                        </h1>
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

                        <p class="shelterText text-center" style="height: ; border-radius: 10px;"> Polubiony przez: <br></p>
                        <div style="width: 99%; margin: auto;  height: 2px; background-color: rgb(175, 126, 158);"></div>

</div>



                        <div style="height: fit-content;">
                            <div style="width:100%; display: grid;  grid-template-columns:repeat(3, 33.3% [col-start]);  overflow-x: hidden; margin: auto; min-height: 600px; "
                                >
                                <div v-for="(user, i) in props.pet.likedBy"
                                    style="width: 100%; height: 420px; padding: 10px;  ">
                                    
                                    <UserFormPDF :user="user" :pet="props.pet" >
                            <template #activator>

                                            <div style="height: 10px;"></div>
                                            <v-card class="mx-auto dontscale scrollbar" width="95%" style="overflow-y: scroll;  border: 1px solid rgb(143, 83, 122);"  >


                                                <v-card-title class="font">

                                                    {{ user.name }} {{ user.lname }}
                                                </v-card-title>

                                                <v-card-subtitle class="font">
                                                    E-mail: {{ user.email }} <br>
                                                    Telefon: {{ user.phone }} <br>
                                               
                                                    Kod pocztowy: {{ user.postCode }} <br />

                                                    Miasto: {{ user.town }} <br />

                                                    Ulica z numerem: {{ user.adress }} <br /> <br>

                                                  
                                                </v-card-subtitle>
                                            
                                            </v-card>

                                     
</template>
</UserFormPDF>
                                </div>
                            </div>
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
import UserFormPDF from './UserFormPDF.vue';
const props = defineProps({
    pet: Object
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
}
</style>