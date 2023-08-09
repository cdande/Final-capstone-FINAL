<template>
  <div class ='home'>
     <div class='img' id='top'> 
       <div id='title'>
      <h1>Welcome To Stockopoly</h1>
      <h2> No matter if its a bull or bear market, we will always have fun! Become a stock broker now </h2>
      </div>
      </div>
      
      <h2 class = "description" id='DescTitle'>Description</h2>
      <p  class = "description" id='Descdesc'> Players take turns rolling dice and moving around the board buying and selling stock, trying to accrue the most amount of money before the game's end. The game ends when the preselected timer hits zero, or all but one player lose their money. The winner of the game is the player with the most amount of money at the end.</p>
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
        <li> 3 </li>
        </ol>
        <div class="button">
        <button @click="$router.push('create')" id="button">Create New Game</button>
        </div>
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
  display:flex;
  margin: 5 em auto;
  font-weight: 400;
  font-size: 15px;
  margin:10px;
  align-items: center;
}
.rules{
  display:grid;
  grid-area: rules;
  border: 3px solid black;
  border-radius: 10px;
  margin:10px
}
.img{
  display:flex;
  grid-area: header;
  margin: 5 em auto;
  border: 3px solid black;
  border-radius: 10px;
  background:url(https://images.saymedia-content.com/.image/t_share/MTkzNjc2OTcxNTA5NTU2Njc1/kid-friendly-c[…]nies-to-study-in-a-stockmarket-portfolio-simulation.jpg);
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
  background-position: center;
  justify-content: center;
  align-items: center;
  /* the line hight is to make the text sit closer to the middle of the image */
  line-height: 100px;
  margin:10px
}
.description{
  grid-area: description;
  text-align: center;
  padding-block: 20px;
  margin: 1 em aut0;
   line-height: 25px;
}
#top{
  padding-bottom:300px;
}
#DescTitle{
  padding-bottom:20px;
  margin: 1 em auto;
}
#title{
  display:block;
  text-align: center;
  border: 3px solid black;
  border-radius: 10px;
  /* rgba is to make the background color opaque. rgb incase something doesn't support it */
  background-color: rgba(255, 127, 80, .5)
}
#Descdesc{
  text-align: left;
  margin: 2em auto;
  padding-left: 20px;
  padding-right: 20px;
  font-weight: bold;
}
html{
   background-color: rgba(255, 127, 80, .5);
}
#title> h2{
  padding-left:20px;
  padding-right: 20px;
}
#button{
  width:100px;
}
.button{
  display:flex;
  grid-area: leaderboard;
  align-content: center;
  align-items: center;
  justify-content: center;
  margin-bottom: 10px;
}
.logo {
  height:100px;
  width:150px;
  margin:10px;
  display:inline-block;
  border: 3px solid black;
  border-radius: 25px;
}
#logo{
  display: inline-block;
}
#navText{
  display: inline-block;
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