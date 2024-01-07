import { defineStore } from "pinia";
import service from "@/services/service";

export const useAnimalsStore = defineStore("pet", {
  state: () => {
    return {
        pets: []
    }
  },
  actions: {
    async getPets() {
      const res= await service.getPets()

      this.pets = res.data


      return res
    },
  },
  getters: {
  },
  persist: true,
});
