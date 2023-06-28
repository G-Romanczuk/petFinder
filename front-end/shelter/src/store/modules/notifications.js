// const common = require("/common/common.js")
// import Vue from "vue"

const state = {
    notifications: [],
  }
  
  let nextId = 0
  
  //return the color of snackbar for the type of notification
  function notificationLook(type) {
    const types = [
      "nothing",
      "success",
      "error",
    ] //todo move to UI or common lib
    const colors = [
      "black",
      "blue lighten-2",
      "red lighten-2",
      "blue darken-1",
      "blue darken-1",
      "blue darken-3",
      "blue darken-3",
    ]
    const icons = [
      "mdi-shovel", 
      "mdi-text",
      "mdi-alert",
      "mdi-download",
      "mdi-download",
      "mdi-briefcase-download",
      "mdi-briefcase-download",
    ]
    let i = types.indexOf(type)
    let color = i > 0 ? colors[i] : colors[0]
    let icon = i > 0 ? icons[i] : icons[0]
    return { color, icon }
  }
  
  const mutations = {
    add(state, notification) {
      //TODO: when there are many errors(messages) of the same type then edit the first one with a count
      let { color, icon } = notificationLook(notification.type)
      let timeout = 5000 //default
      if (("" + notification.type).startsWith("downloading")) {
        timeout = -1
      }
  
      let newNotification = {
        ...notification,
        icon,
        id: nextId++,
        color,
        timeout,
      }
  
      if (("" + notification.type).startsWith("downloaded")) {
        //get all notifications for this particular folder/file
  
        let foundNotifications = state.notifications.filter(
          (x) => x.fileActionId == notification.fileActionId
        )
        //now remove them from the notification list by their unique ids
        for (let i = 0; i < foundNotifications.length; i++) {
          let index = state.notifications.findIndex(
            (x) => x.id == foundNotifications[i].id
          )
          // Vue.set(state.notifications, index, newNotification) //refactored by vue3
          state.notifications[index] = newNotification
        }
      } else {
        state.notifications.push(newNotification)
      }
    },
    remove(state, id) {
      state.notifications = state.notifications.filter(
        (notification) => notification.id !== id
      )
    },
    updateNotificationList(state, notificationList) {
      state.notifications = notificationList
    },
  }
  
  const actions = {
    add({ commit }, notification) {
      commit("add", notification)
    },
    remove({ commit }, notificationToRemove) {
      commit("remove", notificationToRemove)
    },
    updateNotificationList({ commit }, notificationList) {
      commit("updateNotificationList", notificationList)
    },
  }
  
  export default {
    namespaced: true,
    state,
    actions,
    mutations,
  }
  