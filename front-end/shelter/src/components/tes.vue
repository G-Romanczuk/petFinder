<template>
  <div>
    <v-snackbar
      v-model="snackbar"
      right="true"
      :color="notification.color"
      :on-load="deleteAfterTimeout(notification.id, notification.timeout)"
      timeout="-1"
      :id="notification.id"
      :style="{ bottom: calcDistance(number) }"
      v-if="notifications != ''"
      v-for="(notification, number) in notifications"
    >
      <template v-slot:default>
        <slot class="notification-slot" :message="notification.message">
          <v-icon v-if="notification.icon">{{ notification.icon }}</v-icon>
          {{ notification.message }}
        </slot>
        <v-btn
          class="close-button"
          text
          :id="notification.id"
          @click="deleteNotification = notification.id"
          color="black"
          right="0vh"
        >
          Close</v-btn
        >
      </template>
    </v-snackbar>
  </div>
</template>

<script>
import { ref, computed, watch, reactive } from "vue"
import { store } from "@/store/store"
export default {
  name: "VSnackbars",
  setup() {
    const snackbar = ref(true)
    const notifications = computed({
      get: () => {
        return store.state.notifications.notifications
      },
      set: (value) =>
        store.dispatch("notifications/updateNotificationList", value),
    })
    watch(store.state.notifications.notifications, (newValue, oldValue) => {
      console.log(newValue)
      snackbar.value = true
    })
    const deleteNotification = computed({
      get: () => {
        return id
      },
      set: (id) => {
        console.log(id)
        store.dispatch("notifications/remove", id)
      },
    })

    function deleteAfterTimeout(id, timeout) {
      if (timeout != -1) {
        setTimeout(function del() {
          store.dispatch("notifications/remove", id)
        }, timeout)
      }
    }

    function calcDistance(number) {
      let height = window.innerHeight
      let footer_height = 0.15 * height
      return number * 67 + footer_height + "px"
    }

    return {
      snackbar,
      notifications,
      deleteNotification,
      calcDistance,
      deleteAfterTimeout,
    }
  },
}
</script>

<style lang="css" scoped>
.close-button {
  float: right;
}
.my-snackbar {
  max-height: 4vh;
}
</style>
