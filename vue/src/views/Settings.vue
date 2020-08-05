<template>
  <div class="settings">
      <h1 class="title">TEGram</h1>
      <h2>Settings</h2>
      <form @submit.prevent="submitForm">
          <div>
              <label for="bio">Biography: </label>
              <textarea name="bio" id="bio" cols="30" rows="10"></textarea>
          </div>
          <div>
              <label for="pfp">Profile Picture: </label>
              <button @click="uploadPhoto">Upload A Photo</button>
          </div>
          <input type="submit">
      </form>
  </div>
</template>

<script>
export default {
    methods: {
        submitForm() {
            console.log('Click')
        },
        uploadPhoto() {
            this.$store.state.widget.open();
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