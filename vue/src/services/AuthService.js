import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },

  getUserInfo(id) {
    return axios.get(`/login/info/${id}`);
  },

  addUserInfo(user) {
    return axios.put('/login/register/setup', {bio: user.bio, userPhotoPath: user.url});
  },

  changeUserPassword(user) {
    return axios.put('/login/update', {
      userId: user.userId,
      password: user.password,
      username: user.userName
    })
  }

}
