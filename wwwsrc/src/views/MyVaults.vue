<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>

    MY VAULTS
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <vaultForm />
    <b-card-group columns>
      <vault v-for="vault in vaults" :vault="vault" /><!-- V for keeps in keep on b-card -->
    </b-card-group>
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