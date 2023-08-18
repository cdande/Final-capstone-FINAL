<template>
  <div class="rules-page">
    <h2 class="rules-title">Game Rules</h2>
    <div class="rule-book">
      <ol class="rules-list">
        <li>
          You will need at least 2 players to start the game, but can play with up to 6.
        </li>
        <li>
          Each player starts with $1,000,000 in cash which is used to buy stocks, pay fines or any other purpose requiring cash.
        </li>
        <li>
          A player's turn starts by rolling two six-sided virtual die. The player moves squares equal to the sum of the roll.
        </li>
        <li>
          When a player lands on a stock on the game board, they have the option of paying the purchase price to buy it or not. Any player may buy that stock when it is there turn.
        </li>
        <li>
          A stock may be purchased multiple times by the same player or multiple players.
        </li>
        <li>
          After each turn, the value of a players held stock changes with the market.
        </li>
        <li>A player is out when they have 0 or negative net worth.</li>
        <li>
          The game ends when there is only one player left or a specific number of turns have passed which can be set when the game starts.
        </li>
        <p class = "luck">Good Luck, and Have Fun<p/>
      </ol>
    </div>
    <nav class="nav-padding">
     <router-link class="nav-link" :to="{ name: 'home' }">Back</router-link>
    </nav>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
.rules{
  background-color: #333;
}
.nav-link {
  text-decoration: none;
  color: #333;
  margin: 10px;
  padding: 5px 10px;
  border: 1px solid #333;
  border-radius: 4px;
  transition: background-color 0.3s, color 0.3s;
}

.nav-link:hover {
  background-color:#333;
  color:white;
}
.rules-page {
  padding: 2rem;
  font-size: 18px;
}
.nav-padding{
  margin-top: 20px;
}

.rules-title {
  font-size: 36px;
  margin-bottom: 1rem;
  color:white;
}

.rule-book {
  background-color: #f5f5f5;
  border: 2px solid #333;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
}

.rules-list {
  list-style-type: decimal;
  padding-left: 2rem;
  margin: 0;
}

.rules-list li {
  margin-bottom: 1rem;
  line-height: 1.5;
}
.luck{
  font-family: cursive;
  text-align: center;
}
</style>
