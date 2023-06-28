<template>
  <v-dialog
    v-model="dialog"
    max-width="35vw"
    max-height="50vh"
  >
    <template v-slot:activator="{ props }">
      <v-btn elevation="8" class="d-flex align-center flex-column main-text main-text" v-bind="props" >Logowanie</v-btn>
    </template>
    <div class="LoginPopup">
      <v-card>
        <v-card-title class="text-center main-text">
          <h2>Log in</h2>
        </v-card-title>

        <v-card-text class="text-center">
          <div>
            <form @submit.prevent="logIn">
              <v-text-field
                v-model="login"
                :rules="[rules.required, rules.counter]"
                label="Login"
                counter
                maxlength="20"
                @keydown.enter.prevent="logIn"
              ></v-text-field>
              <v-text-field
                v-model="password"
                :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                :rules="[rules.required, rules.min]"
                :type="show1 ? 'text' : 'password'"
                name="input-10-1"
                label="Password"
                hint="At least 6 characters"
                counter
                @click:append="show1 = !show1"
                @keydown.enter.prevent="logIn"
              ></v-text-field>
            </form>
          </div>
          <!--div>-- or --</div>
        <div>email and passwd</div>
        <div>-- or --</div>
        <div>ActiveDirectory</div-->
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" text @click="dialog = false"> Cancel </v-btn>
          <v-btn color="primary" text @click="logIn"> Log in</v-btn>
        </v-card-actions>
      </v-card>
    </div>
  </v-dialog>
</template>

<script>
import { useStore } from "vuex"
const store = useStore()
export default {
  name: "LoginPopup",
  data: () => ({
    dialog: false,
    show1: false,
    password: "",
    login: "",
    rules: {
      required: (value) => !!value || "Required.",
      min: (v) => v.length >= 8 || "Min 8 characters",
      emailMatch: () => `The email and password you entered don't match`,
    },
  }),
  methods: {
    logIn() {
      this.$store
        .dispatch("ui/login", {
          login: this.login,
          password: this.password,
        })
        .then(() => {
          this.loggedUser = this.login
          console.log("logged user " + this.login)
        })
    },
  }, //methods
  computed: {
    loggedUser: {
      get() {
        return this.$store.state.ui.loggedUser
      },
      set(value) {
        this.$store.dispatch("ui/updateLoggedUser", value)
      },
    },
  }, //computed
}
</script>

<style lang="css">
.v-card-title {

}
</style>
