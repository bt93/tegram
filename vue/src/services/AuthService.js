import axios from 'axios';

export default {

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },

  addUserInfo(bio, photo) {
    return axios.put('/login/register/setup', {bio: bio, photo: photo});
  }

}
