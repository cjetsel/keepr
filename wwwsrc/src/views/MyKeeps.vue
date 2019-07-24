<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>
    MY KEEPS
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>

    <b-card-group columns>
      <keeps v-for="keep in myKeeps" :keep="keep" /><!-- V for keeps in keep on b-card -->
    </b-card-group>
  </div>
</template>

<script>
  import Navbar from "../components/Navbar.vue";
  import Keeps from "../components/Keeps.vue"
  export default {
    name: "MyKeeps",
    data() {
      return {
      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      myKeeps() {
        return this.$store.state.myKeeps;
      },
      keep() {
        return this.$store.state.keep;
      },
      vaults() {
        return this.$store.state.vaults;
      }
    },
    mounted() {
      this.$store.dispatch('getKeepsByUser');
      this.$store.dispatch('getVaultsByUser');


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