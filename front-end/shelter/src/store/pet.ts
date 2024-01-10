import { defineStore } from "pinia";
import service from "@/services/service";

export const usePetStore = defineStore("pet", {
  state: () => {
    return {
      pet: {
        shelterEmail: '',
        name: '',
        images: [],
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
    }
      
      
    }
  },
  actions: {
    async postPetForm(data) {
      const res= await service.postPetForm(data)



      return res
    },
    async postPetFormUpdate(data) {
      const res= await service.postPetFormUpdate(data)



      return res
    },
  },
  getters: {
  },
  persist: true,
});
