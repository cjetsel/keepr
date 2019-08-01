<template>
  <div>
    <b-form @submit="addKeep">
      <b-form-row class="justify-content-center">
        <b-form-group id="group-1" label="name" label-for="name">
          <b-form-input id="name" v-model="form.name" type="text" required placeholder="Enter name">
          </b-form-input>
        </b-form-group>
        <b-form-group id="group-2" label="description" label-for="description">
          <b-form-input id="name" v-model="form.description" type="text" required placeholder="Describe your luv!">
          </b-form-input>
        </b-form-group>

        <!-- add if image -->
        <b-form-group id="group-2" label="img url" label-for="img">
          <b-form-input id="img" v-model="form.img" type="text" placeholder="Image URL">
          </b-form-input>
        </b-form-group>

      </b-form-row>
      <button type="submit" class="btn rounded-circle"> <img src="../assets/static/addluv.svg" class="button-img">
      </button>
    </b-form>
  </div>
</template>
<script>
  export default {
    name: 'KeepForm',
    data() {
      return {
        form: {
          name: '',
          description: '',
          img: '',
          isPrivate: false

        }
      }
    },
    methods: {
      addKeep() {
        let data = this.form;
        this.$store.dispatch('createKeep', data);
      }
    }
  }
</script>
<style scoped>
  .btn {
    border-radius: 50%;

  }

  .button-img {
    min-height: 40px;
    height: 6vw;
    max-height: 50px;
  }
</style>