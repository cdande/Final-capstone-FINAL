<template>
   <div>
    <GameBoard :selectedPlayerCount="selectedPlayerCount" :selectedCharacters="selectedCharacters" :characters="characters" :currentGame="currentGame" :players="players" />
  </div>
</template>

<script>
import GameBoard from '../components/GameBoard.vue'
export default {
  components: { GameBoard },

 props: {
    selectedPlayerCount: Number,
    selectedCharacters: Array,
    characters: Array,
    currentGame: Object,
    players: Array,
  },
  
};
</script>

<style>

</style>