<template>
  <div class="photoContainer">
    <header>
        <router-link v-if="$route.name === 'home'" :to="{name: 'user', params: {id: photo.userID}}"><p id="userName">{{photo.userName}}</p></router-link>
        <p v-else id="userName">{{photo.userName}}</p>
    </header>
    <section>
        <img v-bind:src="`${$store.state.cloudinaryUrl}c_scale,w_2498${photo.filePath}`" alt="" @click="show">
    </section>
    <section class="actions">
        <div v-if="photo.caption">{{ photo.caption }}</div>
        <span class="icon">
            <i  @click.stop="clickLike()" v-if="!liked" class="heart far fa-heart"></i>
            <i  @click.stop="clickLike()" v-if="liked" class="heart fas fa-heart"></i>
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
                photoService.unlikePhoto(this.photo.photoId)
                    .then(res => {
                        if (res.status === 200) {
                            this.liked = false;
                            this.photo.likeCount--;
                        }
                    })
            } else if (!this.liked && this.$store.state.token != '') {
                photoService.likePhoto(this.photo.photoId)
                    .then(res => {
                        if (res.status === 200) {
                            this.liked = true;
                            this.photo.likeCount++;
                        }
                    })
                    .catch(err => console.log(err));
            } else if (this.$store.state.token === '') {
                this.$modal.show('alert')
            }
        },
        clickFavorite() {
            if (this.favorited && this.$store.state.token != '') {
                photoService.unfavoritePhoto(this.photo.photoId)
                    .then(res => {
                        if (res.status === 200) {
                            this.favorited = false;
                        }
                    })
                    .catch(err => console.log(err));
            } else if (!this.favorited && this.$store.state.token != '') {
                this.favorited = true;
                photoService.favoritePhoto(this.photo.photoId)
                    .then(res => {
                        if (res.status === 200) {
                            this.favorited = true;
                        }
                    })
                    .catch(err => console.log(err));
            } else if (this.$store.state.token === '') {
                this.$modal.show('alert');
            }
        },
        show() {
            this.$modal.show('detail',  {photo: this.photo} )
        }
    },
    created() {
        if (this.$store.state.token !== '') {
            photoService.getLikeState(this.photo.photoId)
                .then(res => {
                    this.liked = res.data;
                });

            photoService.getPhotoFavoriteState(this.photo.photoId)
                .then(res => {
                    this.favorited = res.data;
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