<template>
  <div>

  </div>
</template>

<script>
  export default {
    name: "navbar",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    }
  };
</script>