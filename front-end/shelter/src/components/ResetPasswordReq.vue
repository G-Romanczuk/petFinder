<template>
  <v-dialog v-model="dialog" max-width="60vw">
    <template v-slot:activator="{ props }">
      <v-btn elevation="8" class="text font-big" v-bind="props">
        <v-icon color="rgb(143, 83, 122)" icon="mdi-lock-reset"> </v-icon> Zmień hasło</v-btn>
    </template>


    <div class="d-flex align-center flex-column" style="width: 30vw; height: fit-content; margin: auto;">
      <v-sheet style="
                float: left;
                width: 100%;
                border-radius: 60px;
                background-color: rgb(162, 104, 177);
              " v-if="show">
        <div style="width: fit-content; margin: 0 auto; text-align: center;">
          <h1 style="color: white; text-shadow: 5px 2px 4px #000000" class="little-title">
            Witaj {{ userStore.userData.name }}{{ shelterStore.shelterData.email }}! <br> Poproś o token do zmiany hasła :
            <br> <br>
          </h1>
        </div>

        <div style="width: fit-content; margin: 0 auto;">
          <v-btn variant="tonal" color="white" class="font" @click="getToken()">
            Zdobądź token</v-btn>
        </div>

        <v-divider :thickness="20" class="border-opacity-0"></v-divider>
      </v-sheet>


      <v-sheet style="
                float: left;
                width: 100%;
                border-radius: 60px;
                background-color: rgb(255, 255, 255);
              " v-else>
        <v-form @submit="onSubmit" :validation-schema="schema" @invalid-submit="onInvalidSubmit" class="px-4 font">
          <v-card-text style="width: 70%; margin: 0 auto; color: #000000;">

            <v-text-field clearable v-bind="email" v-model="emailValue" label="E-mail" type="email" />
            <v-text-field clearable v-bind="token" v-model="tokenValue" label="Token" type="token" />
            <v-text-field :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'" clearable v-bind="password"
              v-model="passwordValue" label="Hasło" :type="show1 ? 'text' : 'password'" @click:append="show1 = !show1" />
            <v-text-field :append-icon="show2 ? 'mdi-eye' : 'mdi-eye-off'" clearable v-bind="passwordConfirm"
              v-model="passwordConfirmValue" label="Potwierdź hasło" :type="show2 ? 'text' : 'password'"
              @click:append="show2 = !show2" />



          </v-card-text>
          <v-card-actions class="d-flex align-center flex-column">


            <div style="display: flex; ">
              <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                @click="dialog = false">Zrezygnuj</v-btn>
              <v-divider vertical :thickness="30" class="border-opacity-0"></v-divider>
              <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title" @click="onSubmit"
                type="submit">Zarejestruj się</v-btn>

            </div>

            <v-divider :thickness="20" class="border-opacity-0"></v-divider>
          </v-card-actions>
        </v-form>
      </v-sheet>
    </div>
  </v-dialog>
</template>
  
<script setup lang="ts">
import { ref } from 'vue'
import { useUserStore } from '@/store/user';
import { useShelterStore } from '@/store/shelter';
import { useForm } from 'vee-validate';
import { useNotificationsStore } from '@/store/notifications';
import * as yup from 'yup';

const notifStore = useNotificationsStore();
var dialog = ref(false)
var show = ref(true)
const userStore = useUserStore();
const shelterStore = useShelterStore();


function getToken() {

  if (shelterStore.loggedShelterJWT != '') {
    shelterStore.resetShelterPasswordRequest();
    show.value = false

  } else if (userStore.loggedUserJWT != '') {
    userStore.resetUserPasswordRequest();
    show.value = false
  }

}

const isValid = ref(true)
var show1 = ref(false)
var show2 = ref(false)


const schema = yup.object({
  token: yup.string().required().label('Token'),
  email: yup.string().email().required().label('E-mail'),
  password: yup.string().min(6).required(),
  passwordConfirm: yup
    .string()
    .oneOf([yup.ref('password')], 'Passwords must match')
    .required()
    .label('Password confirmation'),
});



const vuetifyConfig = (state) => ({
  props: {
    'error-messages': state.errors,
  },
});

const { defineComponentBinds, handleSubmit, resetForm } = useForm({
  validationSchema: schema,
});
var tokenValue = ref()
var emailValue = ref()
var passwordValue = ref()
var passwordConfirmValue = ref()


const token = defineComponentBinds('token', vuetifyConfig);
const email = defineComponentBinds('email', vuetifyConfig);
const password = defineComponentBinds('password', vuetifyConfig);
const passwordConfirm = defineComponentBinds('passwordConfirm', vuetifyConfig);



function onInvalidSubmit({ values, errors, results }) {
  console.log(values); // current form values
  console.log(errors); // a map of field names and their first error message
  console.log(results); // a detailed map of field names and their validation results
}


const onSubmit = handleSubmit((values) => {
  // alert(JSON.stringify(values, null, 2));

  var data = {

    email: emailValue.value,
    token: tokenValue.value,
    newPassword: passwordValue.value,
    confirmPassword: passwordConfirmValue.value
  }

  Post(data)
});



async function Post(form) {
  var res 
  if (shelterStore.loggedShelterJWT != '') {
     res = await shelterStore.resetShelterPassword(form)
     dialog.value = false

  } else if (userStore.loggedUserJWT != '') {
    res = await userStore.resetUserPassword(form)
    dialog.value = false
  }


  if (res.status == 200) {
    const notification = {
      type: "success",
      message: "Password changed successfully !",
    }
    notifStore.add(notification)
  }


}




</script>
  
<style lang="css">
@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');


.font {
  font-family: 'Gruppo', sans-serif;
  text-decoration: none;
  font-weight: 900;
}



.scale :hover {
  transform: scale(1.2);
}




.title {
  font-family: 'Gruppo', sans-serif;
  font-size: xxx-large;
  font-weight: bolder;
  font-stretch: wider;
  color: white;
  text-shadow: 5px 2px 4px #000000
}

.little-title {
  font-family: 'Gruppo', sans-serif;
  font-weight: bold;
  font-size: medium;
  color: rgb(175, 126, 158);
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

.circle {
  border-radius: 50%;
}

.circle-hover :hover {
  opacity: 0.5;
}</style>