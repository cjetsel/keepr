<template>
  <div class="home">
    <h4 class="mb-3">Keep the luvs you want together here! Create a vault and add your luvs to it.</h4>
    <vaultForm class="mb-3" />
    <b-card-group column v-if="vaults[0]">
      <vault v-for="vault in vaults" :vault="vault" /><!-- V for keeps in keep on b-card -->
    </b-card-group>
    <div v-else>
      <img class="default m-5" src="../assets/static/default.svg" alt="">
      <h5><em>Looks like you need to add some vaults!</em></h5>
    </div>
  </div>
</template>

<script>
  import Navbar from "../components/Navbar.vue";
  import Vault from "../components/Vault.vue"
  import VaultForm from "../components/VaultForm.vue"
  export default {
    name: "MyVaults",
    data() {
      return {
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vaults;
      }
    },
    mounted() {
      this.$store.dispatch('getVaultsByUser');
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    },
    components: {
      Navbar,
      Vault,
      VaultForm
    }
  };
</script>