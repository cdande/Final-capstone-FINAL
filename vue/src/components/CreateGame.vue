<template>
  <div>
      <form class="form">
          <div>
          <label for="title" > Title </label>
          <input type="text" v-model="title"/>
          </div>
          <div>
          <label for="MaxDuration" > Max Duration </label>
          <select  v-model="maxDuration">
              <option value="15"> 15 Min </option>
              <option value="30"> 30 Min </option>
              <option value="45"> 45 Min </option>
              <option value="60"> 60 Min </option>
          </select>
          </div>
          <div>
          <label for="numberOfPlayers" > How Many Players Total? </label>
          <select  v-model="numberOfPlayers">
              <option value="2"> 2 </option>
              <option value="3"> 3  </option>
              <option value="4"> 4 </option>
              <option value="5"> 5 </option>
              <option value="6"> 6 </option>
          </select>
          </div>
          <button v-on:submit.prevent=""> </button>
          <button> </button>
       </form>
  </div>
</template>

<script>
export default {
    NewGame: {
        title: "",
        maxDuration:"",
        numberOfPlayers:""

    }

}
</script>

<style>

</style>