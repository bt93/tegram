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
    }
}