<template>
  <div class="favorites">
      <h1>Favorites</h1>
      <photo-container v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
      <div v-if="photos.length === 0">
            <h1>Looks Like you don't have any favorites yet!</h1>
            <h2>Click on the <i class="far fa-bookmark" aria-label="Favorites"></i> Icon to add a photo to your favorites.</h2>
      </div>
      <photo-detail />
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
import PhotoDetail from '../components/PhotoDetail'

export default {
    name: 'favorites',
    components: {
        PhotoContainer,
        PhotoDetail
    },
    data() {
        return {
            photos: []
        }
    },
    created() {
        photoService.getAuthenticatedUserFavoritePhotos()
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