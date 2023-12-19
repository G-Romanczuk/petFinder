<template>
    <v-dialog v-model="dialog" max-width="50vw">
       <template v-slot:activator="{ props }">
            
            <div class="d-flex align-center flex-column  font " size="x-large" v-bind="props" style="margin: auto; color:  rgb(91, 30, 133); font-size: 30px;">Zarejestruj
                się</div>
        </template>
       

      


        <div class="d-flex align-center flex-column" style="width: 100%; margin-left: auto; margin-right: auto;">

            <div class="font title" style="padding: 20px;">Rejestracja</div>


            <v-card class="scrollbar" width="100%" height="85vh" style="overflow-y: scroll; border-radius: 5%;">
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>

                <div class="d-flex align-center flex-column">
                    
                 
                <div class="little-title" style=" text-shadow: 0px 0px 0px #000000">Mam już konto</div>
                <v-divider :thickness="10" class="border-opacity-0"></v-divider>
                    <LoginPopup />
                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                    <div style="width: 80%; height: 2px; background-color: rgb(175, 126, 158); opacity: 0.5;"></div>
                </div>
                <v-form @submit="onSubmit" :validation-schema="schema" @invalid-submit="onInvalidSubmit" class="px-4 font">
                    <v-card-text style="width: 70%; margin: 0 auto; color: #000000;">

                        <v-text-field clearable v-bind="name" v-model="nameValue" label="Imie" type="Name" />
                        <v-text-field clearable v-bind="lname" v-model="lnameValue" label="Nazwisko" type="LName" />
                        <v-text-field clearable v-bind="email" v-model="emailValue" label="E-mail" type="email" />

                        <v-text-field :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'" clearable v-bind="password" v-model="passwordValue" label="Hasło" :type="show1 ? 'text' : 'password'"  @click:append="show1 = !show1" />
                        <v-text-field :append-icon="show2 ? 'mdi-eye' : 'mdi-eye-off'" clearable v-bind="passwordConfirm" v-model="passwordConfirmValue" label="Potwierdź hasło" :type="show2 ? 'text' : 'password'"  @click:append="show2 = !show2"/>

                        <v-text-field clearable label="Telefon kontaktowy"  v-bind="phone" v-model="phoneValue"  type="tel"
                            required></v-text-field>


                        <v-checkbox label="Potwierdzam zapoznanie się z regulaminem i akceptację bababa" 
                            required v-bind="terms" v-model="termsValue"></v-checkbox>
                        <v-checkbox label="Zgoda na przetwarzanie informacji" required
                            v-bind="terms"></v-checkbox>
                    </v-card-text>
                    <v-card-actions class="d-flex align-center flex-column">
                       
                      
                        <div style="display: flex; ">
                            <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                                @click="dialog = false">Zrezygnuj</v-btn>
                            <v-divider vertical :thickness="300" class="border-opacity-0"></v-divider>
                            <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                              @click="onSubmit"  type="submit" >Zarejestruj się</v-btn>
                              
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
const store = useUserStore();
const notifStore = useNotificationsStore();



var dialog = ref(false)
var show1 = ref(false)
var show2 = ref(false)


const schema = yup.object({
    name: yup.string().required().label('Imie'),
    lname: yup.string().required().label('Nazwisko'),
    email: yup.string().email().required().label('E-mail'),
    password: yup.string().min(6).required(),
    passwordConfirm: yup
        .string()
        .oneOf([yup.ref('password')], 'Passwords must match')
        .required()
        .label('Password confirmation'),
    terms: yup
        .boolean()
        .required()
        .oneOf([true], 'You must agree to terms and conditions'),
    phone: yup.string().required().matches(/^[1-9]\d{8}$/, {message: "Please enter valid number.", excludeEmptyString: false}),
   // userType: yup.string().required() .oneOf(["Schronisko", "Adoptujący"]).label('select'),
});

const { defineComponentBinds, handleSubmit, resetForm } = useForm({
    validationSchema: schema,
});

// Refer to the docs for how to make advanced validation behaviors with dynamic configs
// TODO: Add link
const vuetifyConfig = (state) => ({
    props: {
        'error-messages': state.errors,
    },
});

var nameValue = ref()
var lnameValue = ref()
var emailValue = ref()
var passwordValue = ref()
var passwordConfirmValue = ref()
var phoneValue = ref()
var termsValue = ref()



const name = defineComponentBinds('name', vuetifyConfig);
const lname = defineComponentBinds('lname', vuetifyConfig);
const email = defineComponentBinds('email', vuetifyConfig);
const password = defineComponentBinds('password', vuetifyConfig);
const passwordConfirm = defineComponentBinds('passwordConfirm', vuetifyConfig);
const phone = defineComponentBinds('phone', vuetifyConfig);
const terms = defineComponentBinds('terms', vuetifyConfig);
//const userType = defineComponentBinds('select', vuetifyConfig);
//const items = [ 'Schronisko', 'Adoptujący']


const onSubmit = handleSubmit((values) => {
   // alert(JSON.stringify(values, null, 2));

    var register = {
    name: nameValue.value,
    lname: lnameValue.value,
    email: emailValue.value,
    password: passwordValue.value,
    passwordConfirm: passwordConfirmValue.value,
    phone: phoneValue.value,
    terms:termsValue.value
}

Post(register)
});

async function Post(form) {
    const res = await userStore.postRegister(form)

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
}

function onInvalidSubmit({ values, errors, results }) {
  console.log(values); // current form values
  console.log(errors); // a map of field names and their first error message
  console.log(results); // a detailed map of field names and their validation results
}







// async function registerUserTest() {

// var register = {
//     name: nameValue.value,
//     lname: lnameValue.value,
//     email: emailValue.value,
//     password: passwordValue.value,
//     passwordConfirm: passwordConfirmValue.value,
//     phone: phoneValue.value,
//     terms:termsValue.value
// }

// userStore.postRegister(register)
//}





</script>

<style lang="css">

@import url('https://fonts.googleapis.com/css2?family=Gruppo&display=swap');


.font {
  font-family: 'Gruppo', sans-serif;
  text-decoration: none;
font-weight:900;
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
    text-shadow: 1px 1px 2px #000000
}

.font-big {
  font-size: large;
  font-weight: 600;
}

.font-bigger {
  font-size:x-large;
  font-weight: 900;
}

.font {
  font-family: 'Gruppo', sans-serif;
  text-decoration: none;
  font-weight: 900;
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