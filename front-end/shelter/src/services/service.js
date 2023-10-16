import axios from "axios";
const baseURL = "https://localhost:7164";

export default {
  async postShelterLogin(data) {
    //data
    // {
    //     emailShelter : emailShelter.value,
    //     passwordShelter: passwordShelter.value
    //   }
    return await axios.post(baseURL + "/api/test", data);
  },
  async postUserLogin(data) {
    //data
    // {
    //     emailShelter : emailUser.value,
    //     passwordUser: passwordUser.value
    //   }
    return await axios.post(baseURL + "/api/test", data);
  },
  async postRegister(data) {
    //data
    //  {
    //     name: nameValue.value,
    //     lname: lnameValue.value,
    //     email: emailValue.value,
    //     password: passwordValue.value,
    //     passwordConfirm: passwordConfirmValue.value,
    //     phone: phoneValue.value,
    //     terms:termsValue.value
    // }
    return await axios.post(baseURL + "/api/test", data);
  },
  async postUserForm(data) {
    //data
    //  {
    //   name: name.value,
    //   lname: lname.value,
    //   email: email.value,
    //   phone: phone.value,
    //   postCode: postCode.value,
    //   town: town.value,
    //   adress: adress.value,
    //   incomeSource: incomeSource.value,
    //   lifestyle: lifestyle.value,
    //   housingType: housingType.value,
    //   houseOwner: houseOwner.value,
    //   hoursAlone: hoursAlone.value, ?????????????????????
    //   floor: floor.value,
    //   elevator: elevator.value,
    //   walksNumber: walksNumber.value, ?????????????
    //   walksTime: walksTime.value, ?????????????????
    //   fence: fence.value,
    //   fenceHeight: fenceHeight.value,
    //   propertySize: propertySize.value,
    //   petPlace: petPlace.value, ???????????
    //   petPlaceAlone: petPlaceAlone.value, ???????????
    //   careAlone: careAlone.value, ?????????????
    //   houseMates: houseMates.value, ???????????
    //   animals: animals.value, ?????????
    //   animalsBefore: animalsBefore.value,
    //   animalsBeforeText: animalsBeforeText.value,
    //   text: text.value ??????????
    // }
    console.log(data);
    //return await axios.post(baseURL + "/api/test", data);
  },
  async postShelterForm(data) {
    //data
    // {
    //     name: name.value,
    //     email: email.value,
    //     phone: phone.value,
    //     postCode: postCode.value,
    //     town: town.value,
    //     adress: adress.value,
    //     url: url.value,
    //     questions: {
    //         incomeSource: incomeSource.value,
    //         lifestyle: lifestyle.value,
    //         housingType: housingType.value,
    //         houseOwner: houseOwner.value,
    //         hoursAlone: hoursAlone.value,
    //         floor: floor.value,
    //         elevator: elevator.value,
    //         walksNumber: walksNumber.value,
    //         walksTime: walksTime.value,
    //         fence: fence.value,
    //         fenceHeight: fenceHeight.value,
    //         propertySize: propertySize.value,
    //         petPlace: petPlace.value,
    //         petPlaceAlone: petPlaceAlone.value,
    //         careAlone: careAlone.value,
    //         houseMates: houseMates.value,
    //         animals: animals.value,
    //         animalsBefore: animalsBefore.value,
    //         animalsBeforeText: animalsBeforeText.value,
    //         text: text.value
    //     }
    //   }
    return await axios.post(baseURL + "/api/test", data);
  },
  async postPetForm(data) {
    //data
    // {
    //    name: name.value,
    //    images: images.value,
    //    type: type.value,
    //    gender: gender.value,
    //    castration: castration.value,
    //    breed: breed.value,
    //    size: size.value,
    //    age: age.value,
    //    vaccination: vaccination.value,
    //    childFriendly: childFriendly.value,
    //    basicTraining: basicTraining.value,
    //    activity: activity.value,
    //    otherDogs: otherDogs.value,
    //    otherCats: otherCats.value,
    //    cuddly: cuddly.value,
    //    temper: temper.value,
    //    text: text.value,
    // }
    return await axios.post(baseURL + "/api/test", data);
  },
};
