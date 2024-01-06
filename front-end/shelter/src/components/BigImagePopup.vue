<template>
    <v-dialog v-model="dialog" width="98vw" height="98vh">
        <template v-slot:activator="{ props }">

            <v-btn elevation="0" class="text font-big" v-bind="props" style="background-color:  rgba(255, 255, 255, 0.5);">
                <v-icon icon="mdi-magnify"></v-icon>
            </v-btn>
        </template>
        <div class="d-flex align-center flex-column" style="width: 100%; margin: auto; height: 100%;">


            <v-card  width="100%" height="98vh" style="overflow-y: hidden; border-radius: 10px;">
                <v-img v-bind:src="props.img" height="100%"  >
                    <v-btn style="float: right; background-color:  rgba(255, 255, 255, 0.123); margin: 10px 10px 0 0;" @click="dialog = false"> <v-icon icon="mdi-window-close"></v-icon></v-btn>
                </v-img>
                

            
            </v-card>


        </div>
    </v-dialog>
</template>

<script setup lang="js">
import { ref } from 'vue'

const props = defineProps({
   img: String
})


var dialog = ref(false)



</script>

<style lang="css">
</style>