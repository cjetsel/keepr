<template>
  <div class="vaultkeep">
    <b-card-group columns v-if="vaultKeeps[0]">
      <keeps v-for="keep in vaultKeeps" :keep="keep" />
    </b-card-group>
    <div v-else>
      <img class="default m-5" src="../assets/static/default.svg" alt="">
      <h5><em>Looks like there's nothing here....</em></h5>
    </div>
  </div>
</template>

<script>
  import Keeps from "../components/Keeps.vue"
  import Navbar from "../components/Navbar.vue"
  export default {
    name: "VaultKeep",
    data() {
      return {

      }
    },
    mounted() {
      return this.$store.dispatch('getVaultsByUser');
      return this.$store.dispatch('getKeepsByUser');
      // this.$store.dispatch('upViewCount'); -- this will up count on page load?

    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      myVault() {
        return this.$store.state.vault;
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps;
      }

    },

    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    },
    components: {
      Navbar,
      Keeps
    }
  };
</script>
<style>
  .default {
    height: 10vw;
    min-height: 100px;
    max-height: 300px;
  }
</style>