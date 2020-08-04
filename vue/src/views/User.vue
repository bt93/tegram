<template>
  <div id="user">
      <h1 class="title">TEGram</h1>
      <photo-container v-for="photo in photos" :key="photo.userId" :photo="photo"/>
      <img src="" alt="">
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
export default {
  components: {
    PhotoContainer
  },
  data() {
    return {
      userId: this.$route.params.id,
      photos: []
    }
  },
  created() {
    photoService.getPhotosByUser(this.userId)
      .then(res => {
        if (res.status === 200) {
          res.data.forEach(p => this.photos.push(p));
        }
      });
  }  
}
</script>

<style>

</style>