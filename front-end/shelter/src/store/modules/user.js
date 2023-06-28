

const state = {
  loggedUser: "", //early implementation - just login
  password: "",
  userData: null, //login, email, password, token etc
  showLoginForm: false,
  folderTypeNodeState: {
    closed: 0,
    open: 1,
  },
  
}

const getters = {
  getLoggedUser: (state) => state.loggedUser,
}

const actions = {
  updateLoggedUser: ({ commit, dispatch }, login, password) => {
    commit("updateLoggedUser", login, password)
    //TODO: first occurrence of notification in the project
    const notification = {
      type: "success",
      message: login ? `User ${login} logged in` : `User logged out`,
    }
    dispatch("notifications/add", notification, { root: true })
  },

  logout: ({ dispatch }) => {
    dispatch("ui/updateLoggedUser", null)
  },
}

const mutations = {
  updateLoggedUser: (state, login, password) => {
    state.loggedUser = login
    state.password = password
    localStorage.setItem("user", JSON.stringify(login))
  },
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
}
