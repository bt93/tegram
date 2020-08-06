<template>
  <div class="settings">
      <h1 class="title">TEGram</h1>
      <h2>Settings</h2>
      <form @submit.prevent="submitForm">
          <div>
              <error v-if="errorMsg"/>
              <label for="bio">Biography: </label>
              <textarea v-model="user.bio" name="bio" id="bio" cols="30" rows="10"></textarea>
          </div>
          <div>
              <label for="pfp">Profile Picture: </label>
              <div @click="uploadPhoto">Upload A Photo</div>
              <img class="userImg" v-if="user.url" :src="`${$store.state.cloudinaryUrl}w_400,h_400,c_crop,g_face,r_max/w_200/${user.url}`" alt="">
          </div>
          <input type="submit">
      </form>
  </div>
</template>

<script>
import authService from '../services/AuthService'
import Error from '../components/Error'

export default {
    components: {
        Error
    },
    data() {
        return {
            user: {
                url: '',
                bio: ''
            },
            errorMsg: false
        }
    },
    methods: {
        submitForm() {
            authService.addUserInfo(this.user)
                        .then(res => {
                            if (res.status === 200) {
                                this.$router.push({name: 'home'})
                            }
                        })
                        .catch(err => {
                            console.log(err)
                            this.errorMsg = true;
                        })
        },
        uploadPhoto() {
            const myWidget = window.cloudinary.createUploadWidget({
                cloudName: 'tegram', 
                uploadPreset: 'lcj744qb'}, (error, result) => { 
                    if (!error && result && result.event === "success") { 
                    console.log('Done! Here is the image info: ', result.info);
                    this.user.url = result.info.path;
                    } else {
                    console.log(error);
                    }
                }
                )
            myWidget.open();
        }
    }
}
</script>

<style>
form > div {
    display: flex;
    flex-direction: column;
}

.userImg {
    width: 200px;
    margin: auto;
    border-radius: 130px;
}
</style>