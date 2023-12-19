<template>
  <v-dialog transition="dialog-bottom-transition"  overlay-color="black" overlay-opacity="1" v-model="dialog" max-width="80vw">
    <template v-slot:activator="{ props }">
      <v-btn
        elevation="8"
        class="d-flex align-center flex-column text font-big"
        v-bind="props"
        > <v-icon color="rgb(143, 83, 122)"  icon="mdi-account-edit"> </v-icon>Dane użytkownika</v-btn
      >
    </template>
    <div
      class="d-flex align-center flex-column"
      style="width: 100%; margin-left: auto; margin-right: auto"
    >
      <div class="title" style="padding: 20px">Dane użytkownika</div>
      <v-card
        class="scrollbar"
        width="100%"
        height="85vh"
        style="overflow-y: scroll; border-radius: 5%"
      >
        <v-divider :thickness="20" class="border-opacity-0"></v-divider>

        <div class="d-flex align-center flex-column">
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
        </div>
        <v-form
          class="px-4"
        >
          <v-card-text style="width: 70%; margin: 0 auto">
            <p class="p">Imie</p>
            <v-text-field required v-model="name" label="Imie" type="name" :rules="[v => !!v || 'Wymagane']" />

            <p class="p">Nazwisko</p>
            <v-text-field required v-model="lname"  label="Nazwisko" type="lname" :rules="[v => !!v || 'Wymagane']"/>

            <p class="p">E-Mail</p>
            <v-text-field
              required v-model="email"
              label="E-mail"
              type="email"
              disabled
              :rules="emailRules"
            />

            <p class="p">Telefon</p>
            <v-text-field
              required v-model="phone"
              label="Telefon kontaktowy"
              type="tel"
              
              :rules="phoneRules"
            ></v-text-field>

            <p class="p">Kod pocztowy</p>
            <v-text-field required v-model="postCode" label="kod pocztowy" :rules="[v =>/^[0-9]{2}-[0-9]{3}/.test(v) || 'Nieprawidłowy kod pocztowy', v => v.length <= 6 || 'Nieprawidłowy kod pocztowy']" />

            <p class="p">Miasto</p>
            <v-text-field required v-model="town" label="miasto" />

            <p class="p">Ulica z numerem</p>
            <v-text-field required v-model="adress" label="adres" />

            <p class="p">
              1. Jakie jest Pana(i) główne źródło utrzymania? (np. umowa o
              pracę, prace dorywcze/zlecone, świadczenia socjalne)
            </p>
            <v-text-field required v-model="incomeSource" label="Źródło utrzymania" />

            <p class="p">
              2. Jaki tryb życia Pan(i) prowadzi? (Proszę zaznaczyć prawidłową
              odpowiedź)
            </p>
            <v-select
              required v-model="lifeStyle"
              label="tryb życia"
              :items="['Spokojny', 'Przeciętny', 'Aktywny']"
            ></v-select>

            <p class="p">
              3. Gdzie Pan(i) mieszka? (Proszę zaznaczyć prawidłową odpowiedź)
            </p>
            <v-select
              required v-model="housingType"
              label="typ zamieszkania"
              :items="[
                'W domu z ogrodem/podwórkiem',
                'W bloku/kamienicy',
                '- Mieszkanie z dostępem do ogródka (parter)',
              ]"
            ></v-select>

            <p class="p">
              4. Kto jest właścicielem mieszkania lub domu? (Proszę zaznaczyć
              prawidłową odpowiedź)
            </p>
            <v-select
              required v-model="houseOwner"
              label="właściciel"
              :items="[
                'Ja',
                'Inna osoba z którą mieszkam',
                'Wynajmuję mieszkanie/dom',
              ]"
            ></v-select>

            <p class="p">
              5. Ile maksymalnie godzin w ciągu doby pies będzie zostawał sam w
              domu?
            </p>
            <v-slider
              required v-model="hoursAlone"
              :ticks="[1, 2, 3, 4, 5, 6, 7, 8]"
              :max="9"
              step="1"
              show-ticks="always"
              tick-size="1"
            ></v-slider>

            <p class="p" style="font-weight: bold">
              6. Jeśli mieszka Pan(i) w bloku/ kamienicy lub w mieszkaniu z
              dostępem do ogródka (parter) proszę odpowiedzieć na następujące
              pytania:
            </p>
            <p class="p" style="text-align: left">
              Na którym piętrze Pan(i) mieszka?
            </p>
            <v-text-field
              required v-model="floor"
              hide-details
              single-line
              type="number"
            />

            <p class="p" style="text-align: left">Czy w budynku jest winda?</p>
            <v-select
              required v-model="elevator"
              label="winda"
              :items="['Tak', 'Nie']"
            ></v-select>

            <p class="p" style="text-align: left">
              Jak często pies będzie wychodził na spacer? (na dzień)
            </p>
            <v-slider
              required v-model="walksNumber"
              step="1"
              thumb-label
              max="10"
            ></v-slider>

            <p class="p" style="text-align: left">
              Ile czasu będzie trwał najdłuższy spacer z psem? (w minutach)
            </p>
            <v-slider
              required v-model="walksTime"
              step="10"
              thumb-label
              max="200"
            ></v-slider>

            <p class="p" style="font-weight: bold">
              7. Jeśli mieszka Pan(i) w domu z ogrodem/podwórkiem proszę
              odpowiedzieć na następujące pytania:
            </p>
            <p class="p" style="text-align: left">Czy dom jest ogrodzony?</p>
            <v-select
              required v-model="fence"
              label="ogrodzenie"
              :items="['Tak', 'Nie']"
            ></v-select>

            <p class="p" style="text-align: left">
              Jeśli dom jest ogrodzony to jaką wysokość ma ogrodzenie? (cm)
            </p>
            <v-text-field
              required v-model="fenceHeight"
              label="cm"
              hide-details
              single-line
              type="number"
            />

            <p class="p" style="text-align: left">
              Jaka jest powierzchnia podwórka/ogrodu? (m<sup>2</sup>)
            </p>
            <v-text-field
              required v-model="propertySize"
              label="m2"
              hide-details
              single-line
              type="number"
            />

            <p class="p" style="text-align: left">
              Gdzie pies będzie przebywał w ciągu całej doby? (Proszę napisać
              wszystkie miejsca, gdzie pies będzie przebywał: w domu, na posesji
              luzem, na posesji w budzie, na posesji w kojcu, na posesji na
              uwięzi).
            </p>
            <v-text-field required v-model="petPlace" label="miejsca pobytu psa" />

            <p class="p" style="text-align: left">
              Gdzie będzie przebywał pies w czasie Pana(i) nieobecności oraz
              innych domowników jeśli nie mieszka Pan(i) sam(a)? (Proszę
              szczegółowo opisać, czy pies będzie na podwórku luzem, w kojcu, w
              domu – w jakimś konkretnym pomieszczeniu itp.,itd.)
            </p>
            <v-text-field required v-model="petPlaceAlone" label="miejsce pobytu psa" />

            <p class="p">
              8. Czy podczas dłuższej nieobecności (wakacje, sanatorium, pobyt w
              szpitalu) będzie Pan(i) w stanie zapewnić zastępczą właściwą
              opiekę nad zwierzęciem ?
            </p>
            <v-select
              required v-model="careAlone"
              label="opieka"
              :items="['Tak', 'Nie']"
            ></v-select>

            <p class="p">
              9. Kto mieszka razem z Panem(ią)? (Proszę zaznaczyć prawidłową
              odpowiedź)
            </p>
            <v-select
              required v-model="houseMates"
              label="współlokatorzy"
              :items="[
                'Mieszkam sam(a)',
                'Inne osoby dorosłe',
                'dzieci poniżej 15 roku życia',
              ]"
            ></v-select>

            <p class="p">
              10. Czy w miejscu zamieszkania psa są obecnie inne zwierzęta?
              (Jeśli tak, proszę napisać jakie zwierzęta, ile ich jest i w jakim
              są wieku)
            </p>
            <v-text-field required v-model="animals" label="inne zwierzęta" />

            <p class="p">
              11. Jeśli kiedykolwiek w przeszłości posiadał(a) Pan(i) psa (psy)?
              Jeśli tak, proszę napisać kiedy?
            </p>
            <v-text-field
              required v-model="animalsBefore"
              label="poprzednie zwierzęta"
            />

            <p class="p">
              12. . Jeśli miał(a) Pan(i) psa(y) w przeszłości jakiej był(y) rasy
              i skąd wziął/ wzięły się u Pana(i) i co się z nimi stało?
            </p>
            <v-text-field
              required v-model="animalsBeforeText"
              label="poprzednie zwierzęta"
            />

            <p class="p">13. Prosimy o napisanie kilku słów od siebie</p>
            <v-text-field required v-model="text" label="kilka słów" />
          </v-card-text>
          <v-card-actions class="d-flex align-center flex-column">
            <v-divider :thickness="20" class="border-opacity-0"></v-divider>
           
            <div style="display: flex">
              <v-btn
                color="rgb(175, 126, 158)"
                :disabled="!isValid"
                class="little-title"
                @click="dialog = false"
                >Zrezygnuj</v-btn
              >
              <v-divider
                vertical
                :thickness="300"
                class="border-opacity-0"
              ></v-divider>
              <v-btn
                color="rgb(175, 126, 158)"
                :disabled="!isValid"
                class="little-title"
                @click="Submit()"
                >Zapisz</v-btn
              >
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
import LoginPopup from '@/components/LoginPopup.vue';
import { useForm } from 'vee-validate';
import * as yup from 'yup';
import { useUserStore } from '@/store/user';
import { useNotificationsStore } from '@/store/notifications';
const isValid = ref(true)
const userStore = useUserStore();
const notifStore = useNotificationsStore();
const phoneRules = [v => !!v || 'Wymagane', v => /^[1-9]\d{8}$/.test(v) || 'Nieprawidłowy numer telefonu']

