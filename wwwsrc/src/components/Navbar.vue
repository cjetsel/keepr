<template>
  <div>
    <div>
      <b-navbar toggleable="lg" type="dark" variant="info">
        <b-img :src="images.logo"></b-img>
        <b-navbar-brand href="#">NavBar</b-navbar-brand>

        <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

        <!-- Right aligned nav items -->
        <b-navbar-nav class="ml-auto">
          <!-- <b-nav-form>
            <b-form-input size="sm" class="mr-sm-2" placeholder="Search"></b-form-input>
            <b-button size="sm" class="my-2 my-sm-0" type="submit">Search</b-button>
          </b-nav-form> -->

          <b-nav-item-dropdown text="Lang" right>
            <b-dropdown-item href="#">EN</b-dropdown-item>
            <b-dropdown-item href="#">ES</b-dropdown-item>
            <b-dropdown-item href="#">RU</b-dropdown-item>
            <b-dropdown-item href="#">FA</b-dropdown-item>
          </b-nav-item-dropdown>

          <b-nav-item-dropdown right v-if="user.id">
            <!-- Using 'button-content' slot -->
            <template slot="button-content"><em>User</em></template>
            <b-dropdown-item @click="viewMyKeeps">My Keeps</b-dropdown-item>
            <b-dropdown-item @click="viewMyVaults">My Vaults</b-dropdown-item>
            <b-dropdown-item @click="logout">Sign Out</b-dropdown-item>
            <button v-if="user.id" @click="logout">logout</button>
            <router-link v-else :to="{name: 'login'}">Login</router-link>
          </b-nav-item-dropdown>
          <b-nav-item-dropdown right v-else>
            <!-- Using 'button-content' slot -->
            <template slot="button-content"><em>User</em></template>
            <b-dropdown-item href=@click="Home">Keeps</b-dropdown-item>
            <b-dropdown-item href="#">Create Account</b-dropdown-item>
            <b-dropdown-item href="{name: 'login'}">Sign In</b-dropdown-item>



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
        return this.$store.state.user;
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
      }
    },

  };
</script>