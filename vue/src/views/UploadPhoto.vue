<template>
  <div>
      <form @submit.prevent="submitForm">
          <label for="caption">Caption</label>
          <textarea v-model="uploadPhoto.caption" name="caption" id="caption" cols="30" rows="10"></textarea>
          <label for="pfp">Photo: </label>
          <div @click="upload" class="uploadButton">Upload A Photo</div>
          <img class="uploadedPhoto" v-if="uploadPhoto.filePath" :src="`${$store.state.cloudinaryUrl}/c_scale,w_2498/${uploadPhoto.filePath}`" alt="Uploaded Photo">
          <input type="submit">
      </form>
  </div>
</template>

<script>
import photoService from '../services/PhotoService'

export default {
    data() {
        return {
            uploadPhoto: {
                filePath: '',
                caption: '',
                userID: this.$store.state.user.userId
            }
        }
    },
    methods: {
        upload() {
            const myWidget = window.cloudinary.createUploadWidget({
                cloudName: 'tegram', 
                uploadPreset: 'lcj744qb'}, (error, result) => { 
                    if (!error && result && result.event === "success") { 
                    console.log('Done! Here is the image info: ', result.info);
                    this.uploadPhoto.filePath = '/' + result.info.path;
                    } else {
                    console.log(error);
                    }
                }
                )
            myWidget.open();
        },
        submitForm() {
            if (this.uploadPhoto.filePath === '') {
                alert('Must upload a photo first!')
            } else {
            photoService.uploadPhoto(this.uploadPhoto)
                        .then(res => {
                            if (res.status === 200) {
                                this.$router.push({name: 'home'})
                            }
                        })
                        .catch(err => {
                            console.log(err)
                            // this.errorMsg = true;
                        })
            }
        },
    }
}
</script>

<style>
form {
    display: flex;
    flex-direction: column;
}

.uploadedPhoto {
    min-width: 300px;
    max-width: 605px;
    width: 100%;
    max-height: 970px;
    margin: auto;
}

.uploadButton {
    border: 2px solid black;
    margin: 8px auto;
    padding: 20px;
    border-radius: 30px;
}

.uploadButton:hover {
    color: white;
    background-color: black;
    cursor: pointer;
}

.uploadButton:active {
    background-color: white;
}
</style>