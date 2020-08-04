<template>
  <div class="photoContainer">
    <header>
        <!-- TODO Create a linke that will take you to the user page -->
        <router-link v-if="$route.name === 'home'" :to="{name: 'user', params: {id: photo.userID}}"><p id="userName">{{photo.userName}}</p></router-link>
        <p v-else id="userName">{{photo.userName}}</p>
    </header>
    <section>
        <img v-bind:src="`https://res.cloudinary.com/tegram/image/upload${photo.filePath}`" alt="">
    </section>
    <section class="actions">
        <div v-if="photo.caption">{{ photo.caption }}</div>
        <span @click="clickLike"><i class="icon far fa-heart"></i></span>
        <span @click="clickFavorite"><i class="icon far fa-bookmark"></i></span>
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
    margin: 0 15vh 20px 15vh;
    background-color: rgba(255,255,255);
    border: 1px solid rgba(219,219,219);
    text-align: left;
    min-width: 300px;
}

img {
    width: 100%;
    padding: -1
}

.icon {
   font-size: 40px;
   padding-right: 20px;
}
</style> 