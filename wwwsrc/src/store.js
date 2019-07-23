import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost:8080') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaults: [],
    vault: {},
    keeps: [],
    keep: {}
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setMyKeep(state, keep) {
      state.keep = keep
    }
  },
  actions: {
    //#region  Account
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    //#endregion
    //#region Vaults
    async getVaultsByUser({ commit, dispatch }) {

    },

    async createVault({ commit, dispatch }, data) {

    },

    async deleteVault({ commit, dispatch }, value) {

    },
    //#endregion
    //#region Keeps
    async getAllKeeps({ commit, dispatch }) {
      await api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    async getKeepById({ commit, dispatch }, keepId) {
      //update view
      await api.get('keeps/' + keepId)
        .then(res => {
          commit('setMyKeep', res.data)
        })
    },
    async getKeepsByUser({ commit, dispatch }) {

    },

    async createKeep({ commit, dispatch }, data) {

    },
    async deleteKeep({ commit, dispatch }, value) {

    },
    async addKeepToVault({ commit, dispatch }, data) {
      //need to update count of adds
    },
    async removeKeepFromVault({ commit, dispatch }, data) {

    }




  }
})
