<template>
  <div>
    <Lobby @start-game="addPlayersToGame" />
   <GameBoard
    :selectedPlayerCount="selectedPlayerCount"
  :selectedCharacters="selectedCharacters"
  :characters="characters"
  :currentGame="currentGame"
  :players="players"
/>
  </div>
</template>

<script>
import Lobby from './Lobby.vue';
import GameBoard from '../views/GameBoard.vue';
export default {
  components: {
    Lobby,
    GameBoard,

  },
   computed: {
    selectedPlayerCount() {
      return this.$store.state.selectedPlayerCount;
    },
    selectedCharacters() {
      return this.$store.state.selectedCharacters;
    },
    characters() {
      return this.$store.state.characters;
    },
    currentGame() {
      return this.$store.state.currentGame;
    },
    players() {
      return this.$store.state.players;
    }
  },
  methods: {
    addPlayersToGame(selectedPlayerCount) {
      // Clear existing players if needed
      this.$store.commit('CLEAR_PLAYERS'); // Define CLEAR_PLAYERS mutation in your store
       this.$router.push({
      name: 'gameboard',
      params: { selectedPlayerCount }, // Pass the prop as a parameter
    });

      // Add selected number of players to the game
      for (let i = 0; i < selectedPlayerCount; i++) {
        const player = {
          id: i + 1,
          name: `Player ${i + 1}`,
          position: 0,
          money: 1000000,
          stocksOwned: [],
        };
        this.ADD_PLAYER(player);
      }
this.$store.commit('SET_SELECTED_PLAYER_COUNT', selectedPlayerCount);
      // Optionally, update game state or perform other actions
    },
  },
};
</script>
