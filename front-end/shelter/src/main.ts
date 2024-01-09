/**
 * main.ts
 *
 * Bootstraps Vuetify and other plugins then mounts the App`
 */
//store
import {createPinia} from 'pinia';
import piniaPluginPersistedState from "pinia-plugin-persistedstate"
const store = createPinia();
store.use(piniaPluginPersistedState);
const app = createApp(App)
app.use(store)
// Components
import App from './App.vue'

// Composables
import { createApp } from 'vue'

// Plugins
import { registerPlugins } from '@/plugins'

//router
import router from './router'

import { useUserStore } from './store/user';
const userStore = useUserStore()

import 'hammerjs';
registerPlugins(app)

app.use(router)

app.mount('#app')
