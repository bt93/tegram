<template>
  <div class="photoContainer">
    <header>
        <router-link v-if="$route.name === 'home'" :to="{name: 'user', params: {id: photo.userID}}"><p id="userName">{{photo.userName}}</p></router-link>
        <p v-else id="userName">{{photo.userName}}</p>
    </header>
    <section>
        <img v-bind:src="`${$store.state.cloudinaryUrl}c_fill,h_3000,w_3000${photo.filePath}`" :alt="photo.caption" @click="show">
        <div class="caption" v-if="photo.caption">{{ photo.caption }}</div>
    </section>
      
  </div>
</template>
<script>
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


#userName,
.caption {
    padding-left: 10px;
}

img {
    width: 100%;
    max-height: 970px;
    padding: -1
}
</style> 