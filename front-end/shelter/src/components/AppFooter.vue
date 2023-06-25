<template>
  <v-footer class="bg-grey-lighten-1" absolute>
    <v-row justify="center" no-gutters>
     
      <v-col class="text-center mt-4" cols="12">
        {{ new Date().getFullYear() }} — <strong>Shelter App</strong>
      </v-col>
    </v-row>
  </v-footer>
</template>

<script>
import { ref } from 'vue';

export default {
name: "AppFooter",
setup() {



}
};

</script>
