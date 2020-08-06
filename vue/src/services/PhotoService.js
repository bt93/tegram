import axios from 'axios'

export default {
    getAllPhotos() {
        return axios.get('/photo');
    },

    getPhotosByUser(userId) {
        return axios.get(`/photo/${userId}`);
    },

    getLikeState(photoId) {
        return axios.get(`/like/${photoId}`);
    },

    likePhoto(photoId) {
        return axios.put(`/like/${photoId}`);
    }
}