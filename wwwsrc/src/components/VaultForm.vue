<template>
  <div>
    <b-form @submit="addVault">
      <b-form-group id="group-1" label="name" label-for="name">
        <b-form-input id="name" v-model="form.name" type="text" required placeholder="Enter name">
        </b-form-input>
      </b-form-group>
      <b-form-group id="group-2" label="description" label-for="description">
        <b-form-input id="name" v-model="form.description" type="text" required placeholder="Describe your luv!">
        </b-form-input>
      </b-form-group>

      <b-button type="submit">Add New Vault!</b-button>
    </b-form>
  </div>
</template>
<script>
  export default {
    name: 'VaultForm',
    data() {
      return {
        form: {
          name: '',
          description: ''


        }
      }
    },
    methods: {
      addVault() {
        let data = this.form;
        this.$store.dispatch('createVault', data);
      }
    }
  }
</script>