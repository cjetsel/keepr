<template>
  <div class="vaultkeep">
    <b-card-group columns>
      <keeps v-for="keep in vaultKeeps" :keep="keep" />
    </b-card-group>
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