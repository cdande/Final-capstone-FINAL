<template>
  <div id="app">
    <div id="nav">
      <div id='logo'>
        <router-link v-bind:to="{ name: 'home' }"> <img class='logo' src="https://cdn.aarp.net/content/dam/aarp/money/investing/2020/01/1140-bull-and-bear-illustration-with-stock-chart.imgcache.rev.web.700.403.jpg"/> </router-link>&nbsp;
      </div>
      <div id='navText'>
       <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      <router-link v-bind:to="{ name: 'login' }">Sign In</router-link>
      </div>
     
    </div>
    <router-view />
  </div>
</template>
