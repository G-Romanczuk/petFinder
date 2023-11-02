<template>
    <v-dialog transition="dialog-bottom-transition" overlay-color="black" overlay-opacity="1" v-model="dialog"
        max-width="80vw">
        <template v-slot:activator="{ props }">
            <v-btn elevation="8" class="text" v-bind="props">
                <v-icon color="rgb(143, 83, 122)" icon="mdi-paw"> </v-icon> Dodaj
                podopiecznego</v-btn>
        </template>
        <div class="d-flex align-center flex-column" style="width: 100%; margin-left: auto; margin-right: auto">
            <div class="title" style="padding: 20px">Dodaj podopiecznego</div>
            <v-card class="scrollbar" width="100%" height="85vh" style="overflow-y: scroll; border-radius: 5%">
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>

                <div class="d-flex align-center flex-column">
                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                </div>
                <v-form class="px-4">
                    <v-card-text style="width: 70%; margin: 0 auto">
                        <p class="p">Imie</p>
                        <v-text-field v-model="name" label="Imie" type="name" :rules="[(v) => !!v || 'Wymagane']" />

                        <p class="p">Zdjęcia (max 5)</p>

                        <v-file-input type="file" name ="images" @change="onFileChange" :rules="[(v) => v.length <= 5 || 'Maksymalnie 5 plików']"  prepend-icon="mdi-camera" accept=".jpg,.png" chips
                            multiple show-size counter />
                        <div style=" display: flexbox;" v-if="show">
                            <v-row>
                                <v-col>
      <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" :src="urls[0]"   alt="..."/>
    </v-col>
    <v-col>
    <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" :src="urls[1]"   alt="..."/>
</v-col>
<v-col>
     <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" :src="urls[2]"   alt="..."/>
    </v-col>
    <v-col>
      <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" :src="urls[3]"   alt="..."/>
    </v-col>
    <v-col>
      <v-img lazy-src="https://geekflare.com/wp-content/uploads/2023/03/img-placeholder.png" :src="urls[4]"   alt="..."/>
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
                                @click="Submit(petData)">Zapisz</v-btn>
                        </div>
                        <v-btn @click="petFormTest()"> TEST petform</v-btn>
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
import { useUserStore } from '@/store/user';


const isValid = ref(true)
const store = usePetStore();
const userStore = useUserStore();
var show = ref(false)
var urls = []

var name = ref(store.petData.name)
var images = store.petData.images
var type = ref(store.petData.type)
var gender = ref(store.petData.gender)
var castration = ref(store.petData.castration)
var breed = ref(store.petData.breed)
var size = ref(store.petData.size)
var age = ref(store.petData.age)
var vaccination = ref(store.petData.vaccination)
var childFriendly = ref(store.petData.childFriendly)
var basicTraining = ref(store.petData.basicTraining)
var activity = ref(store.petData.activity)
var otherDogs = ref(store.petData.otherDogs)
var otherCats = ref(store.petData.otherCats)
var cuddly = ref(store.petData.cuddly)
var temper = ref(store.petData.temper)
var text = ref(store.petData.text)
var shelterEmail = ref(userStore.loggedShelter)
var petData = {
    shelter: shelterEmail,
    name: name,
    images: images,
    type: type,
    gender: gender,
    castration: castration,
    breed: breed,
    size: size,
    age: age,
    vaccination: vaccination,
    childFriendly: childFriendly,
    basicTraining: basicTraining,
    activity: activity,
    otherDogs: otherDogs,
    otherCats: otherCats,
    cuddly: cuddly,
    temper: temper,
    text: text,
}

var dialog = ref(false)



function Submit(petData) {
    store.petData = petData;
   
}
    
const onFileChange = (e) => {
    show.value = false
    urls = []
    images = []
    console.log(images.length)
    for(var i = 0; i < e.target.files.length; i++){
        images[i] = e.target.files[i]
        urls[i] = URL.createObjectURL(images[i])
    }
    show.value = true
    console.log(images)
    };



//for tests
async function petFormTest() {
   const formData = new FormData();
// //   formData.append("shelter", shelterEmail.value);

//   formData.append("images", images[0]);
//   formData.append("images", images[1]);
//   formData.append("images", images[2]);
//   formData.append("images", images[3]);
//   formData.append("images", images[4]);

for(let i=0 ; i<images.length;i++)
{
    formData.append("images", images[i])
}

  var petForm = {
        shelter: shelterEmail.value,
        images:images,
        name: name.value,
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

    console.log(petForm)
    
    console.log()
    store.postPetForm(petForm)
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
    color: rgb(175, 126, 158);
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
}
</style>
