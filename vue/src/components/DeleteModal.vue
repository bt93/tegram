<template>
  <modal name="deletePhoto" @before-open="beforeOpen">
      <div class="deleteAlert">
          <h2>Are you sure you would like to delete this photo?</h2>
          <button @click="deletePhoto">Yes</button>
          <button @click="$modal.hide('deletePhoto')">No</button>
      </div>
  </modal>
</template>

<script>
import photoService from '../services/PhotoService'

export default {
    data() {
        return {
            photoId: null,
            deleted: true
        }
    },
    methods: {
        beforeOpen(e) {
            this.photoId = e.params.photoId;
        },
        deletePhoto() {
            photoService.deletePhoto(this.photoId)
                .then(res => {
                if (res.status === 200) {
                    window.location.reload()
                }
                })
                .catch(err => {
                    console.log(err);
                });
        }
    }
}
</script>

<style>
.deleteAlert {
    text-align: center;
}
</style>