import { defineStore } from "pinia";
import service from "@/services/service";

export const usePetStore = defineStore("pet", {
  state: () => {
    return {
       id: '',
       img: null,
       petData: {
        name: '',
        images: {},
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
    postPetForm(data) {
      service.postPetForm(data)
    },
  },
  getters: {
  },
  persist: true,
});
