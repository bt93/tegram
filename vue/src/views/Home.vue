<template>
  <div class="home">
    <h1 class="title">TEGram</h1>
    <img src="../images/loading.gif" alt="" v-if="isLoading">
    <error v-else-if="error"/>
    <photo-container v-else v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
import Error from '../components/Error'

export default {
  name: "home",
  components: {
    PhotoContainer,
    Error
  },
  data() {
    return {
      photos: [],
      error: false,
      isLoading: true
    }
  },
  created() {
    photoService.getAllPhotos()
      .then(res => {
        if (res.status === 200) {
          res.data.forEach(p => this.photos.push(p));
          this.isLoading = false;
        }
      })
      .catch(err => {
        if (err) {
          // TODO: Come back to fix this
          this.isLoading = false;
          this.error = true;
        }
      })
  }
};
</script>
