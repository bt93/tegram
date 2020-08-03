<template>
  <div class="home">
    <h1 class="title">TEGram</h1>
    <photo-container v-for="photo in photos" :key="photo" :photo="photo"/>
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'

export default {
  name: "home",
  components: {
    PhotoContainer
  },
  data() {
    return {
      photos: []
    }
  },
  created() {
    photoService.getAllPhotos()
      .then(res => {
        if (res.status === 200) {
          res.data.forEach(p => this.photos.push(p));
        }
      })
      .catch(err => {
        if (err.status === 400) {
          // TODO: Come back to fix this
          console.log("something went wrong")
        }
      })
  }
};
</script>
