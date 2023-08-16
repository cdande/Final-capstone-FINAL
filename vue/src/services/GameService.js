import axios from 'axios'

export default{
    CreateGame(game){
        return axios.post('/game', game)
    }
}