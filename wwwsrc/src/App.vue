<template>
  <b-container id="app" fluid>
    <navbar class="mb-3" />
    <router-view />

  </b-container>
</template>
<script>
  import Navbar from "./components/Navbar.vue"
  export default {
    components: {
      Navbar
    }
  }
</script>

<style>
  #app {
    font-family: 'Nunito', sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  body {
    background-color: #4dd0e142;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  .button-img {
    min-height: 30px;
    max-height: 30px;
  }
</style>