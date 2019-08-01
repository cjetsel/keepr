<template>
  <div>
    <div>
      <b-navbar type="dark" variant="info" class="mb-3">

        <b-navbar-brand href="{name: home}"><img src="../assets/static/home.svg" alt="" class="home"></b-navbar-brand>
        <b-nav-text class="brand align-items-center">Lovr</b-nav-text>
        <b-navbar-nav class="ml-auto">
          <b-nav-item-dropdown right v-if="user.id">
            <!-- Using 'button-content' slot -->
            <template slot="button-content"><img src="../assets/static/user.svg" class="user"></template>
            <b-dropdown-item @click="viewMyKeeps">My Luvs</b-dropdown-item>
            <b-dropdown-item @click="viewMyVaults">My Vaults</b-dropdown-item>
            <b-dropdown-item v-if="user.id" @click="logout">Sign Out</b-dropdown-item>
          </b-nav-item-dropdown>
          <b-nav-item-dropdown right v-else>
            <!-- Using 'button-content' slot -->
            <template slot="button-content"><img src="../assets/static/user.svg" class="user"></template>
            <b-dropdown-item @click="signIn">Sign In</b-dropdown-item>



          </b-nav-item-dropdown>
        </b-navbar-nav>
        </b-collapse>
      </b-navbar>
    </div>
  </div>
</template>

<script>
  export default {
    name: "navbar",
    data() {
      return {
        images: {
          sample: require('../assets/static/logo.svg')
        }
      }
    },
    computed: {
      user() {
        if (this.$store.state.user) {
          return this.$store.state.user;
        }
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      viewMyKeeps() {
        this.$store.dispatch("getKeepsByUser");
        this.$router.push({ name: "myKeeps" })
      },
      viewMyVaults() {
        this.$store.dispatch("getVaultsByUser");
        this.$router.push({ name: "myVaults" })
      },
      signIn() {
        this.$router.push({ name: "login" })
      }

    },

  };
</script>
<style>
  .brand {
    font-family: 'Pacifico', cursive;
    color: #fff !important;
    font-size: 3vh;
    max-height: 56px;
  }

  .home {
    height: 5vw;
    min-height: 41px;
    max-height: 56px;
  }

  .user {
    height: 3vw;
    min-height: 32px;
    max-height: 40px;
  }
</style>