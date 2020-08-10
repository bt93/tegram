<template>
  <modal name="detail" :adaptive="true" @before-open="beforeOpen" @closed="closed" :reset="true" height="auto" :scrollable="true">
      <section v-if="$store.state.token != ''" class="delete">
        <p v-if="photo.userID === $store.state.user.userId" @click="deletePhoto">❌ Delete</p>
      </section>
      <section>
        <img src="../images/loading.gif" alt="Loading" v-if="isLoading" class="loading">
        <img v-bind:src="`${$store.state.cloudinaryUrl}c_fit,w_600${photo.filePath}`" alt="{ photo.userName }" @load="onImgLoad">
      </section>
        <div class="caption" v-if="photo.caption">{{ photo.userName }} - {{ photo.caption }}</div>
        <section class="actions">
        <span class="icon">
            <i @click.stop="clickLike()" v-if="!liked" class="heart far fa-heart"></i>
            <i @click.stop="clickLike()" v-if="liked" class="heart fas fa-heart"></i>
            {{photo.likeCount}}
        </span>
        <span class="icon">
            <i @click="clickFavorite" v-if="!favorited" class="far fa-bookmark"></i>
            <i @click="clickFavorite" v-if="favorited" class="fas fa-bookmark"></i>
        </span>
        <section class="comments">
        <p class="comment" v-for="(comment ,i) in comments" :key="i"><router-link :to="{name :'user', params: {id: comment.userId}}">{{comment.userName}}</router-link>: {{ comment.contents }}</p>
        </section>
        <section> 
          <form @submit.prevent="submitComment">
            <label for="newComment">New Comment</label>
            <input type="text" name="newComment" id="newComment" v-model="newComment">
            <input type="submit" value="Submit">
          </form>
        </section>
        </section>
  </modal>
</template>

<script>
// import PhotoContainer from './PhotoContainer'
import photoService from '../services/PhotoService'

export default {
    name: 'photo-detail',
    components: {
      //  PhotoContainer
    },
    data() {
      return {
        photo: {},
        liked: false,
        favorited: false,
        comments: [],
        newComment: '',
        isLoading: true
      }
    },
    methods: {
    closed() {
      this.comments = [];
      this.newComment = '';
      this.isLoading = true;
    },
    onImgLoad() {
      this.isLoading = false;
    },
    deletePhoto() {
      photoService.deletePhoto(this.photo.photoId)
        .then(res => {
          if (res === 200) {
            this.$router.push('/')
          }
        })
        .catch(err => {
          console.log(err);
        });
    },
    submitComment() {
      if (this.$store.state.token === '') {
        this.$modal.show('alert');
      } else {
        let comment = {
          photoId: this.photo.photoId,
          contents: this.newComment,
          userName: this.$store.state.user.username
        }
        photoService.addComment(comment)
          .then(res => {
            if (res.status === 200) {
              this.comments.push(comment)
              this.newComment = '';
            }
          })
          .catch(err => {
            console.log(err);
          })
        }
      },
      beforeOpen (event) {
      this.photo = event.params.photo
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

        photoService.getDetailPhoto(this.photo.photoId) 
            .then(res => {
              res.data.comments.forEach(c => this.comments.push(c));
            })
      },
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
    },
}
</script>

<style>
.icon {
   font-size: 40px;
   padding-right: 20px;
}

.heart {
    color: red;
}

.icon > i,
.delete {
    cursor: pointer;
}

.delete {
  text-align: center;
}

.actions,
.comments {
    padding-left: 10px;
    padding-right: 10px;
}

.loading {
    padding: 26%;
}
</style>