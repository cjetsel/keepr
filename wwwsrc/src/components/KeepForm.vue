<template>
  <div>
    <b-form @submit="addKeep">
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
        <b-form-input id="img" v-model="form.img" type="text" placeholder="Image URL!">
        </b-form-input>
      </b-form-group>
      <!-- otherwise its a quote? some default image? haha -->
      <b-button type="submit">Add New Luv!</b-button>
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
          isPrivate: true

        }
      }
    },
    methods: {
      addKeep() {
        debugger
        let data = this.form;
        this.$store.dispatch('createKeep', data);
      }
    }
  }
</script>