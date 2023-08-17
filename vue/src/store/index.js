import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    players: [],

    currentGame: {
      //Get game id from database 
      title: "",
      MaxTurns: "",
      CurrentTurn: "",
      IsInProgress: "",
      UserId: "",
      GameId: 0
    }
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    ADD_PLAYERS(state, players) {
      state.players = players;
    },
    CREATE_GAME(state, game) {
      state.currentGame.title = game.title;
      state.currentGame.MaxTurns = game.MaxTurns;
      state.currentGame.CurrentTurn = game.CurrentTurn;
      state.currentGame.IsInProgress = game.IsInProgress;
      state.currentGame.UserId = game.UserId
    },
     UPDATE_GAME(state, game){
        state.currentGame.CurrentTurn = game.CurrentTurn;
        state.currentGame.IsInProgress = game.IsInProgress
     },
    SET_IMAGE(state, player) {
      let index = state.players.findIndex((p) => p.playerId === player.playerId)
      state.players[index] = player;
    },
    SET_POSITION(state, player) {
      let index = state.players.findIndex((p) =>  p.playerId === player.playerId);
      let newPlayers = structuredClone(state.players);
      newPlayers[index].position = player.position;
      state.players = newPlayers;
    },
    SET_ISROLLED(state, player) {
      let index = state.players.findIndex((p) =>  p.playerId === player.playerId)
      state.players[index].isRolled = player.isRolled;

    },
    SET_TURN(state, player){
      let index = state.players.findIndex((p) =>  p.playerId === player.playerId)
      state.players[index].isTurn = player.isTurn;
    },
    SET_GAME_FROM_DB(state, game){
      state.currentGame.title = game.title;
      state.currentGame.MaxTurns = game.maxTurns;
      state.currentGame.CurrentTurn = game.currentTurn;
      state.currentGame.IsInProgress = game.isInProgress;
      state.currentGame.UserId = game.UserId;
      state.currentGame.GameId = game.gameId;
    },
  }

})
