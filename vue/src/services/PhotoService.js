import axios from 'axios'

export default {
    getAllPhotos() {
        return axios.get('/photo');
    },

    getPhotosByUser(userId) {
        return axios.get(`/photo/${userId}`);
    },

    getDetailPhoto(photoId) {
        return axios.get(`/photo/detail/${photoId}`);
    },

    addComment(comment) {
        return axios.post('/comment', {
            photoId: comment.photoId,
            contents: comment.contents
        })
    },

    getLikeState(photoId) {
        return axios.get(`/like/${photoId}`);
    },

    favoritePhoto(photoId) {
        return axios.post(`/favorite/${photoId}`);
    },

    unfavoritePhoto(photoId) {
        return axios.delete(`/favorite/${photoId}`);
    },

    getPhotoFavoriteState(photoId) {
        return axios.get(`/favorite/${photoId}`);
    },

    getAuthenticatedUserFavoritePhotos() {
        return axios.get('/favorite/myfavorites');
    },

    uploadPhoto(photo) {
        return axios.post(`/photo/upload`, {
            filePath: photo.filePath,
            caption: photo.caption,
            userID: photo.userID
        });
    },

    likePhoto(photoId) {
        return axios.put(`/like/${photoId}`);
    },

    unlikePhoto(photoId) {
        return axios.delete(`/like/${photoId}`);
    },

    deletePhoto(photoId) {
        return axios.delete(`/photo/${photoId}`);
    }
}