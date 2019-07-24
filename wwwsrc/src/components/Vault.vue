<template>
  <b-card :title="vault.name" img-src="https://placekitten.com/500/350" img-alt="Image" img-top>
    <b-card-text>
      {{vault.description}}
    </b-card-text>
    <b-card-text class="small text-muted">Last updated 3 mins ago</b-card-text>
    <b-button @click="viewVault()">View Vault</b-button>
    <b-button v-if="vault.userId == user.id" @click="deleteVault()">Delete Vault</b-button>

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