<template>
    <div style="width: 100vw;" class="background">
        <v-sheet height="100px" style="opacity: 0;"></v-sheet>
        <div class="d-flex align-center flex-column" style="width: 80vw; margin-left: auto; margin-right: auto">

            <div class="title" style="padding: 20px;">Rejestracja</div>


            <v-card width="70%">
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                
                <div class="d-flex align-center flex-column">
                    <LoginPopup v-if="loggedUser == ''" />
                    <v-btn class="little-title" target="_blank" v-else @click="loggedUser = ''">Mam już konto</v-btn></div>
                <v-card-text style="width: 70%; margin: 0 auto;">
                    <v-form v-model="isValid">
                        <v-text-field label="Imie" v-model="name" required></v-text-field>
                        <v-text-field label="E-mail" v-model="email" :rules="emailRules" required></v-text-field>
                        <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                        <v-text-field label="Hasło" v-model="password1" type="password" :rules="passwordRules"
                            required></v-text-field>
                        <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                        
                        <v-text-field label="Telefon kontaktowy" v-model="phone" :rules="phonerules" type="tel"
                            required></v-text-field>
                            
                            <div  style="margin: 0 auto; width: fit-content; text-align: center;">
                                <v-card-title class="little-title"> Data urodzenia</v-card-title><VueDatePicker v-model="dateOfBirth" :flow="flow" inline  :enable-time-picker="false"/></div>
                            


                        <v-checkbox label="Potwierdzam zapoznanie się z regulaminem i akceptację bababa" v-model="checkbox1"
                            required :rules="checkboxrules"></v-checkbox>
                        <v-checkbox label="Zgoda na przetwarzanie informacji" v-model="checkbox2" required
                            :rules="checkboxrules"></v-checkbox>
                    </v-form>
                </v-card-text>
                <v-card-actions class="d-flex align-center flex-column">
                    <v-btn color="primary" :disabled="!isValid" class="little-title">Zarejestruj się</v-btn>
                </v-card-actions>
            </v-card>



            <div style="height: 15vh;"></div>

        </div>
        <v-img src="@/assets/dog-corner.png" style="width: 20%; position: absolute; right: 0; bottom: 0vh; " ></v-img>
    </div>
</template>

<script lang="ts">
import { computed, ref } from 'vue'
import VueDatePicker from '@vuepic/vue-datepicker';
import LoginPopup from '@/components/LoginPopup.vue';
import '@vuepic/vue-datepicker/dist/main.css'
import { store } from '@/store/store';
export default {
    name: "RegisterView",
    components: {VueDatePicker, LoginPopup},
    setup() {

        let name = ref()
        const email = ref(null)
        const password1 = ref(null)
        const isValid = ref(true)
        const checkbox1 = ref(false)
        const checkbox2 = ref(false)
        const phone = ref(null)
        const dateOfBirth = ref()
        const flow = ref(['year','month',  'calendar']);

        const emailRules = [v => !!v || 'Wymagane',
        v => /.+@.+/.test(v) || 'Nieprawidłowy E-mail'
        ]
        const passwordRules = [
            v => !!v || 'Password is required',
            v => (v && v.length >= 5) || 'Hasło musi mieć ponad 5 znaków',
            v => /(?=.*[A-Z])/.test(v) || 'Hasło musi mieć 1 dużą literę',
            v => /(?=.*\d)/.test(v) || 'Hasło musi mieć 1 liczbę',
            v => /([!@$%.,<>?/~`^&*])/.test(v) || 'Hasło musi mieć 1 znak specjalny [!@$%.,<>?/~`^&*]'
        ]

        const checkboxrules = [v => !!v || 'Wymagane']

        const phonerules = [v => !!v || 'Wymagane', v => /\d{9}/.test(v) || 'Nieprawidłowy numer telefonu',]

        const dateOfBirthrules = [v => !!v || 'Wymagane']

        var dialog = ref(false)


const loggedUser = computed({
  get: () => store.state.user.loggedUser,
  set: (value) => store.dispatch("ui/updateLoggedUser", value),
})
       



        return { email, password1, checkbox1, checkbox2, phone, dateOfBirth, isValid, emailRules, passwordRules, checkboxrules, phonerules, dateOfBirthrules, flow, name, loggedUser, dialog }
    }
}

</script>

<style lang="css">
.background {
    background: url('@/assets/landing-pink-gradient.png') no-repeat center center fixed !important;
    background-size: cover;
    position: relative;
    top: 0;
}

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
    text-shadow: 1px 2px 2px #000000
}
</style>