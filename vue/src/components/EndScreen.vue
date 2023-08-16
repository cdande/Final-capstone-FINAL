<template>
  <div class="button-padding">
     <router-link class="button-link" :to="{ name: 'home' }">Back</router-link>
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
</style>