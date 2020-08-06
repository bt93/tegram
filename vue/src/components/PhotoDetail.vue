<template>
  <modal name="detail">
      <photo-container />
      <section class="comments">
        <p class="comment">This is a comment</p>
      </section>
  </modal>
</template>

<script>
import PhotoContainer from './PhotoContainer'

export default {
    name: 'photo-detail',
    components: {
      PhotoContainer
    },
    props: {
      photo: Object
    }
}
</script>

<style>

</style>