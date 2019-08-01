<template>
  <b-card :title="vault.name">
    <b-card-text>
      {{vault.description}}
    </b-card-text>
    <b-button variant="light" @click="viewVault()"><img src="../assets/static/views.svg" alt="" class="button-img"> View
      Vault
    </b-button>
    <b-button variant="light" v-if="vault.userId == user.id" @click="deleteVault()"><img
        src="../assets/static/delete.svg" alt="" class="button-img"></b-button>
  </b-card>
</template>
<script>
  export default {
    name: "vault",
    props: ["vault"],
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch('getVaultById', this.vault.id)
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vaults;
      },
      myVault() {
        return this.$store.state.vault;
      }


    },
    methods: {
      viewVault() {
        this.$store.dispatch('getKeepsByVault', this.vault.id);
        this.$router.push({
          path: `/vaults/${this.vault.id}`
        });
      },
      deleteVault() {
        this.$store.dispatch('deleteVault', this.vault.id);
      }

    },


  }
</script>


<!-- 
prior keep saved in mykeep? y/n





 -->