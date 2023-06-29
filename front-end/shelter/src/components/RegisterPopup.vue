<template>
    <v-dialog v-model="dialog" max-width="50vw">
        <template v-slot:activator="{ props }">
            <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text" v-bind="props">Zarejestruj
                się</v-btn>
        </template>
        <div class="d-flex align-center flex-column" style="width: 100%; margin-left: auto; margin-right: auto;">

            <div class="title" style="padding: 20px;">Rejestracja</div>


            <v-card class="scrollbar" width="100%" height="85vh" style="overflow-y: scroll; border-radius: 5%;">
                <v-divider :thickness="20" class="border-opacity-0"></v-divider>

                <div class="d-flex align-center flex-column">
                    <LoginPopup />
                    <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                </div>
                <v-form @submit="onSubmit" class="px-4">
                    <v-card-text style="width: 70%; margin: 0 auto;">

                        <v-text-field v-bind="name"  label="Name" />
                        <v-text-field v-bind="email"  label="E-mail" type="email" />

                        <v-text-field v-bind="password" label="Hasło" type="password" />
                        <v-text-field v-bind="passwordConfirm" label="Potwierdź hasło" type="password" />

                        <v-text-field label="Telefon kontaktowy"  v-bind="phone"  type="tel"
                            required></v-text-field>

                        <v-select v-bind="userType"  :items="items" label="Typ użytkownika" persistent-hint return-object
                            single-line required></v-select>


                        <v-checkbox label="Potwierdzam zapoznanie się z regulaminem i akceptację bababa" 
                            required v-bind="terms"></v-checkbox>
                        <v-checkbox label="Zgoda na przetwarzanie informacji" required
                            v-bind="terms"></v-checkbox>
                    </v-card-text>
                    <v-card-actions class="d-flex align-center flex-column">
                        <v-divider :thickness="20" class="border-opacity-0"></v-divider>
                        <v-btn color="outline" class="ml-4" @click="resetForm()"> Reset </v-btn>
                        <div style="display: flex; ">
                            <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                                @click="dialog = false">Zrezygnuj</v-btn>
                            <v-divider vertical :thickness="300" class="border-opacity-0"></v-divider>
                            <v-btn color="rgb(175, 126, 158)" :disabled="!isValid" class="little-title"
                                @click="dialog = false" type="submit">Zarejestruj się</v-btn>
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


const isValid = ref(true)




var dialog = ref(false)



const schema = yup.object({
    name: yup.string().required().label('Name'),
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
    userType: yup.string().required().label('select'),
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

const name = defineComponentBinds('name', vuetifyConfig);
const email = defineComponentBinds('email', vuetifyConfig);
const password = defineComponentBinds('password', vuetifyConfig);
const passwordConfirm = defineComponentBinds('passwordConfirm', vuetifyConfig);
const phone = defineComponentBinds('phone', vuetifyConfig);
const terms = defineComponentBinds('terms', vuetifyConfig);
const userType = defineComponentBinds('select', vuetifyConfig);
const items = [ 'Schronisko', 'Adoptujący']


const onSubmit = handleSubmit((values) => {
    console.log('Submitted with', values);
});

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