const emailRules = [v => !!v || 'Wymagane',
      v => /.+@.+/.test(v) || 'Nieprawidłowy E-mail'
      ]
var name = ref(userStore.userData.name)
var lname = ref(userStore.userData.lname)
var email = ref(userStore.userData.email)
var phone = ref(userStore.userData.phone)
var postCode = ref(userStore.userData.postCode)
var town = ref(userStore.userData.town)
var adress = ref(userStore.userData.adress)
var incomeSource = ref(userStore.userData.incomeSource)
var lifeStyle = ref(userStore.userData.lifeStyle)
var housingType = ref(userStore.userData.housingType)
var houseOwner = ref(userStore.userData.houseOwner)
var hoursAlone = ref(userStore.userData.hoursAlone)
var floor = ref(userStore.userData.floor)
var elevator = ref(userStore.userData.elevator)
var walksNumber = ref(userStore.userData.walksNumber)
var walksTime = ref(userStore.userData.walksTime)
var fence = ref(userStore.userData.fence)
var fenceHeight = ref(userStore.userData.fenceHeight)
var propertySize = ref(userStore.userData.propertySize)
var petPlace = ref(userStore.userData.petPlace)
var petPlaceAlone = ref(userStore.userData.petPlaceAlone)
var careAlone = ref(userStore.userData.careAlone)
var houseMates = ref(userStore.userData.houseMates)
var animals = ref(userStore.userData.animals)
var animalsBefore = ref(userStore.userData.animalsBefore)
var animalsBeforeText = ref(userStore.userData.animalsBeforeText)
var text = ref(userStore.userData.text)




