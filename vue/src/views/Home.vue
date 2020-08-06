<template>
  <div class="home">
    <div class="header">
      <span @click="show"><img src="..\images\TEGram_Smaller_Rounded.png" class="small-logo" alt=""></span><h1 class="title">TEGram</h1>
    </div>
    <img src="../images/loading.gif" alt="TEGram" v-if="isLoading">
    <error v-else-if="error"/>
    <photo-container v-else v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
    <photo-detail />
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
import Error from '../components/Error'
import PhotoDetail from '../components/PhotoDetail'

export default {
  name: "home",
  components: {
    PhotoContainer,
    PhotoDetail,
    Error
  },
  data() {
    return {
      photos: [],
      error: false,
      isLoading: true
    }
  },
  methods: {
    show() {
      this.$modal.show('detail')
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
