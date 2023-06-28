import { InjectionKey } from "vue"
// @ts-ignore
import { createStore, useStore as baseUseStore, Store } from "vuex"
import user from "./modules/user"
import notifications from "./modules/notifications"

export interface State {
  count: number
  tmp_tmp: number
}

export const key: InjectionKey<Store<State>> = Symbol()

export const store = createStore<State>({
  state: {
    count: 1,
    tmp_tmp: 2,
  },
  getters: {},
  mutations: {},
  actions: {},
  modules: {
    user,
    notifications,
  },
})

// define your own `useStore` composition function
export function useStore() {
  return baseUseStore(key)
}
