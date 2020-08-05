<template>
  <div class="settings">
      <h1 class="title">TEGram</h1>
      <h2>Settings</h2>
      <form @submit.prevent="submitForm">
          <div>
              <label for="bio">Biography: </label>
              <textarea v-bind="bio" name="bio" id="bio" cols="30" rows="10"></textarea>
          </div>
          <div>
              <label for="pfp">Profile Picture: </label>
              <button @click="uploadPhoto">Upload A Photo</button>
              <img v-if="url" :src="`${$store.state.cloudinaryUrl}${url}`" alt="">
          </div>
          <input type="submit">
      </form>
  </div>
</template>

<script>
import authService from '../services/AuthService'

export default {
    data() {
        return {
            url: '',
            bio: ''
        }
    },
    methods: {
        submitForm() {
            authService.addUserInfo(this.bio, this.url)
                        .then(res => {
                            if (this.res) {
                                console.log(res);
                            }
                        })
        },
        uploadPhoto() {
            const myWidget = window.cloudinary.createUploadWidget({
                cloudName: 'tegram', 
                uploadPreset: 'lcj744qb'}, (error, result) => { 
                    if (!error && result && result.event === "success") { 
                    console.log('Done! Here is the image info: ', result.info);
                    this.url = result.info.path;
                    } else {
                    console.log(error);
                    }
                }
                )
            myWidget.open();
            console.log(this.$store.state.widget)
        }
    }
}
</script>

<style>
form > div {
    display: flex;
    flex-direction: column;
}
</style>