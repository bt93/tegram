<template>
  <modal name="deletePhoto" @before-open="beforeOpen">
      <div class="deleteAlert">
          <h2>Are you sure you would like to delete this photo?</h2>
          <button v-if="!isLoading" @click="deletePhoto">Yes</button>
          <button v-if="!isLoading" @click="$modal.hide('deletePhoto')">No</button>
          <img v-if="isLoading" class="loading-delete" src="../images/loading.gif" alt="Loading">
          <h3 v-if="deleted">Photo has been successfully deleted.</h3>
          <h3 v-else-if="fail">Photo was not successfully deleted. Please try again.</h3>
      </div>
  </modal>
</template>

<script>
import photoService from '../services/PhotoService'

export default {
    data() {
        return {
            photoId: null,
            deleted: false,
            fail: false,
            isLoading: false
        }
    },
    methods: {
        beforeOpen(e) {
            this.photoId = e.params.photoId;
        },
        deletePhoto() {
            this.isLoading = true
            photoService.deletePhoto(this.photoId)
                .then(res => {
                if (res.status === 200) {
                    this.isLoading = false;
                    this.deleted = true
                    setTimeout(() => window.location.reload(), 1500)
                }
                })
                .catch(err => {
                    this.isLoading = false;
                    this.fail = true;
                    console.log(err)
                });
        }
    }
}
</script>

<style>
.deleteAlert {
    text-align: center;
}

.loading-delete {
    width: 100px;
    margin: auto;
}
</style>