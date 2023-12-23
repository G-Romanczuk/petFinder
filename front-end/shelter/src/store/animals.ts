import { defineStore } from "pinia";
import service from "@/services/service";

export const usePetStore = defineStore("pet", {
  state: () => {
    return {
        pets: []
    }
  },
  actions: {
    async getPets() {
      const res= await service.getPets()

      console.log(res)


      return res
    },
  },
  getters: {
  },
  persist: true,
});
