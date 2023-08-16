import axios from 'axios'

export default{
    CreateGame(game){
        return axios.post('/game', game)
    },
    UpdateGame(game){
        return axios.put(`/game/${game.id}`)
    },
    //We can filter out the proper game with SQL
    GetInProgressGameByUserId(userId){
        return axios.get(`/game?userid=${userId}`)
    }
}