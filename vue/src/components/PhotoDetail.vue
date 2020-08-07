<template>
  <modal name="detail" :adaptive="true" @before-open="beforeOpen" :reset="true" height="auto" :scrollable="true">
      <photo-container :photo="photo" />
      <section class="comments">
        <p class="comment">This is a comment</p>
        <form @submit.prevent="submitComment">
          <label for="newComment">New Comment</label>
          <input type="text" name="newComment" id="newComment ">
          <input type="submit" value="Submit">
        </form>
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
    data() {
      return {
        photo: {}
      }
    },
    methods: {
      submitComment(e) {
        console.log(e)
      },
       beforeOpen (event) {
      this.photo = event.params.photo
    }
    }
}
</script>

<style>

</style>