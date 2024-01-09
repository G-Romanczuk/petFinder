import { defineStore } from "pinia";
import service from "@/services/service";
import { useUserStore } from "./user";
export const useAnimalsStore = defineStore("pet", {
  state: () => {
    return {
        pets: [],
        allPets:[],
        unliked: [],
    }
  },
  actions: {
    async getPets() {
      const res= await service.getPets()

      this.allPets = res.data


      await this.fillLikedPets();
     await this.deleteLikedPets();

      return res
    },
    async fillLikedPets(){
      var userStore = useUserStore()



      for(let i = 0; i < this.allPets.length; i++){
        
        for(let j = 0; j < userStore.userData.likedPetIds.length; j++){

            if(this.allPets[i].id == userStore.userData.likedPetIds[j]){

              userStore.userData.likedPets.push(this.allPets[i])
              
            }
        }

       


      }


    },
    async deleteLikedPets(){
      var userStore = useUserStore()
      for(let i = 0; i < this.allPets.length; i++){
        var check = 0
        for(let j = 0; j < userStore.userData.likedPets.length; j++){

            if(this.allPets[i].id != userStore.userData.likedPets[j].id){
              check++;
            }
        }

        if(check == userStore.userData.likedPets.length) {
         this.pets.push(this.allPets[i])
        }


      }


    }
  },
  getters: {
  },
  persist: true,
});