var dialog = ref(false)





async function Submit() {

console.log(propertySize.value)
console.log(lifeStyle.value)
var userForm = {
  name: name.value,
    lname: lname.value,
    email: email.value,
    phone: phone.value,
    postCode: postCode.value,
    town: town.value,
    adress: adress.value,
    incomeSource: incomeSource.value,
    lifeStyle: lifeStyle.value,
    housingType: housingType.value,
    houseOwner: houseOwner.value,
    hoursAlone: hoursAlone.value,
    floor: floor.value,
    elevator: elevator.value,
    walksNumber: walksNumber.value,
    walksTime: walksTime.value,
    fence: fence.value,
    fenceHeight: fenceHeight.value,
    propertySize: propertySize.value,
    petPlace: petPlace.value,
    petPlaceAlone: petPlaceAlone.value,
    careAlone: careAlone.value,
    houseMates: houseMates.value,
    animals: animals.value,
    animalsBefore: animalsBefore.value,
    animalsBeforeText: animalsBeforeText.value,
    text: text.value
}
const res = await userStore.postUserForm(userForm)

if(res.data.message == "Success"){
        const notification = {
          type: "succes",
          message: "Registered successfully !",
        }
        notifStore.add(notification)
      } 
      else
      {
        const notification = {
          type: "error",
          message: res.data.message,
        }
        notifStore.add(notification)
      }


var userData = {
    name: name,
    lname: lname,
    email: email,
    phone: phone,
    postCode: postCode,
    town: town,
    adress: adress,
    incomeSource: incomeSource,
    lifeStyle: lifeStyle,
    housingType: housingType,
    houseOwner: houseOwner,
    hoursAlone: hoursAlone,
    floor: floor,
    elevator: elevator,
    walksNumber: walksNumber,
    walksTime: walksTime,
    fence: fence,
    fenceHeight: fenceHeight,
    propertySize: propertySize,
    petPlace: petPlace,
    petPlaceAlone: petPlaceAlone,
    careAlone: careAlone,
    houseMates: houseMates,
    animals: animals,
    animalsBefore: animalsBefore,
    animalsBeforeText: animalsBeforeText,
    text: text
}

userStore.userData = userData

}



function onInvalidSubmit({ values, errors, results }) {
  console.log(values); // current form values
  console.log(errors); // a map of field names and their first error message
  console.log(results); // a detailed map of field names and their validation results
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
  color: rgb(0, 0, 0);
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
  background-image: -webkit-gradient(
    linear,
    left bottom,
    left top,
    color-stop(0.14, rgb(235, 196, 222)),
    color-stop(0.24, rgb(221, 167, 202)),
    color-stop(0.52, rgb(175, 126, 158)),
    color-stop(0.86, rgb(131, 70, 109))
  );
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
