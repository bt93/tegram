<template>
  <div class="home">
    <img src="../images/loading.gif" alt="TEGram" v-if="isLoading">
    <error v-else-if="error"/>
    <div v-else class="photolist">
      <photo-container v-for="photo in photos" :key="photo.photoId" :photo="photo"/>
      <div class="buttons">
        <button :disabled="pageNum === 1" @click="prevPage">Previous</button> | 
        <button :disabled="pageNum >= totalPages" @click="nextPage">Next</button>
      </div>
    </div>
    <photo-detail />
    <login-alert />
    <delete-modal />
  </div>
</template>

<script>
import PhotoContainer from '../components/PhotoContainer'
import photoService from '../services/PhotoService'
import Error from '../components/Error'
import PhotoDetail from '../components/PhotoDetail'
import LoginAlert from '../components/LoginAlert'
import DeleteModal from '../components/DeleteModal'

export default {
  name: "home",
  components: {
    PhotoContainer,
    PhotoDetail,
    LoginAlert,
    DeleteModal,
    Error
  },
  data() {
    return {
      photos: [],
      error: false,
      isLoading: true,
      pageNum: 1,
      totalPages: 0
    }
  },
  methods: {
    prevPage() {
      this.photos = [];
      this.pageNum--;
      photoService.getPartitionedPhotos(this.pageNum)
      .then(res => {
        if (res.status === 200) {
          res.data.forEach(p => this.photos.push(p));
          this.isLoading = false;
        }
      })
      .catch(err => {
        if (err) {
          this.isLoading = false;
          this.error = true;
        }
      })
    },
    nextPage() {
      this.photos = [];
      this.pageNum++;
      photoService.getPartitionedPhotos(this.pageNum)
      .then(res => {
        if (res.status === 200) {
          res.data.forEach(p => this.photos.push(p));
          this.isLoading = false;
        }
      })
      .catch(err => {
        if (err) {
          this.isLoading = false;
          this.error = true;
        }
      })
    }
  },
  created() {
    photoService.getAllPhotos()
      .then(res => this.totalPages = res.data.length / 5)

    photoService.getPartitionedPhotos(this.pageNum)
      .then(res => {
        if (res.status === 200) {
          res.data.forEach(p => this.photos.push(p));
          this.isLoading = false;
        }
      })
      .catch(err => {
        if (err) {
          this.isLoading = false;
          this.error = true;
        }
      })
  }
};
</script>
<style scoped>
.photoContainer {
    margin: 0 auto 20px auto;
    background-color: rgba(255,255,255);
    border: 1px solid rgba(219,219,219);
    text-align: left;
    min-width: 300px;
    max-width: 605px;
    border-radius: 15px;
    padding-bottom: 20px;
}

.photolist {
  margin-bottom: 65px
}

.buttons > button {
  z-index: 100;
  cursor: pointer;
}
</style>