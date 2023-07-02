<template>
  <div>
    <div class="imagePreviewWrapper" :style="{ 'background-image': `url(${previewImage})` }" > </div>
    <v-file-input label="Zdjęcia" ref="fileInput"  prepend-icon="mdi-camera" accept=".jpg,.png" chips
                            multiple show-size counter
                            :rules="[(v) => v.length <= 5 || 'Maksymalnie 5 plików']" @input="pickFile"  ></v-file-input>
                            
                 
  </div>
</template>
 
<script setup>
import { ref } from 'vue';
import { usePetStore } from '@/store/pet';
const store = usePetStore();
       var previewImage= ref(null)
  const fileInput = ref(null)
      
     function pickFile () {
        let input = fileInput.value
        
        let file = input.files
        if (file && file[0]) {
          let reader = new FileReader
          reader.onload = e => {
            previewImage = e.target.result
            console.log(previewImage)
            store.petData.images = previewImage
        
          }
          reader.readAsDataURL(file[0])
          
        }
      }

</script>
 
<style>
.imagePreviewWrapper {
    width: 250px;
    height: 250px;
    display: block;
    cursor: pointer;
    margin: 0 auto 30px;
    background-size: cover;
    background-position: center center;
}
</style>