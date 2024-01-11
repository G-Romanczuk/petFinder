import { defineStore } from "pinia";
import service from "@/services/service";
import router from "@/router";
import { useNotificationsStore } from "./notifications";

export const useUserStore = defineStore("user", {
  state: () => {
    return {
      loggedUserJWT: "",
      userData: {
      name: "",
      lname: "",
      email: "",
      phone: "",
      postCode: "",
      town: "",
      adress: "",
      incomeSource: "",
      lifestyle: "",
      housingType: "",
      houseOwner: "",
      hoursAlone: "",
      floor: "",
      elevator: "",
      walksNumber: "",
      walksTime: "",
      fence: "",
      fenceHeight: "",
      propertySize: "",
      petPlace: "",
      petPlaceAlone: "",
      careAlone: "",
      houseMates: "",
      animals: "",
      animalsBefore: "",
      animalsBeforeText: "",
      text: "",
      },
      passwordToken: '',
    };
  },
  actions: {
    async postUserLogin(data) {
      const res = await service.postUserLogin(data)

      return res
    },
    async getUserData(email){
      const res = await service.getUserData(email)

      this.userData.name = res.data.name
      this.userData.lname = res.data.lname
      this.userData.email = res.data.email
      this.userData.phone = res.data.phone
      this.userData.postCode = res.data.postCode
      this.userData.town = res.data.town
      this.userData.adress = res.data.adress
      this.userData.incomeSource = res.data.incomeSource
      this.userData.lifestyle = res.data.lifestyle
      this.userData.housingType = res.data.housingType
      this.userData.houseOwner = res.data.houseOwner
      this.userData.hoursAlone = res.data.hoursAlone
      this.userData.floor = res.data.floor
      this.userData.elevator = res.data.elevator
      this.userData.walksNumber = res.data.walksNumber
      this.userData.walksTime = res.data.walksTime
      this.userData.fence = res.data.fence
      this.userData.fenceHeight = res.data.fenceHeight
      this.userData.propertySize = res.data.propertySize
      this.userData.petPlace = res.data.petPlace
      this.userData.petPlaceAlone = res.data.petPlaceAlone
      this.userData.careAlone = res.data.careAlone
      this.userData.houseMates = res.data.houseMates
      this.userData.animals = res.data.animals
      this.userData.animalsBefore = res.data.animalsBefore
      this.userData.animalsBeforeText = res.data.animalsBeforeText
      this.userData.text = res.data.text

      return res
    },
    async postRegister(data) {
      const res = await service.postRegister(data)
    return res
    },
   async postUserForm(data) {
     const res = await service.postUserForm(data)
     return res
    },
    async resetUserPasswordRequest(){

      var email = {email : this.userData.email}

      const res= await service.resetUserPasswordRequest(email)

      this.passwordToken = res.data
      return res
    },
    async resetUserPassword(data){

      const res= await service.resetUserPassword(data)

      return res
    },
    async deleteUser(email) {
const notifStore = useNotificationsStore()

      const res= await service.deleteUser(email)

      if(res.status == 200){
        router.push('/')

        const notification = {
          type: "Success",
          message: "Deleted succesfully",
        }
    
        notifStore.add(notification)


      }


      return res
    },
  },
  getters: {
    getLoggedUserJWT: (state) => {return state.loggedUserJWT},
  },
  persist: true,
});
