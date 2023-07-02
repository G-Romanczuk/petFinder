import { defineStore } from "pinia";

export const usePetStore = defineStore("pet", {
  state: () => {
    return {
       id: '',
       petData: {
        name: '',
        images: '',
        type: '',
        gender: '',
        castration: '',
        breed: '',
        size: '',
        age: '',
        vaccination: '',
        childFriendly: '',
        basicTraining: '',
        activity: '',
        otherDogs: '',
        otherCats: '',
        cuddly: '',
        temper: '',
        text: '',
       },
       shelterId: '',
       shelterName: '',
       city: '',
      
    }
  },
  actions: {
    
  },
  getters: {
  },
  persist: true,
});
