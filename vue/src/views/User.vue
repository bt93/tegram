<template>
  <div id="user">
      <img src="../images/loading.gif" alt="Loading" v-if="isLoading">
      <error v-else-if="error" />
      <div v-else>
        <h3>{{user.username}}</h3>
        <div class="userInfo">
          <img class="pfp" v-if="!user.userPhotoPath" v-bind:src="`${$store.state.cloudinaryUrl}w_400,h_400,c_crop,g_face,r_max/w_200/v1596719353/TE-Gram/kqwltepz7nzuciby6eew.png`" alt="">
          <img class="pfp" v-else :src="`${$store.state.cloudinaryUrl}w_400,h_400,c_crop,g_face,r_max/w_200${user.userPhotoPath}`" alt="">
          <div>
            <p>Bio: {{this.user.bio}}</p>
            <p>Posts: {{ photos.length }}</p>
          </div>
        </div>
        <div class="userPhotos">
          <photo-container class="flex-photo" v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
        </div>
        <h1 v-if="photos.length === 0">Looks Like this user doesn't have any photos yet!</h1>
        <photo-detail />
        <login-alert />
        <delete-modal />
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
import DeleteModal from '../components/DeleteModal'

export default {
  components: {
    PhotoContainer,
    PhotoDetail,
    LoginAlert,
    Error,
    DeleteModal
  },
  data() {
    return {
      userId: this.$route.params.id,
      photos: [],
      error: false,
      isLoading: true,
      user: {}
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
.userPhotos {
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
}

.photoContainer {
    margin: 0 auto 20px auto;
    background-color: rgba(255,255,255);
    border: 1px solid rgba(219,219,219);
    text-align: left;
    max-width: 245px;
    border-radius: 15px;
    padding-bottom: 20px;
}

.pfp {
    width: 200px;
    margin: 20px;
    border-radius: 130px;
}

.userInfo {
  display: flex;
  flex-direction: row;
  justify-content: center;
}

.userInfo div {
  margin-top: 50px;
  font-size: 20px;
}

@media screen and (max-width: 1425px) {
  .photoContainer {
    max-width: 300px;
  }
}

@media screen and (max-width: 1145px) {
  .photoContainer {
    min-width: 300px;
    max-width: 100px;
  }
}

@media screen and (max-width: 925px) {
  .photoContainer {
    max-width: 60px;
  }
}
</style>