<template>
  <v-dialog v-model="dialog" max-width="30vw" max-height="48vh" >
      <template v-slot:activator="{ props }">
          <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text" v-bind="props">Zaloguj
              się</v-btn>
      </template>
      <div class="d-flex align-center flex-column" style="width: 100%; height: 60vh; margin-left: auto; margin-right: auto;">

          <div class="title" style="padding: 20px;">Logowanie</div>


          <v-card class="scrollbar" width="100%" height="55vh" style="overflow-y: scroll; border-radius: 5%;">
              <v-divider :thickness="20" class="border-opacity-0"></v-divider>

             
              <v-card-text style="width: 70%; margin: 0 auto;">
                  <v-form v-model="isValid">
                      
                      <v-text-field label="E-mail" v-model="email" :rules="emailRules" required></v-text-field>
                      <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                      <v-text-field label="Hasło" v-model="password1" type="password" :rules="passwordRules"
                          required></v-text-field>
                    

                  </v-form>
              </v-card-text>
              <v-card-actions class="d-flex align-center flex-column">
                  <v-divider :thickness="20" class="border-opacity-0"></v-divider>
              
                      <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                          @click="dialog = false, //@ts-ignore
      store.loggedUser = email,
      $router.push('/userMenu')">Zaloguj się</v-btn>
                 <v-divider :thickness="10" class="border-opacity-0"></v-divider>
                 <div style="width: 80%; height: 2px; background-color: rgb(175, 126, 158); opacity: 0.5;"></div>
                 <v-divider :thickness="10" class="border-opacity-0"></v-divider>
                <div class="little-title" style=" text-shadow: 0px 0px 0px #000000">Nie posiadam konta</div>
                 <v-divider  :thickness="20" class="border-opacity-0"></v-divider>
               <RegisterPopup />
                  <v-divider color="rgb(175, 126, 158)" :thickness="20" class="border-opacity-0"></v-divider>
              </v-card-actions>

             
          </v-card>


      </div>
  </v-dialog>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useUserStore } from '@/store/user';
import RegisterPopup from './RegisterPopup.vue';

const store = useUserStore();


      const email = ref(null)
      
      const password1 = ref(null)
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






  


</script>

<style lang="css">
.title {
  font-family: cursive;
  font-size: xxx-large;
  font-weight: bolder;
  font-stretch: wider;
  color: white;
  text-shadow: 5px 2px 4px #000000
}

.little-title {
  font-family: cursive;
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