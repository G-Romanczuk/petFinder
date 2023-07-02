<template>
    <div>
        <div class="imagePreviewWrapper" :style="{ 'background-image': `url(${previewImage})` }" > </div>
    <v-file-input label="Zdjęcia" ref="fileInput"  prepend-icon="mdi-camera" accept=".jpg,.png" chips
                            multiple show-size counter
                            :rules="[(v) => v.length <= 5 || 'Maksymalnie 5 plików']" @input="pickFile"  ></v-file-input>
                            
            
    </div>
  </template>
   
  <script>
  export default {
    data() {
        return {
          previewImage: null
        };
      },
    methods: {
       
        pickFile () {
          let input = this.$refs.fileInput
          
          let file = input.files
          if (file && file[0]) {
            let reader = new FileReader
            reader.onload = e => {
              this.previewImage = e.target.result
              console.log(file[0])
            }
            reader.readAsDataURL(file[0])
          }
        }
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