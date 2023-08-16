import axios from 'axios'

export default{
    GetStockByPlayerId(playerId){
        return axios.get(`/stocks?playerid=${playerId}`);
    }
}