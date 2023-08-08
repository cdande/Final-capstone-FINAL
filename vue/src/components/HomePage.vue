<template>
  <div class ='home'>
     <div class='img' id='top'> 
      <h1>Welcome To Stockopoly</h1>
      <h2> No matter if its a bull or bear market, we will always have fun! Become a stock broker now </h2>
      </div>
      <h2 class = "description" id='DescTitle'>Description</h2>
      <p  class = "description"> Players take turns rolling dice and moving around the board buying and selling stock, trying to accrue the most amount of money before the game's end. The game ends when the preselected timer hits zero, or all but one player lose their money. The winner of the game is the player with the most amount of money at the end.</p>
      <ol class = "rules"><h3>Rules</h3>
        <li>You will need at least 2 players to start the game, but can play with up to 6.</li>
        <li>Each player starts with $1,000,000 in cash which is used to buy stocks, pay fines or any other purpose requiring cash.</li>
        <li>A player's turn starts by rolling two six-sided virtual die. The player moves squares equal to the sum of the roll.</li>
        <li>When a player lands on a stock in the game board they have the option of paying the purchase price to buy it or not. If the Player decides to not buy the stock it remains unsold.</li>
        <li>A stock may be purchased multiple times by the same player or multiple players. The only way a player may acquire stock is to land on it during the course of the game or buy/trade with another player.</li>
        <li>Players may trade or auction stocks with other players to raise cash. If a player attempts to trade or auction a stock and no other player is interested, the player has the option of keeping the stock or selling back to the bank for 1/2 the purchase price.</li>
        <li>If a player lands on an Individual Stock (like a property in Monopoly)
hazards such as SEC Invistigates Company, Product Recall, Employee Strike, Natural Disaster, Executive Corruption which will require players to pay fines or lose a percentage of value in the company stock.
Bonus' such as gifts, stock split, dividends
Charitible contributions where a percentage of the player’s net worth is donanted when landing upon the spot.
Players shall receive a bonus of $25000 each time they complete a rotation of the board (kike passing “Go” in Monopoly </li>
        <li>A player is out when they have 0 or negative net worth.</li>
        <li>The game ends when there is only one player left or a specific amount of time has passed which can be set when the game starts.</li>
        </ol>
        <button @click="$router.push('create')">Create New Game</button>
        <!-- change route -->
 </div>
</template>

<script>
export default {

}
</script>

<style>
.home {
  display:grid;
  grid-template-columns: 1fr;
  grid-template-areas:
  "header"
  "description"
  "rules"
  "leaderboard"
  "footer"
  ;
  margin: 25;
  font-family: "Oswald", sans-serif;
  font-weight: 400;
  font-size: 15px;
  color: #080808;
  text-transform: uppercase;
}
#nav {
  margin: 5 em auto;
  font-weight: 400;
  font-size: 15px;
  padding-block: 10px;
}
.rules{
  display:grid;
  grid-area: rules;
  border: solid;
  border-color: black;
  border-width: 10px;
  border-radius: 20px;
}
.img{
  grid-area: header;
  text-align: center;
  margin: 5 em auto;
  border: solid;
  border-color: black;
  border-radius: 10px;
  background:url(https://images.saymedia-content.com/.image/t_share/MTkzNjc2OTcxNTA5NTU2Njc1/kid-friendly-c[…]nies-to-study-in-a-stockmarket-portfolio-simulation.jpg);
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
  background-position: center;
  text-align: center;
  align-items:center;
  place-items:center;
   align-items:center;
  place-items:center;
}
.description{
  grid-area: description;
  text-align: center;
  padding-block: 20px;
  margin: 1 em aut0;
}
#top{
  padding-bottom:500px;
}
#DescTitle{
  padding-bottom:20px;
  margin: 1 em auto;
}
/* .home{
  background:url(https://e1.pxfuel.com/desktop-wallpaper/68/973/desktop-wallpaper-stock-market-and-exchange-candle-stick-graph-chart-of-stock-1300x866-for-your-mobile-tablet-stock-chart.jpg) no-repeat fixed;
   -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
  background: stretch;
} */

/* ol {
  background: #3399ff;
  padding: 20px;
}

ol li {
  background: #cce5ff;
  color: darkblue;
  margin: 5px;
} */
</style>