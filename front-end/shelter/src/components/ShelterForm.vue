<template>
  <v-dialog
    transition="dialog-bottom-transition"
    overlay-color="black"
    overlay-opacity="1"
    v-model="dialog"
    max-width="80vw"
  >
    <template v-slot:activator="{ props }">
      <v-btn
        elevation="8"
        class="d-flex align-center flex-column text font-big"
        v-bind="props"
      >
        <v-icon color="rgb(143, 83, 122)" icon="mdi-account-edit"> </v-icon>Dane
        schroniska</v-btn
      >
    </template>
    <div
      class="d-flex align-center flex-column"
      style="width: 100%; margin-left: auto; margin-right: auto"
    >
      <div class="title" style="padding: 20px">Dane schroniska</div>
      <v-card
        class="scrollbar"
        width="100%"
        height="85vh"
        style="overflow-y: scroll; border-radius: 10px"
      >

     
      

        <v-divider :thickness="20" class="border-opacity-0"></v-divider>

        <div class="d-flex align-center flex-column">
          <v-divider :thickness="20" class="border-opacity-0"></v-divider>
        </div>
        <v-form class="px-4">
          <v-card-text style="width: 70%; margin: 0 auto">



            <p class="p">Nazwa</p>
            <v-text-field
              v-model="name"
              label="Nazwa"
              type="name"
              :rules="[(v) => !!v || 'Wymagane']"
            />

            <p class="p">E-Mail</p>
            <v-text-field
              v-model="email"
              label="E-mail"
              type="email"
              disabled
              :rules="emailRules"
            />

            <p class="p">Telefon</p>
            <v-text-field
              v-model="phone"
              label="Telefon kontaktowy"
              type="tel"
              required
              :rules="phoneRules"
            ></v-text-field>

            <p class="p">Kod pocztowy</p>
            <v-text-field
              v-model="postCode"
              autocomplete="postal-code"
              label="kod pocztowy"
              :rules="[
                (v) =>
                  /^[0-9]{2}-[0-9]{3}/.test(v) || 'Nieprawidłowy kod pocztowy',
                (v) => v.length <= 6 || 'Nieprawidłowy kod pocztowy',
              ]"
            />

            <p class="p">Miasto</p>
            <v-text-field
              v-model="town"
              label="miasto"
              autocomplete="address-level2"
            />

            <p class="p">Ulica z numerem</p>
            <v-text-field
              v-model="adress"
              label="adres"
              autocomplete="street-address"
            />

            <p class="p">Strona internetowa</p>
            <v-text-field
              v-model="url"
              label="strona internetowa"
              type="url"
              :rules="[(v) => !!v || 'Wymagane']"
            />

            <p class="p" style="font-size: large; font-weight: bold">
              Jakie pytania zawiera Państwa ankieta adopcyjna:
              <br />
              <br />
            </p>

            <v-checkbox
              v-model="incomeSource"
              class="p"
              label=" Jakie jest Pana(i) główne źródło utrzymania? (np. umowa o
                pracę, prace dorywcze/zlecone, świadczenia socjalne)"
            />

            <v-checkbox
              class="p"
              v-model="lifestyle"
              label="Jaki tryb życia Pan(i) prowadzi? (Proszę zaznaczyć prawidłową
                odpowiedź)"
            />

            <v-checkbox
              class="p"
              v-model="housingType"
              label="Gdzie Pan(i) mieszka? (Proszę zaznaczyć prawidłową odpowiedź)"
            />

            <v-checkbox
              class="p"
              v-model="houseOwner"
              label=" Kto jest właścicielem mieszkania lub domu? (Proszę zaznaczyć
                prawidłową odpowiedź)"
            />

            <v-checkbox
              class="p"
              v-model="hoursAlone"
              label="Ile maksymalnie godzin w ciągu doby pies będzie zostawał sam w
                domu?"
            />

            <p class="p" style="font-weight: bold">
              Jeśli mieszka Pan(i) w bloku/ kamienicy lub w mieszkaniu z
              dostępem do ogródka (parter) proszę odpowiedzieć na następujące
              pytania:
            </p>

            <v-checkbox
              class="p"
              v-model="floor"
              label=" Na którym piętrze Pan(i) mieszka?"
            />

            <v-checkbox
              class="p"
              v-model="elevator"
              label="Czy w budynku jest winda?"
            />

            <v-checkbox
              class="p"
              v-model="walksNumber"
              label="Jak często pies będzie wychodził na spacer? (na dzień)"
            />

            <v-checkbox
              class="p"
              v-model="walksTime"
              label=" Ile czasu będzie trwał najdłuższy spacer z psem? (w minutach)"
            />

            <p class="p" style="font-weight: bold">
              Jeśli mieszka Pan(i) w domu z ogrodem/podwórkiem proszę
              odpowiedzieć na następujące pytania:
            </p>
            <v-checkbox
              class="p"
              v-model="fence"
              label="Czy dom jest ogrodzony?"
            />

            <v-checkbox
              class="p"
              v-model="fenceHeight"
              label="  Jeśli dom jest ogrodzony to jaką wysokość ma ogrodzenie? (cm)"
            />

            <v-checkbox
              class="p"
              v-model="propertySize"
              label=" Jaka jest powierzchnia podwórka/ogrodu? (m2)"
            />

            <v-checkbox
              class="p"
              v-model="petPlace"
              label="Gdzie pies będzie przebywał w ciągu całej doby? (Proszę napisać
                wszystkie miejsca, gdzie pies będzie przebywał: w domu, na posesji
                luzem, na posesji w budzie, na posesji w kojcu, na posesji na
                uwięzi)."
            />

            <v-checkbox
              class="p"
              v-model="petPlaceAlone"
              label="Gdzie będzie przebywał pies w czasie Pana(i) nieobecności oraz
                innych domowników jeśli nie mieszka Pan(i) sam(a)? (Proszę
                szczegółowo opisać, czy pies będzie na podwórku luzem, w kojcu, w
                domu – w jakimś konkretnym pomieszczeniu itp.,itd.)"
            />

            <v-checkbox
              class="p"
              v-model="careAlone"
              label=" Czy podczas dłuższej nieobecności (wakacje, sanatorium, pobyt w
                szpitalu) będzie Pan(i) w stanie zapewnić zastępczą właściwą
                opiekę nad zwierzęciem ?"
            />

            <v-checkbox
              class="p"
              v-model="houseMates"
              label="  Kto mieszka razem z Panem(ią)? (Proszę zaznaczyć prawidłową
                odpowiedź)"
            />

            <v-checkbox
              class="p"
              v-model="animals"
              label=" Czy w miejscu zamieszkania psa są obecnie inne zwierzęta?
                (Jeśli tak, proszę napisać jakie zwierzęta, ile ich jest i w jakim
                są wieku)"
            />

            <v-checkbox
              class="p"
              v-model="animalsBefore"
              label=" Jeśli kiedykolwiek w przeszłości posiadał(a) Pan(i) psa (psy)?
                Jeśli tak, proszę napisać kiedy?"
            />

            <v-checkbox
              class="p"
              v-model="animalsBeforeText"
              label=" Jeśli miał(a) Pan(i) psa(y) w przeszłości jakiej był(y) rasy
                i skąd wziął/ wzięły się u Pana(i) i co się z nimi stało?"
            />

            <v-checkbox
              class="p"
              v-model="text"
              label="Prosimy o napisanie kilku słów od siebie"
            />
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
                @click="Submit(shelterData)"
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
import { useShelterStore } from '@/store/shelter';
import { useNotificationsStore } from '@/store/notifications';
const shelterStore = useShelterStore();
const notifStore = useNotificationsStore();
const isValid = ref(true)

