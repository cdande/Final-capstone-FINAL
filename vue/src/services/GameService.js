import axios from 'axios'

export default{
    CreateGame(game){
        return axios.post('/game', game)
    },
    UpdateGame(game){
        return axios.put(`/game/${game.id}`)
    }
}