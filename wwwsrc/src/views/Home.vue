<template>
  <div class="home">
    <h1 v-if="user">Welcome Home {{user.username}}</h1>
    <b-card-group columns>
      <keeps v-for="keep in keeps" :keep="keep" /><!-- V for keeps in keep on b-card -->
    </b-card-group>
  </div>
</template>

<script>
  import Navbar from "../components/Navbar.vue";
  import Keeps from "../components/Keeps.vue"
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      keep() {
        return this.$store.state.keep;
      }
    },
    mounted() {
      this.$store.dispatch('getAllKeeps');
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