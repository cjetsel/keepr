<template>
  <div class="home">
    <h1>{{user.username}}'s Loves</h1>
    <keepForm />
    <b-card-group columns>
      <keeps v-for="keep in myKeeps" :keep="keep" /><!-- V for keeps in keep on b-card -->
    </b-card-group>
  </div>
</template>

<script>
  import Navbar from "../components/Navbar.vue";
  import Keeps from "../components/Keeps.vue";
  import KeepForm from "../components/KeepForm.vue";
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
      Keeps,
      KeepForm
    }
  };
</script>