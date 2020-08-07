<template>
  <div id="user">
      <img src="../images/loading.gif" alt="Loading" v-if="isLoading">
      <error v-else-if="error" />
      <div v-else>
        <h3>{{user.username}}</h3>
        <img class="userImg" v-if="!user.userPhotoPath" v-bind:src="`${$store.state.cloudinaryUrl}w_400,h_400,c_crop,g_face,r_max/w_200/v1596719353/TE-Gram/kqwltepz7nzuciby6eew.png`" alt="">
        <img class="userImg" v-else :src="`${$store.state.cloudinaryUrl}w_400,h_400,c_crop,g_face,r_max/w_200${user.userPhotoPath}`" alt="">
        <p>{{this.user.bio}}</p>
        <photo-container v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
        <h1 v-if="photos.length === 0">Looks Like you don't have any photos yet!</h1>
        <photo-detail />
        <login-alert />
      </div>
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
import PhotoDetail from '../components/PhotoDetail'
import LoginAlert from '../components/LoginAlert'
import authService from '../services/AuthService'
import Error from '../components/Error'

export default {
  components: {
    PhotoContainer,
    PhotoDetail,
    LoginAlert,
    Error
  },
  data() {
    return {
      userId: this.$route.params.id,
      photos: [],
      error: false,
      isLoading: true,
      user: {
      }
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
    authService.getUserInfo(this.userId)
      .then(res => {
        if (res.status === 200) {
          this.user = res.data;
        }
      })

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
.userImg {
    width: 200px;
    margin: auto;
    border-radius: 130px;
}
</style>