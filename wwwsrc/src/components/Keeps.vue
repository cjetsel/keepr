<template>
  <b-card :title="keep.name" img-src="https://placekitten.com/500/350" img-alt="Image" img-top>
    <b-card-text>
      {{keep.description}}
    </b-card-text>
    <b-card-text class="small text-muted">views: 0 loves: 0 share? details?</b-card-text>
    <b-button @click="viewKeep()">View Keep</b-button>

    <b-dropdown v-if="user">
      <template slot="button-content">
        Add to A Vault
      </template>
      <!-- <div v-if="id.boardId == boardId"> -->
      <b-dropdown-item v-for="vault in vaults" :vault="vault.id" @click="addToVault(vault.id)">
        {{vault.name}}</b-dropdown-item>
    </b-dropdown>

    <b-dropdown v-if="user">
      <template slot="button-content">
        Remove From Vault
      </template>
      <!-- <div v-if="id.boardId == boardId"> -->
      <b-dropdown-item v-for="vault in vaults" :vault="vault.id" @click="removeFromVault(vault.id)">
        {{vault.name}}</b-dropdown-item>
    </b-dropdown>




    <b-button v-if="keep.userId == user.id" @click="deleteKeep()">Delete</b-button>
  </b-card>
</template>
<script>
  export default {
    name: "keeps",
    props: ["keep"],
    data() {
      return {
        "vaultId": 0,
        "keepId": this.keep.id
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      myKeeps() {
        return this.$store.state.myKeeps;
      },
      myKeep() {
        return this.$store.state.keep;
      },
      vaults() {
        return this.$store.state.vaults;
      }

    },
    methods: {
      viewKeep() {
        this.$store.dispatch('getKeepById', this.keep.id);
        let activeKeep = this.$store.state.keep.id;
        if (activeKeep) {
          this.$router.push({
            path: `/keeps/${activeKeep}`, props: { "keepId": activeKeep }
          });
        }
        else {

        }
      },
      addToMyKeeps() {
        this.$store.dispatch('getKeepById', this.keep.id);
      },
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.keep.id);
      },
      addToVault(vault) {
        let data = {
          vaultId: vault,
          keepId: this.keep.id
        }
        this.$store.dispatch('addToVault', data)
      },
      removeFromVault(vaultId) {
        let data = {
          vaultId: vaultId,
          keepId: this.keep.id,
          userId: ''
        }
        this.$store.dispatch('removeKeepFromVault', data);
      },
    },


  }
</script>


<!-- 
prior keep saved in mykeep? y/n





 -->