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
    keep: {},
    myKeeps: [],
    vaultKeeps: []
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
    setVault(state, vault) {
      state.vault = vault
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setMyKeep(state, keep) {
      state.keep = keep
    },
    setMyKeeps(state, myKeeps) {
      state.myKeeps = myKeeps
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultKeeps = vaultkeeps;
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

      await api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },

    async getVaultById({ commit, dispatch }, vaultId) {

      await api.get('vaults/' + vaultId)
        .then(res => {
          commit('setVault', res.data)
        })
    },

    async createVault({ commit, dispatch }, data) {
      await api.post('vaults', data)
        .then(res => {
          dispatch('getVaultsByUser');
        })
    },

    async deleteVault({ commit, dispatch }, value) {
      api.delete('vaults/' + value)
        .then(res => {
          dispatch('getVaultsByUser')
        })
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
      await api.get('keeps/user')
        .then(res => {
          commit('setMyKeeps', res.data)
        })
    },

    async createKeep({ commit, dispatch }, data) {
      await api.post('keeps', data)
        .then(res => {
          dispatch('getAllKeeps');
        })
    },
    async deleteKeep({ commit, dispatch }, value) {
      api.delete('keeps/' + value)
        .then(res => {
          dispatch('getKeepsByUser')
        })

    },
    async addToVault({ commit, dispatch }, data) {
      //need to update count of adds
      await api.post('vaultkeeps', data)
        .then(res => {
          dispatch('getAllKeeps');
        })
    },
    async getKeepsByVault({ commit, dispatch }, vaultId) {
      //update view
      await api.get('vaultkeeps/' + vaultId)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },

    async removeKeepFromVault({ commit, dispatch }, data) {

      let res = await api.put('vaultkeeps', data)
        .then(res => {
          dispatch('getKeepsByVault', data.vaultId)
        })
    }





  }
})
