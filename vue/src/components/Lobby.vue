<template>
  <div class="container">
    <h1>Welcome To Your Game! Please Select Your Players!</h1>
    <table id="tblUsers">
      <thead>
        <tr>
          <th>&nbsp;</th>
          <th>Username |</th>
          <th>Select Character |</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <input type="checkbox" id="selectAll" v-bind="selectedUsers" />
          </td>

          <td>&nbsp;</td>
        </tr>
        <tr
          v-for="player in players"
          v-bind:key="player.id"
          v-bind:class="{ deactivated: player.status === 'Inactive' }"
        >
          <td>
            <input
              type="checkbox"
              class="checkbox"
              v-bind:id="player.id"
              v-bind:value="player.id"
              v-bind="selectedUsers"
              v-on:click="addtoCheckBoxArray(player)"
            />
          </td>
          <td class="">{{ player.username }}</td>
          <td class="">{{ player.selectCharacter }}</td>
        </tr>
      </tbody>
    </table>

    <div class="action-buttons">
      <button v-bind:disabled="disabled" v-on:click="deleteSelelected">
        Delete Users
      </button>
    </div>

    <button class="action-button" @click="showForm = !showForm">
      {{ showForm ? "Cancel Adding" : "Add New User" }}
    </button>
    <button class="action-button" @click="BeginGame" id="button">Start Game!</button>
    <form
      id="frmAddNewUser"
      v-on:submit.prevent="addPlayer"
      v-show="showForm === true"
    >
      <div class="field">
        <label for="userName">Username:</label>
        <input type="text" required name="userName" v-model="player.username" />
      </div>
      <div class="field">
        <label for="selectCharacter"> Select Character:</label>
        <select required v-model="player.selectCharacter">
          <option value="bull" v-bind:disabled="isCharacterSelected('bull')">
            Bull
          </option>
          <option value="bear" v-bind:disabled="isCharacterSelected('bear')">
            Bear
          </option>
          <option value="shark" v-bind:disabled="isCharacterSelected('shark')">
            Shark
          </option>
          <option value="lion" v-bind:disabled="isCharacterSelected('lion')">
            Lion
          </option>
          <option value="eagle" v-bind:disabled="isCharacterSelected('eagle')">
            Eagle
          </option>
          <option value="tiger" v-bind:disabled="isCharacterSelected('tiger')">
            Tiger
          </option>
        </select>
      </div>

      <button type="submit" class="btn save">
        Save Player
      </button>
    </form>
     <GameRules/>
  </div>
</template>

<script>
import PlayerService from '../services/PlayerService';
import GameService from '../services/GameService';
import GameRules from "./GameRules.vue";

export default {
  components: {GameRules},
  
  name: "user-list",
  data() {
    return {
      disabled:false,
      showForm: false,
      selectedUsers: [],
      player: {
        id: null,
        username: "",
        selectCharacter: "",
        position: 0,
        isTurn:false,
        isRolled: false,
        money: 1000000,
        stocksOwned: [],
        imageSource: ""
      },
      players: [
        // The person loggin in should be automagically number one in the lobby without us adding
      ],
    };
  },
  methods: {
    addPlayer() {
      this.players.unshift(this.player);
      this.ResetPlayer();
    },
    addtoCheckBoxArray(player) {
      if (this.selectedUsers.includes(player)) {
        let index = this.selectedUsers.indexOf(player);
        this.selectedUsers.splice(index, 1);
      } else {
        this.selectedUsers.push(player);
      }
    },
    activateSelectedUsers() {
      this.selectedUsers.forEach((player) => {
        player.status = "Active";
      });
      let checkbox = document.querySelectorAll(".checkbox");
      checkbox.forEach((check) => {
        check.checked = false;
      });
      this.selectedUsers = [];
    },
    deactivateAll() {
      this.selectedUsers.forEach((player) => {
        player.status = "Inactive";
      });
      let checkbox = document.querySelectorAll(".checkbox");
      checkbox.forEach((check) => {
        check.checked = false;
      });
      this.selectedUsers = [];
    },
    deleteSelelected() {
      this.selectedUsers.forEach((player) => {
        this.players.pop(player);
      });
      let checkbox = document.querySelectorAll(".checkbox");
      checkbox.forEach((check) => {
        check.checked = false;
      });
      this.selectedUsers = [];
    },
    isCharacterSelected(character) {
      return this.players.some(
        (player) => player.selectCharacter === character
      );
    },
      async BeginGame(){
      await GameService.CreateGame(this.$store.state.currentGame);
      let players = await PlayerService.CreatePlayers(this.players);
      this.$store.commit("ADD_PLAYERS", players);
      this.$router.push('gameboard');
    },
    ResetPlayer(){
      this.player = {
        id: null,
        username: "",
        selectCharacter: "",
        position: 0,
        isTurn:false,
        isRolled: false,
        money: 1000000,
        stocksOwned: [],
        imageSource: "",
      };
    }
  },
};
</script>

<style scoped>
.container {
  font-family: 'Segoe UI', Roboto, Arial, sans-serif;
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
}

h1 {
  text-align: center;
  margin-bottom: 20px;
}

table {
  width: 100%;
  border-collapse: collapse;
  margin-bottom: 20px;
}

th, td {
  padding: 10px;
  border: 1px solid #ccc;
}

th {
  text-transform: uppercase;
  font-weight: bold;
  background-color: #f2f2f2;
  color: #333;
}

tr.deactivated {
  color: red;
}

.checkbox {
  margin: 0;
}

.action-buttons {
  display: flex;
  justify-content: center;
  margin-bottom: 20px;
}

.action-button {
  background-color: #3498db;
  color: white;
  border: none;
  padding: 10px 20px;
  margin-right: 10px;
  cursor: pointer;
  font-weight: bold;
  transition: background-color 0.3s ease;
}

.action-button:hover {
  background-color: #2980b9;
}

.form-field {
  display: flex;
  align-items: center;
  margin-bottom: 15px;
}

.form-field label {
  width: 150px;
  margin-right: 10px;
  font-weight: bold;
}

input[type="text"], select {
  padding: 5px;
  font-size: 16px;
  width: 100%;
  border: 1px solid #ccc;
  border-radius: 4px;
}

.btn.save {
  background-color: #2ecc71;
  color: white;
  border: none;
  padding: 10px 20px;
  cursor: pointer;
  font-weight: bold;
  transition: background-color 0.3s ease;
}

.btn.save:hover {
  background-color: #27ae60;
}

</style>