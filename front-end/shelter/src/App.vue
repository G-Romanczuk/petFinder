<template>
  <v-app>
   
    <AppHeader app ></AppHeader>
    <v-main>
      <router-view ></router-view>
    </v-main>
    <AppFooter app style="opacity: 0.8;"></AppFooter>
   
  </v-app>
</template>

<script lang="ts">
import AppHeader from "./components/AppHeader.vue";
import AppFooter from "./components/AppFooter.vue";
import { defineComponent } from "vue";

export default defineComponent({
  name: "App",

  components: {
   AppHeader,
   AppFooter,
  },

  setup() {

  }
});
</script>
