import axios from 'axios'

export default {
    getAllPhotos() {
        return axios.get('/photo');
    },

    getPhotosByUser(id) {
        return axios.get(`/photo/${id}`);
    },

    getLikeState(id) {
        return axios.get(`/like/${id}`);
    }
}