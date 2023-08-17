<template>
  <div class="button-padding">
     <router-link class="button-link" :to="{ name: 'home' }">Back</router-link>
     <h1 class = "text"> Congratulations! You have Completed the game. Press "Back" To go to the Home Screen"</h1>
     <h2 class = "text"> Thank you for playing STOCKOPOLY </h2>
    </div>
</template>

<script>
export default {

}
</script>

<style>
.button-link {
  text-decoration: none;
  color: #333;
  margin: 10px;
  padding: 5px 10px;
  border: 1px solid #333;
  border-radius: 4px;
  transition: background-color 0.3s, color 0.3s;
}

.button-link:hover {
  background-color:#333;
  color:white;
}
.button-padding{
  margin-top: 20px;
}
.text{
  margin: 10px;
}
</style>