<template>
  <div id="app">
    <div id="nav">
     
      <div id='navText'>
       <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      <router-link v-bind:to="{ name: 'login' }">Sign In</router-link>
      </div>
     
    </div>
    <router-view />
  </div>
</template>
