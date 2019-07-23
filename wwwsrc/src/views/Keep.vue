<template>
  <div class="keep">

    <b-card-group columns>
      <keeps v-for="keep in myKeep" :keep="keep" /><!-- V for keeps in keep on b-card -->
    </b-card-group>
  </div>
</template>

<script>
  import Keeps from "../components/Keeps.vue"
  import Navbar from "../components/Navbar.vue"
  export default {
    name: "keep",
    prop: ["keepId"],
    data() {
      return {

      }
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      keeps() {
        return this.$store.state.keeps;
      },
      myKeep() {
        return this.$store.state.keep;
      }
      // keep() {
      //   return this.$store.state.keep;
      // }
    },
    mounted() {
      this.$store.dispatch('getAllKeeps');
      this.$store.dispatch('getKeepById');
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