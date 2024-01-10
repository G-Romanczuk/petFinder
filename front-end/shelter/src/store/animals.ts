import { defineStore } from "pinia";
import service from "@/services/service";
import { useUserStore } from "./user";
export const useAnimalsStore = defineStore("pet", {
  state: () => {
    return {
      pets: [],
      allPets: [],
      unliked: [],
      likedPetIds: [],
      likedPets: [],
    }
  },
  actions: {
    async getAllPets() {
      const userStore = useUserStore();
      const res = await service.getAllPets()

      this.allPets = res.data
      console.log(this.allPets)
      await this.getLikedPets(userStore.userData.email)
      await this.deleteLikedPets();

      return res
    },
    async getLikedPets(data) {

      const res = await service.getLikedPets(data)
      
      this.likedPetIds = res.data
      await this.fillLikedPets();
      return res

    },


    async addLikedPets() {
      const userStore = useUserStore();
      //send to server
      this.likedPetIds = []
      for (let i = 0; i < this.likedPets.length; i++) {
          if(  !this.likedPetIds.includes(this.likedPets[i].id)){
            this.likedPetIds.push(this.likedPets[i].id)
          }

      }

      var data = {
        userEmail: userStore.userData.email,
        likedPetIds: this.likedPetIds
      }
      console.log(data)

      const res = await service.addLikedPets(data)

      return res

    },



    async fillLikedPets() {

      if (this.likedPetIds != undefined) {
        this.likedPets = []
        //fills likedPets table with objects of pets of likedpetsids
        for (let i = 0; i < this.allPets.length; i++) {

          for (let j = 0; j < this.likedPetIds.length; j++) {

            if (this.allPets[i].id == this.likedPetIds[j]) {


              if(  !this.likedPets.includes(this.allPets[i])){
              this.likedPets.push(this.allPets[i])
              }
            }
          }
        }
      }



    },
    async deleteLikedPets() {
      if (this.likedPets != undefined) {

        this.pets = []
        //deletes liked pets from pets table
        for (let i = 0; i < this.allPets.length; i++) {
          var check = 0
          for (let j = 0; j < this.likedPets.length; j++) {

            if (this.allPets[i].id != this.likedPets[j].id) {
              check++;
            }
          }

          if (check == this.likedPets.length) {
            this.pets.push(this.allPets[i])
          }
        }
      }
      else this.allPets = this.pets



    },
    async unlikePet(id) {

      console.log(id)
     for (let i = 0; i < this.likedPets.length; i++) {

        if(this.likedPets[i].id == id){
          this.likedPets.splice(i)
          
        }

      }
      console.log(this.likedPets)
      this.addLikedPets()

    }
  },
  getters: {
  },
  persist: true,
});
