<template>
  <div>
      <form class="form">
          <div id="formtitle">
            <label for="title" > Title </label>
            <input type="text"  v-model="NewGame.title" required/>
          </div>
          <div id="duration">
            <label for="MaxDuration" > Max Duration </label>
            <select  v-model="NewGame.maxDuration" required>
              <option value="15"> 15 Min </option>
              <option value="30"> 30 Min </option>
              <option value="45"> 45 Min </option>
              <option value="60"> 60 Min </option>
             </select>
          </div>
          <!-- <div>
          <label for="numberOfPlayers" > Max Amount of players </label>
          <select  v-model="numberOfPlayers">
              <option value="2"> 2 </option>
              <option value="3"> 3  </option>
              <option value="4"> 4 </option>
              <option value="5"> 5 </option>
              <option value="6"> 6 </option>
          </select>
          </div> -->
         <button v-on:click="resetForm" type="button" id="cancel"> Cancel </button>
         <button v-on:click="createGame" type="buton" id="createGame"> Create Game </button> 
       </form>
  </div>
</template>

<script>
export default {
    data(){
        return{
           NewGame: {
        title: "",
        maxDuration:"",
         } 
    }
    },
    methods:{
        resetForm(){
            this.NewGame = {};
            this.$router.push('/');
        },
        createGame(){
            this.$store.commit('CREATE_GAME', this.NewGame);
            this.$router.push('lobby');
        }
    }

}
</script>

<style>
form{
    border: 3px solid  black;
    border-radius: 10px;
    align-items: center;
    width: 400px;
    justify-content: center;
    margin: 10px;
}
#formtitle{
    margin: 10px;
    text-align: center;
}
#duration{
    margin: 10px;
    text-align: center;
}
#cancel{
    margin: 10px;
    text-align: center;
}
#createGame{
    margin: 10px;
    text-align: center;
    align-items: center;
}
</style>