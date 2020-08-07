<template>
  <div class="favorites">
      <h1>Favorites</h1>
      <photo-container v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
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