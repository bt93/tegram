<template>
  <div id="user">
      <h1 class="title">TEGram</h1>
      <img src="../images/loading.gif" alt="Loading" v-if="isLoading">
      <error v-else-if="error"/>
      <photo-container v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
import Error from '../components/Error'

export default {
  components: {
    PhotoContainer,
    Error
  },
  data() {
    return {
      userId: this.$route.params.id,
      photos: [],
      error: false,
      isLoading: true
    }
  },
  watch: {
    '$route.params.id': function(userId) {
      this.photos = [];
      photoService.getPhotosByUser(userId)
      .then(res => {
        if (res.status === 200) {
          this.isLoading = false;
          res.data.forEach(p => this.photos.push(p));
        }
      }).catch(err => {
        if (err) {
          this.isLoading = false;
          this.error = true;
        }
      });
    }
  },
  created() {
    photoService.getPhotosByUser(this.userId)
      .then(res => {
        if (res.status === 200) {
          this.isLoading = false;
          res.data.forEach(p => this.photos.push(p));
        }
      })
      .catch(err => {
        if (err) {
          this.isLoading = false;
          this.error = true;
        }
      });
  }  
}
</script>

<style>

</style>