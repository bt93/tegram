<template>
  <div id="user">
      <h1 class="title">TEGram</h1>
      <img src="../images/loading.gif" alt="Loading" v-if="isLoading">
      <error v-else-if="error" />
      <div v-else>
        <h1 v-if="photos.length === 0">Looks Like you don't have any photos yet!</h1>
        <h3>{{photos[0].userName}}</h3>
        <img v-bind:src="`${$store.state.cloudinaryUrl}w_400,h_400,c_crop,g_face,r_max/w_200/v1596719353/TE-Gram/kqwltepz7nzuciby6eew.png`" alt="">
        <photo-container v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
      </div>
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
          if (res.data.length === 0) {
            this.error = true
          } else {
            res.data.forEach(p => this.photos.push(p));
          }
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
          if (res.data.length === 0) {
            this.error = true
          } else {
            res.data.forEach(p => this.photos.push(p));
          }
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