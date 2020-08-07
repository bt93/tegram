<template>
  <modal name="detail" :adaptive="true">
      <!-- <photo-container /> -->
      <section class="comments">
        <p class="comment">{{photo}}</p>
      </section>
  </modal>
</template>

<script>
// import PhotoContainer from './PhotoContainer'

export default {
    name: 'photo-detail',
    components: {
      // PhotoContainer
    },
    props: {
      photo: Number
    }
}
</script>

<style>

</style>