const phoneRules = [v => !!v || 'Wymagane', v => /^[1-9]\d{8}$/.test(v) || 'Nieprawidłowy numer telefonu']

const emailRules = [v => !!v || 'Wymagane',
v => /.+@.+/.test(v) || 'Nieprawidłowy E-mail'
]
var name = ref(shelterStore.shelterData.name)
var email = ref(shelterStore.shelterData.email)
var phone = ref(shelterStore.shelterData.phone)
var postCode = ref(shelterStore.shelterData.postCode)
var town = ref(shelterStore.shelterData.town)
var adress = ref(shelterStore.shelterData.adress)
var url = ref(shelterStore.shelterData.url)
var incomeSource = ref(shelterStore.shelterData.incomeSource)
var lifestyle = ref(shelterStore.shelterData.lifestyle)
var housingType = ref(shelterStore.shelterData.housingType)
var houseOwner = ref(shelterStore.shelterData.houseOwner)
var hoursAlone = ref(shelterStore.shelterData.hoursAlone)
var floor = ref(shelterStore.shelterData.floor)
var elevator = ref(shelterStore.shelterData.elevator)
var walksNumber = ref(shelterStore.shelterData.walksNumber)
var walksTime = ref(shelterStore.shelterData.walksTime)
var fence = ref(shelterStore.shelterData.fence)
var fenceHeight = ref(shelterStore.shelterData.fenceHeight)
var propertySize = ref(shelterStore.shelterData.propertySize)
var petPlace = ref(shelterStore.shelterData.petPlace)
var petPlaceAlone = ref(shelterStore.shelterData.petPlaceAlone)
var careAlone = ref(shelterStore.shelterData.careAlone)
var houseMates = ref(shelterStore.shelterData.houseMates)
var animals = ref(shelterStore.shelterData.animals)
var animalsBefore = ref(shelterStore.shelterData.animalsBefore)
var animalsBeforeText = ref(shelterStore.shelterData.animalsBeforeText)
var text = ref(shelterStore.shelterData.text)

var shelterData = {
    name: name,
    email: email,
    phone: phone,
    postCode: postCode,
    town: town,
    adress: adress,
    url: url,
        incomeSource: incomeSource,
        lifestyle: lifestyle,
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


var dialog = ref(false)


async function Submit(shelterData) {
  var shelterForm = {
    name: name.value,
    email: email.value,
    phone: phone.value,
    postCode: postCode.value,
    town: town.value,
    adress: adress.value,
    url: url.value,
        incomeSource: incomeSource.value,
        lifestyle: lifestyle.value,
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

const res = await shelterStore.postShelterForm(shelterForm)

if(res.status == 200){
        const notification = {
          type: "success",
          message: "Updated Successfully !",
        }
        notifStore.add(notification)
      } 


    shelterStore.shelterData = shelterForm;
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
  opacity: 1;
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
