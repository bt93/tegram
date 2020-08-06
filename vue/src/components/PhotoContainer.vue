<template>
  <div class="photoContainer">
    <header>
        <router-link v-if="$route.name === 'home'" :to="{name: 'user', params: {id: photo.userID}}"><p id="userName">{{photo.userName}}</p></router-link>
        <p v-else id="userName">{{photo.userName}}</p>
    </header>
    <section>
        <img v-bind:src="`${$store.state.cloudinaryUrl}c_scale,w_2498${photo.filePath}`" alt="">
    </section>
    <section class="actions">
        <div v-if="photo.caption">{{ photo.caption }}</div>
        <span class="icon">
            <i  @click="clickLike()" v-if="!liked" class="heart far fa-heart"></i>
            <i  @click="clickLike()" v-if="liked" class="heart fas fa-heart"></i>
            {{photo.likeCount}}
        </span>
        <span class="icon">
            <i @click="clickFavorite" v-if="!favorited" class="far fa-bookmark"></i>
            <i @click="clickFavorite" v-if="favorited" class="fas fa-bookmark"></i>
        </span>
    </section>
  </div>
</template>

<script>
import photoService from '../services/PhotoService'

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
        clickLike() {
            if (this.liked && this.$store.state.token != '') {
                this.liked = false;
                photoService.unlikePhoto(this.photo.photoId)
                    .then(res => {
                        if (res.status === 200) {
                            console.log('unliked');
                            this.photo.likeCount--;
                        }
                    })
            } else if (!this.liked && this.$store.state.token != '') {
                this.liked = true;
                photoService.likePhoto(this.photo.photoId)
                    .then(res => {
                        if (res.status === 200) {
                            console.log('liked');
                            this.photo.likeCount++;
                        }
                    })
                    .catch(err => console.log(err));
            }
        },
        clickFavorite() {
            if (this.favorited && this.$store.state.token != '') {
                this.favorited = false;
            } else if (!this.favorited && this.$store.state.token != '') {
                this.favorited = true;
            }
        }
    },
    created() {
        if (this.$store.state.token !== '') {
            photoService.getLikeState(this.photo.photoId)
                .then(res => {
                    this.liked = res.data;
                });
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
}

.heart {
    color: red;
}

#userName,
.actions,
.comments {
    padding-left: 10px;
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