import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Logout from '../views/Logout.vue'
import Register from '../views/Register.vue'
import User from '../views/User'
import Settings from '../views/Settings'
import UploadPhoto from '../views/UploadPhoto'
import Favorites from '../views/Favorites'
import ChangeUserPass from '../views/ChangeUserPass'
import store from '../store/index'

Vue.use(Router)

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home,
      meta: {
        requiresAuth: false,
        title: 'Home'
      }
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false,
        title: 'Login'
      }
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false,
        title: 'Logout'
      }
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false,
        title: 'Register'
      }
    },
    {
      path: "/user/:id",
      name: "user",
      component: User,
      meta: {
        requiresAuth: false,
        title: 'User'
      }
    },
    {
      path: "/settings",
      name: "settings",
      component: Settings,
      meta: {
        requiresAuth: true,
        title: 'User Settings'
      }
    },
    {
      path: '/upload',
      name: 'upload',
      component: UploadPhoto,
      meta: {
        requiresAuth: true,
        title: 'Upload Photo'
      }
    },
    {
      path: '/favorites',
      name: 'favorites',
      component: Favorites,
      meta: {
        requiresAuth: true,
        title: 'Favorites'
      }
    },
    {
      path: '/settings/user',
      name: 'userPass',
      component: ChangeUserPass,
      meta: {
        requiresAuth: true,
        title: 'User'
      }
    }
  ]
})

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);

  if (to.meta && to.meta.title) {
    document.title = to.meta.title + ' | TEGram';
  }

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === '') {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
