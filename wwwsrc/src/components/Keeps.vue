<template>
  <b-card title="Title" img-src="https://placekitten.com/500/350" img-alt="Image" img-top>
    <b-card-text>
      views: 0 loves: 0 share? details?
    </b-card-text>
    <b-card-text class="small text-muted">Last updated 3 mins ago</b-card-text>
    <b-button @click="viewKeep()">Redirect to Keep by Id</b-button>
  </b-card>
</template>
<script>
  export default {
    name: "Keeps",
    props: ["keep"],
    data() {
      return {

      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps;
      },
      myKeep() {
        return this.$store.state.keep;
      }

    },
    methods: {
      viewKeep() {
        let keepId = this.keep.id;
        this.$store.dispatch('getKeepById', keepId);
        this.$router.push({ name: "keep", params: { keepId: keepId } });
      }
    },


  }
</script>


<!-- 
prior keep saved in mykeep? y/n





 -->