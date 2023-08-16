<template>
  <div id="app">
    <div id="nav">
      <div id="navText">
        <router-link class="nav-link" v-bind:to="{ name: 'home' }">Home</router-link>
        <router-link class="nav-link" v-bind:to="{ name: 'logout' }" v-if="$store.state.token !== ''">Logout</router-link>
        <router-link class="nav-link" v-bind:to="{ name: 'login' }">Sign In</router-link>
      </div>
    </div>
    <router-view />
  </div>
</template>

<style>
#nav {
  background-color: #333;
  color: white;
  padding: 10px;
}

.nav-link {
  text-decoration: none;
  color: white;
  margin-right: 10px;
  padding: 5px 10px;
  border: 1px solid white;
  border-radius: 4px;
  transition: background-color 0.3s, color 0.3s;
}

.nav-link:hover {
  background-color: white;
  color: #333;
}
</style>