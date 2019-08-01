<template>
  <div class="keep">
    <b-card-group columns>
      <keeps :keep="myKeep" />
    </b-card-group>
  </div>
</template>

<script>
  import Keeps from "../components/Keeps.vue"
  import Navbar from "../components/Navbar.vue"
  export default {
    name: "keep",
    props: ["keepId"],
    mounted() {
      return this.$store.dispatch('getAllKeeps');
      // this.$store.dispatch('upViewCount'); -- this will up count on page load?

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
      },
      myKeeps() {
        return this.$store.state.keep
      }

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