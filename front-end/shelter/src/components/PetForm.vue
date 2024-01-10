<template>
    <v-dialog transition="dialog-bottom-transition" overlay-color="black" overlay-opacity="1" v-model="dialog"
        max-width="80vw">
        <template v-slot:activator="{ props }">
            <v-btn elevation="8" class="text font-big" v-bind="props">
                <v-icon color="rgb(143, 83, 122)" icon="mdi-paw"> </v-icon> Dodaj
                podopiecznego</v-btn>
        </template>
        <div class="d-flex align-center flex-column" style="width: 100%; margin-left: auto; margin-right: auto">
            <div class="title" style="padding: 20px">Dodaj podopiecznego</div>
            <v-card class="scrollbar" width="100%" height="85vh" style="overflow-y: scroll; border-radius: 10px">
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>

                <div class="d-flex align-center flex-column">
                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                </div>
                <v-form class="px-4">
                    <v-card-text style="width: 70%; margin: 0 auto">
                        <p class="p">Imie</p>
                        <v-text-field v-model="name" label="Imie" type="name" :rules="[(v) => !!v || 'Wymagane']" />

                        <p class="p">Zdjęcia (max 5)</p>

           
                        <v-file-input type="file" @change="onFileChange" 
                            :rules="[(v) => v.length <= 5 || 'Maksymalnie 5 plików']" prepend-icon="mdi-camera"
                            accept=".jpg,.png" chips multiple show-size counter />
                        <div style=" display: flexbox;" v-if="show">
                            <v-row>
                                <v-col>
                                    <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png"
                                        :src="urls[0]" alt="..." />
                                </v-col>
                                <v-col>
                                    <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png"
                                        :src="urls[1]" alt="..." />
                                </v-col>
                                <v-col>
                                    <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png"
                                        :src="urls[2]" alt="..." />
                                </v-col>
                                <v-col>
                                    <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png"
                                        :src="urls[3]" alt="..." />
                                </v-col>
                                <v-col>
                                    <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png"
                                        :src="urls[4]" alt="..." />
                                </v-col>
                            </v-row>
                        </div>


                        


                        <p class="p">Typ zwierzęcia</p>
                        <v-select v-model="type" label="typ" :items="['Pies', 'Kot', 'Gryzoń']"></v-select>

                        <p class="p">Płeć</p>
                        <v-select v-model="gender" label="płeć" :items="['Żeńska', 'Męska']"></v-select>

                        <p class="p">Czy odbył(a) kastrację/sterylizację</p>
                        <v-select v-model="castration" label="płeć" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Rasa</p>
                        <v-text-field v-model="breed" label="Rasa" :rules="[(v) => !!v || 'Wymagane']" />

                        <p class="p">Wielkość</p>
                        <v-select v-model="size" label="Wielkość" :items="['Mała', 'Średnia', 'Duża']"></v-select>

                        <p class="p">Wielkość</p>
                        <v-select v-model="size" label="Wielkość" :items="['Mała', 'Średnia', 'Duża']"></v-select>

                        <p class="p">Przybliżony wiek</p>
                        <v-text-field v-model="age" label="m2" hide-details single-line type="number" />

                        <p class="p">Czy szczepiony(a)</p>
                        <v-select v-model="vaccination" label="szczepienia" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Czy przyjazny(a) dla dzieci</p>
                        <v-select v-model="childFriendly" label="lubi dzieci" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Znajomość podstawowych komend</p>
                        <v-select v-model="basicTraining" label="tresura" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Stopień aktywności</p>
                        <v-slider v-model="activity" :ticks="[1, 2, 3, 4, 5, 6, 7, 8, 9, 10]" :max="10" step="1"
                            show-ticks="always" tick-size="1"></v-slider>

                        <p class="p">Czy przyjazny(a) dla psów</p>
                        <v-select v-model="otherDogs" label="lubi psy" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Czy przyjazny(a) dla kotów</p>
                        <v-select v-model="otherCats" label="lubi koty" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Czy lubi przytulanie/uwagę</p>
                        <v-select v-model="cuddly" label="lubi przytulanie" :items="['Tak', 'Nie']"></v-select>

                        <p class="p">Temperament</p>
                        <v-text-field v-model="temper" label="Tempreament" type="name" />

                        <p class="p">Krótki opis</p>
                        <v-text-field v-model="text" label="Opis" type="name" />
                    </v-card-text>
                    <v-card-actions class="d-flex align-center flex-column">
                        <v-divider :thickness="20" class="border-opacity-0"></v-divider>

                        <div style="display: flex">
                            <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                                @click="dialog = false">Zrezygnuj</v-btn>
                            <v-divider vertical :thickness="300" class="border-opacity-0"></v-divider>
                            <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                                @click="Submit()">Zapisz</v-btn>
                        </div>
                        <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                    </v-card-actions>
                </v-form>
            </v-card>
        </div>
    </v-dialog>
</template>

<script setup lang="js">
import { ref } from 'vue'
import { usePetStore } from '@/store/pet';
import { useNotificationsStore } from '@/store/notifications';
import { useShelterStore } from '@/store/shelter';
import { file } from '@babel/types';
const shelterStore = useShelterStore();
const notifStore = useNotificationsStore();
const isValid = ref(true)
const petStore = usePetStore();
var show = ref(false)
var urls = []
var files = []
var images = []

var name = ref()
var type = ref()
var gender = ref()
var castration = ref()
var breed = ref()
var size = ref()
var age = ref()
var vaccination = ref()
var childFriendly = ref()
var basicTraining = ref()
var activity = ref()
var otherDogs = ref()
var otherCats = ref()
var cuddly = ref()
var temper = ref()
var text = ref()
var shelterEmail = ref(shelterStore.shelterData.email)


var dialog = ref(false)

const onFileChange =  (e)  => {
    show.value = false
    urls = []
    files = [];
    files = e.target.files;
    forBase64(files);

    for (var i = 0; i < e.target.files.length; i++) {
        
        urls[i] = URL.createObjectURL(e.target.files[i])
      

    }

    show.value = true
};

async function getBase64(file, i) {

        const reader = new FileReader();
    reader.onload = (event) => {
        images[i] = event.target.result;
      }
      reader.readAsDataURL(file);

    }
 
    var test = null

async function forBase64(files){

    for(var i = 0; i < files.length; i++){
      await getBase64(files[i], i)



    }
}





async function Submit() {

    var petForm = {
        shelterEmail: shelterEmail.value,
        name: name.value,
        images: images,
        type: type.value,
        gender: gender.value,
        castration: castration.value,
        breed: breed.value,
        size: size.value,
        age: age.value,
        vaccination: vaccination.value,
        childFriendly: childFriendly.value,
        basicTraining: basicTraining.value,
        activity: activity.value,
        otherDogs: otherDogs.value,
        otherCats: otherCats.value,
        cuddly: cuddly.value,
        temper: temper.value,
        text: text.value,
    }

    const res = await petStore.postPetForm(petForm)

    if (res.status == 200) {
        const notification = {
            type: "success",
            message: "Added  succesfully",
        }
        notifStore.add(notification)
    }
}


</script>

<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');

.title {
    font-family: 'Gruppo', sans-serif;
    font-size: xxx-large;
    font-weight: bolder;
    font-stretch: wider;
    color: white;
    text-shadow: 5px 2px 4px #000000;
}

.p {
    font-family: 'Gruppo', sans-serif;
    font-size: medium;
    font-weight: 900;
    color: rgb(95, 20, 83);
    text-align: center;
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
