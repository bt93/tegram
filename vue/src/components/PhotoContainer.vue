<template>
  <div class="photoContainer">
    <header>
        <router-link v-if="$route.name === 'home'" :to="{name: 'user', params: {id: photo.userID}}"><p id="userName">{{photo.userName}}</p></router-link>
        <p v-else id="userName">{{photo.userName}}</p>
    </header>
    <section>
        <img v-bind:src="`${$store.state.cloudinaryUrl}${photo.filePath}`" alt="">
    </section>
    <section class="actions">
        <div v-if="photo.caption">{{ photo.caption }}</div>
        <span class="icon">
            <i  @click="clickLike" class="far fa-heart"></i>
            {{photo.likeCount}}
        </span>
        <span class="icon"><i @click="clickFavorite" class="far fa-bookmark"></i></span>
    </section>
    <section class="comments">
        <div>
            <p class="comment"> {UserName}
                <span>What a good boy!</span></p>
        </div>
    </section>
  </div>
</template>

<script>
export default {
    name: 'photo-container',
    props: {
        photo: Object
    },
    methods: {
        clickLike(e) {
            console.log(e);
        },
        clickFavorite(e) {
            console.log(e);
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
    max-width: 600px;
    border-radius: 15px;
}

img {
    width: 100%;
    max-height: 970px;
    padding: -1
}

.icon {
   font-size: 40px;
   padding-right: 20px;
}

.icon > i {
    cursor: pointer;
}
</style> 