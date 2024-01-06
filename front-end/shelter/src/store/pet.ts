import { defineStore } from "pinia";
import service from "@/services/service";

export const usePetStore = defineStore("pet", {
  state: () => {
    return {
      pet: { }
      
      
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
