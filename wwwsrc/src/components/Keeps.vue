<template>
  <div>
    <b-card-group columns>
      <!-- <b-card header="Quote">
        <blockquote class="blockquote mb-0">
          <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer posuere erat a ante.</p>
          <footer class="blockquote-footer">
            Someone famous in <cite title="Source Title">Source Title</cite>
          </footer>
        </blockquote>
      </b-card> -->

      <!-- V for keeps in keep on b-card -->

      <b-card title="Title" img-src="https://placekitten.com/500/350" img-alt="Image" img-top>
        <b-card-text>
          views: 0 loves: 0 share? details?
        </b-card-text>
        <b-card-text class="small text-muted">Last updated 3 mins ago</b-card-text>
        <b-button variant="outline-info">Redirect to Keep by Id</b-button>
      </b-card>

    </b-card-group>
  </div>
</template>
<script>
  export default {
    name: "Keeps",

  }
</script>