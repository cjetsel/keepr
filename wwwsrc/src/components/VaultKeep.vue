<template>
  <b-card :title="keep.name" :img-src="keep.img" img-alt="Image" img-top>
    <b-card-text>
      {{keep.description}}
    </b-card-text>
    <b-card-text class="small text-muted">
      <div class="row justify-content-center">
        <div class="col-2">
          <div class="row justify-content-center"><img src="../assets/static/views.svg" class="button-img"></div>
          <div class="row justify-content-center">{{keep.views}}</div>
        </div>
        <div class="col-2">
          <div class="row justify-content-center"><img src="../assets/static/luvs.svg" class="button-img"></div>
          <div class="row justify-content-center">{{keep.keeps}}</div>
        </div>
        <div class="col-2">
          <div class="row justify-content-center"><img src="../assets/static/shares.svg" class="button-img"></div>
          <div class="row justify-content-center">{{keep.shares}}</div>
        </div>
      </div>
    </b-card-text>
    <b-button @click="viewKeep()"><img src="../assets/static/views.svg" class="button-img"> View</b-button>
    <b-dropdown v-if="user">
      <template slot="button-content">
        <img src="../assets/static/removekeep.svg" class="button-img"> Remove From Vault
      </template>
      <!-- <div v-if="id.boardId == boardId"> -->
      <b-dropdown-item v-for="vault in vaults" :vault="vault.id" @click="removeFromVault(vault.id)">
        {{vault.name}}</b-dropdown-item>
    </b-dropdown>
    <b-button v-if="keep.userId == user.id" @click="deleteKeep()"> <img src="../assets/static/delete.svg"
        class="button-img">Delete</b-button>
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
        let data = {
          views: this.keep.views++,
          id: this.keep.id
        }
        this.$store.dispatch('updateViews', data)
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
        let keepData = {
          id: this.keep.id,
          keeps: this.keep.keeps++
        }
        this.$store.dispatch('updateKeeps', keepData)

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
<style>
  .button-img {
    min-height: 30px;
    max-height: 30px;
  }
</style>

<!-- 
prior keep saved in mykeep? y/n





 -->