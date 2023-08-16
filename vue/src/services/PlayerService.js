import axios from 'axios';

export default {
    UpdatePlayer(player){
        return axios.put(`/player/${player.id}`, player)
    },
    CreatePlayers(players){
        return axios.post('/player', players)
    },
    GetPlayersByGameId(gameId){
        return axios.get(`/players?gameid=${gameId}`)
    }
}