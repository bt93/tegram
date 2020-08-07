<template>
  <modal name="detail" :adaptive="true" @before-open="beforeOpen" @closed="closed" :reset="true" minWidth="10000px" height="auto" :scrollable="true">
      <photo-container :photo="photo" />
        <section class="actions">
        <div v-if="photo.caption">{{ photo.caption }}</div>
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
        <p class="comment" v-for="comment in comments" :key="comment">{{comment.userName}}: {{ comment.contents }}</p>
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
import PhotoContainer from './PhotoContainer'
import photoService from '../services/PhotoService'

export default {
    name: 'photo-detail',
    components: {
       PhotoContainer
    },
    data() {
      return {
        photo: {},
        liked: false,
        favorited: false,
        comments: [],
        newComment: ''
      }
    },
    methods: {
    closed() {
      this.comments = [];
      this.newComment = '';
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
    }
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

.icon > i {
    cursor: pointer;
}

.actions,
.comments {
    padding-left: 10px;
    padding-right: 10px;
}
</style>