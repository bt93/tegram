<template>
  <div class="photoContainer">
    <header>
        <router-link v-if="$route.name === 'home'" :to="{name: 'user', params: {id: photo.userID}}"><p id="userName">{{photo.userName}}</p></router-link>
        <p v-else id="userName">{{photo.userName}}</p>
    </header>
    <section>
        <img v-bind:src="`${$store.state.cloudinaryUrl}c_scale,w_2498${photo.filePath}`" alt="" @click="show">
    </section>
      
  </div>
</template>
<script>
// import photoService from '../services/PhotoService'

export default {
    name: 'photo-container',
    data() {
        return {
            liked: false,
            favorited: false,
        }
    },
    props: {
        photo: Object
    },
    methods: {
        show() {
            this.$modal.show('detail',  {
                photo: this.photo,
                liked: this.liked,
                favorited: this.favorited,
                clickFavorite: this.clickFavorite,
                clickLike: this.clickLike
                })
        }
    }
}
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

#userName {
    padding-left: 10px;
}

img {
    width: 100%;
    max-height: 970px;
    padding: -1
}
</style> 