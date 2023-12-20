<template>
  <v-dialog v-model="dialog" max-width="60vw"  >
      <template v-slot:activator="{ props }">
          <v-btn elevation="8" class="d-flex align-center flex-column font" v-bind="props">Zaloguj
              się</v-btn>
      </template>
      
    
      <div class="d-flex align-center flex-column" style="width: 100%; height: 70vh; margin-left: auto; margin-right: auto;">

          <div class="title" style="padding: 20px;">Logowanie</div>

          
          <v-card class="scrollbar" width="100%" height="58vh" style="overflow-y: scroll; border-radius: 5%;">
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              <v-row>
             <v-col style="height: fit-content; margin: auto 0;">
            
              <v-card-text style="width: 70%; margin: auto; ">

                <div class="little-title" style="padding-bottom: 20px; text-align: center; text-shadow: 0px 0px 0px #000000;">Schronisko</div>
                  <v-form v-model="isValid" class="font">
                      
                      <v-text-field label="E-mail" v-model="emailShelter" :rules="emailRules" required></v-text-field>
                      <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                      <v-text-field :append-icon="show2 ? 'mdi-eye' : 'mdi-eye-off'" clearable  v-model="passwordShelter" label="Hasło" :type="show2 ? 'text' : 'password'"  @click:append="show2 = !show2" :rules="passwordRules"
                          required />
                    
                    

                  </v-form>
              </v-card-text>
              <v-card-actions class="d-flex align-center flex-column">
                  <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              
                      <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                      @click="shelterLogin()">Zaloguj się</v-btn>

                 <v-divider :thickness="10" class="border-opacity-0"></v-divider>
               
              </v-card-actions>
         
            </v-col>

            <div style="width: 2px; height: 350px; background-color: rgb(175, 126, 158); opacity: 0.5; margin: auto 0"></div>

            <v-col>
              <v-card-text style="width: 70%; margin: 0 auto;">
                <div class="little-title" style="padding-bottom: 20px; text-align: center; text-shadow: 0px 0px 0px #000000">Adoptujący</div>
                  <v-form v-model="isValid"  class="font">
                      
                      <v-text-field label="E-mail" v-model="emailUser" :rules="emailRules" required></v-text-field>
                      <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                      <v-text-field :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'" clearable  v-model="passwordUser" label="Hasło" :type="show1 ? 'text' : 'password'"  @click:append="show1 = !show1" :rules="passwordRules"
                          required />
                    

                  </v-form>
              </v-card-text>
              <v-card-actions class="d-flex align-center flex-column">
                  <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              
                      <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                          @click="userLogin()">Zaloguj się</v-btn>
                 <v-divider :thickness="10" class="border-opacity-0"></v-divider>
                 <div style="width: 80%; height: 2px; background-color: rgb(175, 126, 158); opacity: 0.5;"></div>
                 <v-divider :thickness="10" class="border-opacity-0"></v-divider>
                <div class="little-title" style=" text-shadow: 0px 0px 0px #000000">Nie posiadam konta</div>
                 <v-divider  :thickness="20" class="border-opacity-0"></v-divider>
                
                  <RegisterPopup  />
                   

                  <v-divider color="rgb(175, 126, 158)" :thickness="20" class="border-opacity-0"></v-divider>
              </v-card-actions>
            </v-col>

            </v-row>
          </v-card>


      </div>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useUserStore } from '@/store/user';
import { useNotificationsStore } from '@/store/notifications';
import RegisterPopup from './RegisterPopup.vue';
import router from '@/router';
import { useShelterStore } from '@/store/shelter';

const shelterStore = useShelterStore();
const userStore = useUserStore();
const notifStore = useNotificationsStore();
var show1 = ref(false)
var show2 = ref(false)
      const emailUser = ref(null)
      const passwordUser = ref(null)

      

      const emailShelter = ref(null)
      const passwordShelter = ref(null)

      


      const isValid = ref(true)
      

      const emailRules = [v => !!v || 'Wymagane',
      v => /.+@.+/.test(v) || 'Nieprawidłowy E-mail'
      ]
      const passwordRules = [
          v => !!v || 'Password is required',
          v => (v && v.length >= 6) || 'Hasło musi mieć ponad 6 znaków',
          // v => /(?=.*[A-Z])/.test(v) || 'Hasło musi mieć 1 dużą literę',
          // v => /(?=.*\d)/.test(v) || 'Hasło musi mieć 1 liczbę',
          // v => /([!@$%.,<>?/~`^&*])/.test(v) || 'Hasło musi mieć 1 znak specjalny [!@$%.,<>?/~`^&*]'
      ]

      

      var dialog = ref(false)


  async function shelterLogin() {

    var shelterLogin = {
      emailShelter : emailShelter.value,
      passwordShelter: passwordShelter.value
    }
    const res = await  shelterStore.postShelterLogin(shelterLogin)
    dialog = false
    if( res.data.message == "Success"){
      shelterStore.loggedShelterJWT = res.data.jwtToken   //.jwtToken
      shelterStore.shelterData.email = emailShelter.value
      
      router.push('/shelterMenu')
     
      }
      else {
        console.log("wrong password")
      }
  }

    async function userLogin() {
var userLogin = {
  emailUser : emailUser.value,
  passwordUser: passwordUser.value
}
    const res = await userStore.postUserLogin(userLogin)

     if( res.data.message == "Success"){

      const notification = {
    type: "success",
    message: "Loggeed in succesfully",
  }

  notifStore.add(notification)
      console.log(emailUser.value)
     await userStore.getUserData(emailUser.value)  

    userStore.loggedUserJWT = res.data.jwtToken
    dialog = false
    router.push('/userMenu')
   
    }
    else {
      
const notification = {
    type: "error",
    message: res.data.message,
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