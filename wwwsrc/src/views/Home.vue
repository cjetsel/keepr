<template>
  <div class="home">
    <h1 v-if="user" class="mb-3">Hello {{user.username}}!</h1>
    <h4 class="mb-3">Welcome to Lovr, a simple way to keep all your favorite things in one place!</h4>
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