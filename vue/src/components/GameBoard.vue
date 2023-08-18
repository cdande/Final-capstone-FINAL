<template>
  <div class="table">
    <h1>{{ this.currentGame.title }}</h1>
    <p>Max Turns: {{ this.currentGame.MaxTurns }}</p>
    <p>Current Turn: {{ this.currentGame.CurrentTurn }}</p>
    <div class="board">
      <div class="center">
        <h1 class="title">STOCKOPOLY</h1>
       <div class="current-player-box">
        <h2 class="current-player-header">Current Player:</h2>
        <div class="player-info">
          <img class="player-avatar" :src="currentPlayer.imageSource" alt="Player Avatar" />
          <span class="username">{{ splitUsername }}</span>
<p class="money">
  Money: <span class="money-value">${{ currentPlayer.money }}</span>
</p>
<p class="money">
  Stock Value: <span class="stock-value">${{ currentPlayer.stockValue }}</span>
</p>
        </div>
      </div>
        <p class="error-message" v-if="error">{{ error }}</p>
       <div class="button-container">
          <button class="action-button" @click="rollDice" :disabled="disabled">Roll Dice</button>
          <button class="action-button" @click="passTurn">Pass Turn</button>
        </div>
        <DiceComponent :value="dice1" />
    <DiceComponent :value="dice2" />
      </div>

      <div class="space corner go">
        <div class="container">
          <div class="instructions">Collect $25000.00 salary as you pass</div>
          <div class="go-word">go</div>
         <player-image :position= "0" />
        </div>
      </div>

      <div class="row horizontal-row bottom-row">
        <div class="space property">
          <div class="container">
            <img src="../img/nvidia.png" alt="nvidia" />
            <div class="name"></div>
            <div class="price">PRICE $130,000</div>
            <player-image :position= "9" />
             <button class="buy-button" @click="buyProperty(130000)" v-if="showBuyButtonForNvidia">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img
              class="photo"
              src="../img/applied.jpg"
              alt="applied"
              width="50%"
            />
            <div class="name"></div>
            <div class="price">Price $145,000</div>
           <player-image :position= "8" />
            <button class="buy-button" @click="buyProperty(145000)" v-if="showBuyButtonForApplied">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img
              class="bigPhoto"
              src="../img/nubo.jpeg"
              alt="nubo"
            />
            <div class="name"></div>
            <div class="price">Price $100,000</div>
           <player-image :position= "7" />
            <button class="buy-button" @click="buyProperty(100000)" v-if="showBuyButtonForNubo">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src=../img/gamestop.png alt="gamestop" >
            <div class="price">Price $110,000</div>
           <player-image :position= "6" />
            <button class="buy-button" @click="buyProperty(110000)" v-if="showBuyButtonForGamestop">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space railroad">
          <div class="container">
            <img src=../img/apple.jpg alt="apple" >
            <div class="price">Price $200,000</div>
            <player-image :position= "5" />
             <button class="buy-button" @click="buyProperty(200000)" v-if="showBuyButtonForApple">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space fee income-tax">
          <div class="container">
            <div class="name">SEC Fine</div>
            <div class="diamond"></div>
            <div class="instructions">Pay 10%<br />or<br />$200,000</div>
           <player-image :position= "4" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src=../img/tech-elevator.png alt="tech" >
            <div class="price">Price $100,000</div>
           <player-image :position= "3" />
            <button class="buy-button" @click="buyProperty(100000)" v-if="showBuyButtonForTech">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Product Recall</div>
            <div class="instructions">Lose $50,000</div>
            <player-image :position= "2" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src=../img/metrohealth.png alt="metrohealth" >
            <div class="price">Price $135,000</div>
            <player-image :position= "1" />
             <button class="buy-button" @click="buyProperty(135000)" v-if="showBuyButtonForMetro">
      Buy Stock
    </button>
          </div>
        </div>
      </div>

      <div class="space corner jail">
        <div class="just">Just</div>
        <div class="drawing">
          <div class="container">
            <div class="name">In</div>
            <div class="window">
              <div class="bar"></div>
              <div class="bar"></div>
              <div class="bar"></div>
            </div>
            <div class="name">Jail</div>
            <player-image :position= "10" />
          </div>
        </div>
        <div class="visiting">Visiting</div>

      </div>

      <div class="row vertical-row left-row">
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/att.webp" alt="at&t" />
            <div class="price">Price $80,000</div>
            <player-image :position= "19" />
             <button class="buy-button" @click="buyProperty(80000)" v-if="showBuyButtonForATT">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/americanairlines.png" alt="american airlines" />
            <div class="price">Price $180,000</div>
           <player-image :position= "18" />
            <button class="buy-button" @click="buyProperty(180000)" v-if="showBuyButtonForAA">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Employee Strike</div>
            <div class="instructions">Lose $30,000</div>
            <player-image :position= "17" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/boeing.webp" alt="boeing" />
            <div class="price">Price $165,000</div>
           <player-image :position= "16" />
            <button class="buy-button" @click="buyProperty(165000)" v-if="showBuyButtonForBoeing">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/xngage.png" alt="xngage" />
            <div class="price">Price $155,000</div>
           <player-image :position= "15" />
            <button class="buy-button" @click="buyProperty(155000)" v-if="showBuyButtonForXngage">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/chipotle.png" alt="chiptole" />
            <div class="price">Price $65,000</div>
            <player-image :position= "14" />
             <button class="buy-button" @click="buyProperty(65000)" v-if="showBuyButtonForChipotle">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/cigna.png" alt="cigna" />
            <div class="price">Price $90,000</div>
            <player-image :position= "13" />
             <button class="buy-button" @click="buyProperty(90000)" v-if="showBuyButtonForCigna">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Lucky Day</div>
            <div class="instructions">Gain $35,000</div>
            <player-image :position= "12" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/dollartree.png" alt="dollar tree" />
            <div class="price">Price $140,000</div>
            <player-image :position= "11" />
             <button class="buy-button" @click="buyProperty(140000)" v-if="showBuyButtonForDollarTree">
      Buy Stock
    </button>
          </div>
        </div>
      </div>

      <div class="space corner free-parking">
        <div class="container">
          <div class="name">Holiday</div>
          <div class="name">Season</div>
         <player-image :position= "20" />
        </div>
      </div>

      <div class="row horizontal-row top-row">
        <div class="space property">
          <div class="container">
            <img src="../img/fedex.png" alt="fedex" />
            <div class="price">Price $220,000</div>
            <player-image :position= "21" />
             <button class="buy-button" @click="buyProperty(220000)" v-if="showBuyButtonForFedex">
      Buy Stock
    </button>
          </div>
        </div>
         <div class="space community-chest">
          <div class="container">
            <div class="name">Executive Coruption</div>
            <div class="instructions">Lose $50,000</div>
            <player-image :position= "22" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/fidelity.jpg" alt="fidelity" />
            <div class="price">Price $122,000</div>
            <player-image :position= "23" />
             <button class="buy-button" @click="buyProperty(122000)" v-if="showBuyButtonForFidelity">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/garmin.png" alt="garmin" />
            <div class="price">Price $65,000</div>
            <player-image :position= "24" />
             <button class="buy-button" @click="buyProperty(65000)" v-if="showBuyButtonForGarmin">
      Buy Stock
    </button>
          </div>
        </div>
          <div class="space property">
          <div class="container">
            <img src="../img/progressive.png" alt="progressive" />
            <div class="price">Price $260,000</div>
            <player-image :position= "25" />
             <button class="buy-button" @click="buyProperty(260000)" v-if="showBuyButtonForProgressive">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" 
            src="../img/generalmills.jpg" 
            alt="general mills" />
            <div class="price">Price $125,000</div>
            <player-image :position= "26" />
             <button class="buy-button" @click="buyProperty(125000)" v-if="showBuyButtonForGeneral">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/google.png" alt="google" />
            <div class="price">Price $255,000</div>
           <player-image :position= "27" />
            <button class="buy-button" @click="buyProperty(255000)" v-if="showBuyButtonForGoogle">
      Buy Stock
    </button>
          </div>
        </div>
          <div class="space property">
          <div class="container">
            <img src="../img/nike.png" alt="nike" />
            <div class="price">Price $190,000</div>
            <player-image :position= "28" />
             <button class="buy-button" @click="buyProperty(190000)" v-if="showBuyButtonForNike">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img
             src="../img/heinz.png" alt="heinz" />
            <div class="price">Price $110,000</div>
            <player-image :position= "29" />
             <button class="buy-button" @click="buyProperty(110000)" v-if="showBuyButtonForHeinz">
      Buy Stock
    </button>
          </div>
        </div>
      </div>

      <div class="space corner go-to-jail">
        <div class="container">
          <div class="name">It's The</div>
          <div class="name">Weekend</div>
         <player-image :position= "30" />
        </div>
      </div>

      <div class="row vertical-row right-row">
        <div class="space property">
          <div class="container">
            <img src="../img/hershey.png" alt="hershey" />
            <div class="price">Price $128,000</div>
           <player-image :position= "31" />
            <button class="buy-button" @click="buyProperty(128000)" v-if="showBuyButtonForHershey">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/homedepot.png" alt="home depot" />
            <div class="price">Price $122,000</div>
            <player-image :position= "32" />
             <button class="buy-button" @click="buyProperty(122000)" v-if="showBuyButtonForHomedepot">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Natural Disaster</div>
            <div class="instructions">Lose $22,000</div>
            <player-image :position= "33" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/intel.png" alt="intel" />
            <div class="price">Price $320,000</div>
            <player-image :position= "34" />
             <button class="buy-button" @click="buyProperty(320000)" v-if="showBuyButtonForIntel">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" 
            src="../img/sherwinwilliams.png" alt="sherwinwilliams" />
            <div class="price">Price $125,000</div>
            <player-image :position= "35" />
             <button class="buy-button" @click="buyProperty(125000)" v-if="showBuyButtonForSherwin">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" 
            src="../img/wellsfargo.png" alt="wellsfargo" />
            <div class="price">Price $345,000</div>
            <player-image :position= "36" />
             <button class="buy-button" @click="buyProperty(345000)" v-if="showBuyButtonForWells">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/johndeere.jpg" alt="john deere" />
            <div class="price">Price $122,000</div>
           <player-image :position= "37" />
            <button class="buy-button" @click="buyProperty(122000)" v-if="showBuyButtonForJohn">
      Buy Stock
    </button>
          </div>
        </div>
        <div class="space fee luxury-tax">
          <div class="container">
            <div class="name">Luxury Tax</div>
            <div class="instructions">Pay $75,000</div>
            <player-image :position= "38" />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/waltdisney.jpg" alt="walt disney" />
            <div class="price">Price $400,000</div>
           <player-image :position= "39" />
            <button class="buy-button" @click="buyProperty(400000)" v-if="showBuyButtonForDisney">
      Buy Stock
    </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import DiceComponent from'./DiceComponent.vue'
import PlayerImage from './PlayerImage.vue'
import PlayerService from '../services/PlayerService'
import GameService from '../services/GameService'
export default {
  components: {
    PlayerImage,
    DiceComponent,
  },
  data() {
    return {
      error: "",
      currentPlayerIndex: 0,
      dice1: 0,
      dice2: 0,
    };
  },
  created() {
   this.playerTurn({...this.$store.state.players[0], isTurn: true});
   this.playerImage();
   
  },
  methods: {
    
    buyProperty(price) {
      // Find the player at the current position
      const currentPlayer = this.$store.state.players[this.currentPlayerIndex];

      
      // Add stocks to database when possible
      if (currentPlayer.money >= price) {
        // Add a nicer pop-up?
        const confirmBuy = confirm(`Do you want to buy this stock for $${price}?`);
        if (confirmBuy) {
          currentPlayer.money -= price;
          // currentPlayer.stocksOwned.push("NVIDIA"); // Update this logic with actual property details
          currentPlayer.stockValue += price;
          // Update the player's information in the store or database
          PlayerService.UpdatePlayer(currentPlayer);
        }
      } else {
        alert("You don't have enough money to buy this property.");
      }
    },
    rollDice() {
      this.$store.state.players.forEach((player) => {
        if (player.isTurn && !this.isRolled) {
          this.dice1 = Math.floor(Math.random() * 6) + 1;
          this.dice2 = Math.floor(Math.random() * 6) + 1;
          for (let i = 0; i < this.dice1 + this.dice2; i++) {
            if (player.position === 39) {
              player.position = 0;
               this.playerPosition(player);
            } else {
              player.position++;
               this.playerPosition(player);
            }
          }
          if (this.dice1 === 1 && this.dice2 === 1) {
            player.isRolled = false;
          } else {
            this.isPlayerRolled({...player, isRolled: true})
            //this.playerTurn({...player, isTurn: false});
          }
        }
      });
    },
    playerImage() {
      this.$store.state.players.forEach((player) => {
        let selectedCharacter = player.selectCharacter || "defaultCharacter";
        switch (selectedCharacter) {
          case "bull":
            this.$store.commit("SET_IMAGE", {...player, imageSource : require("../img/bull.jpg")});
            break;
          case "bear":
            this.$store.commit("SET_IMAGE", {...player, imageSource : require("../img/bear.jpg")});
            break;
          case "shark":
            this.$store.commit("SET_IMAGE", {...player, imageSource : require("../img/shark.jpg")});
            break;
          case "lion":
            this.$store.commit("SET_IMAGE", {...player, imageSource : require("../img/lion.jpg")});
            break;
          case "eagle":
            this.$store.commit("SET_IMAGE", {...player, imageSource : require("../img/eagle.jpg")});
            break;
          default:
            this.$store.commit("SET_IMAGE", {...player, imageSource : require("../img/tiger.jpg")});
            break;
        }
      });
    },
    playerPosition(player){
     this.$store.commit("SET_POSITION", player);
    },
    isPlayerRolled(player){
      this.$store.commit("SET_ISROLLED", player);
    },
    playerTurn(player){
      this.$store.commit("SET_TURN", player);
    },
    turnCounter(game){
      this.$store.commit("UPDATE_GAME", game)
    },
    rng(stockValue) {
  const diceRoll = Math.floor(Math.random() * 6) + 1;
  const isIncrease = diceRoll <= 3;
  const changeFactor = Math.random() * 0.1;
  const stockChange = stockValue * changeFactor;
  let newStockValue = isIncrease ? stockValue + stockChange : stockValue - stockChange;
  newStockValue = Math.max(newStockValue, 0);

  // Decimals ffor money value
  newStockValue = newStockValue.toFixed(2);

  return parseFloat(newStockValue); 
},
    passTurn(){
      if(this.currentPlayer.isRolled){
        this.currentPlayer.isTurn = false;
         this.currentPlayer.stockValue = this.rng(this.currentPlayer.stockValue);
        PlayerService.UpdatePlayer(this.currentPlayer)
      if(this.currentPlayerIndex + 1 < this.playerCount){
        this.currentPlayerIndex++;
      }
      else{
        this.currentPlayerIndex = 0;
        this.$store.state.currentGame.CurrentTurn++;
        console.log(this.currentGame.CurrentTurn, this.currentGame.MaxTurns)
        if(this.currentGame.CurrentTurn > this.currentGame.MaxTurns){
          this.currentGame.IsInProgress = false;
          this.turnCounter(this.currentGame);
          GameService.UpdateGame(this.currentGame);
          this.$router.push('endscreen')
        }
        else{
          this.turnCounter(this.currentGame);
          GameService.UpdateGame(this.currentGame);
        }
      }
      this.currentPlayer.isTurn = true;
      this.error = "";
    }
    else{
      this.error = "You need to Roll before you can Pass your turn.";
    }
    this.currentPlayer.isRolled = false;
      }
      
  },
  computed: {
     showBuyButtonForNvidia() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 9); 
    return currentPlayer && currentPlayer.money >= 130000; 
     },

    showBuyButtonForApplied() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 8); 
    return currentPlayer && currentPlayer.money >= 145000; 
    },

    showBuyButtonForNubo() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 7); 
    return currentPlayer && currentPlayer.money >= 100000; 
    },

    showBuyButtonForGamestop() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 6); 
    return currentPlayer && currentPlayer.money >= 110000; 
    },

    showBuyButtonForApple() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 5); 
    return currentPlayer && currentPlayer.money >= 200000; 
    },

    showBuyButtonForTech() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 3); 
    return currentPlayer && currentPlayer.money >= 100000; 
    },

    showBuyButtonForMetro() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 1); 
    return currentPlayer && currentPlayer.money >= 135000; 
    },

    showBuyButtonForATT() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 19); 
    return currentPlayer && currentPlayer.money >= 80000; 
    },

    showBuyButtonForAA() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 18); 
    return currentPlayer && currentPlayer.money >= 180000; 
    },

    showBuyButtonForBoeing() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 16); 
    return currentPlayer && currentPlayer.money >= 165000; 
    },

    showBuyButtonForXngage() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 15); 
    return currentPlayer && currentPlayer.money >= 155000; 
    },

    showBuyButtonForChipotle() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 14); 
    return currentPlayer && currentPlayer.money >= 65000; 
    },

    showBuyButtonForCigna() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 13); 
    return currentPlayer && currentPlayer.money >= 90000; 
    },

    showBuyButtonForDollarTree() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 11); 
    return currentPlayer && currentPlayer.money >= 140000; 
    },

    showBuyButtonForFedex() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 21); 
    return currentPlayer && currentPlayer.money >= 220000; 
    },


    showBuyButtonForFidelity() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 23); 
    return currentPlayer && currentPlayer.money >= 122000; 
    },

    showBuyButtonForGarmin() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 24); 
    return currentPlayer && currentPlayer.money >= 65000; 
    },

    showBuyButtonForProgressive() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 25); 
    return currentPlayer && currentPlayer.money >= 260000; 
    },

    showBuyButtonForGeneral() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 26); 
    return currentPlayer && currentPlayer.money >= 125000; 
    },

    showBuyButtonForGoogle() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 27); 
    return currentPlayer && currentPlayer.money >= 255000; 
    },

    showBuyButtonForNike() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 28); 
    return currentPlayer && currentPlayer.money >= 190000; 
    },

    showBuyButtonForHeinz() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 29); 
    return currentPlayer && currentPlayer.money >= 110000; 
    },

    showBuyButtonForHershey() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 31); 
    return currentPlayer && currentPlayer.money >= 128000; 
    },

    showBuyButtonForHomedepot() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 32); 
    return currentPlayer && currentPlayer.money >= 122000; 
    },

    showBuyButtonForIntel() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 34); 
    return currentPlayer && currentPlayer.money >= 320000; 
    },

    showBuyButtonForSherwin() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 35); 
    return currentPlayer && currentPlayer.money >= 125000; 
    },

    showBuyButtonForWells() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 36); 
    return currentPlayer && currentPlayer.money >= 345000; 
    },

    showBuyButtonForJohn() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 37); 
    return currentPlayer && currentPlayer.money >= 122000; 
    },

    showBuyButtonForDisney() {
    const currentPlayer = this.$store.state.players.find(player => player.position === 39); 
    return currentPlayer && currentPlayer.money >= 400000; 
    },


    disabled() {
      //Updating current players roll status based on data object 
      return this.currentPlayer.isRolled;
    },
    currentPlayer(){
      return this.$store.state.players[this.currentPlayerIndex]
    },
    playerCount(){
      return this.$store.state.players.length;
    },
     splitUsername() {
      // Adjust the maximum length as needed
      const maxLength = 12;
      const username = this.currentPlayer.username;
      return username.length > maxLength ? `${username.slice(0, maxLength)}...` : username;
  },
    currentGame(){
      return this.$store.state.currentGame;
    }
  }
};
</script>

<style>
* {
  box-sizing: border-box;
}
body {
  margin: 0;
  font-family: "Oswald", sans-serif;
  font-weight: 400;
  font-size: 10px;
  color: #080808;
  text-transform: uppercase;
}
h1,
h2,
h3,
h4,
h5,
h6 {
  margin: 0;
}

.dark-purple {
  background: #5e3577;
}
.light-blue {
  background: #d2eaf5;
}
.purple {
  background: #b02f7c;
}
.orange {
  background: #fa811d;
}
.red {
  background: #f50c2b;
}
.yellow {
  background: #ffed20;
}
.green {
  background: #41994e;
}
.dark-blue {
  background: #5a6dba;
}
.table {
  padding-left: 50px;
  padding-right: 50px;
}
.board {
  display: grid;
  grid-template-columns: 125px repeat(9, 80px) 125px;
  grid-template-rows: 125px repeat(9, 80px) 125px;
  grid-gap: 2px;
  margin: 50px auto;
  width: 994px;
  height: 994px;
  background: #080808;
  border: 2px solid #080808;
}
.center {
  grid-column: 2 / 11;
  grid-row: 2 / 11;
  background: #fafaf8;
  display: grid;
  grid-template-columns: repeat(7, 1fr);
  grid-template-rows: repeat(7, 1fr);
  justify-items: center;
  align-items: center;
}
.title {
  grid-column: 1 / 9;
  grid-row: 4;
  font-size: 90px;
  font-weight: 400;
  letter-spacing: 12px;
}

.label {
  text-align: center;
  font-weight: 500;
  letter-spacing: 3px;
  padding-bottom: 10px;
}
.deck {
  border: 2px dashed #080808;
  width: 160px;
  height: 120px;
}
.row {
  display: grid;
  grid-gap: 2px;
}
.horizontal-row {
  grid-template-columns: repeat(9, 80px);
  grid-template-rows: 125px;
}
.vertical-row {
  grid-template-columns: 125px;
  grid-template-rows: repeat(9, 80px);
}
.vertical-row .container {
  top: 50%;
  left: 50%;
}
.bottom-row {
  grid-column: 2 / 11;
  grid-row: 11;
}
.left-row {
  grid-column: 1;
  grid-row: 2 / 11;
}
.left-row .container {
  transform: translate(-50%, -50%) rotate(90deg);
}
.top-row {
  grid-column: 2 / 11;
  grid-row: 1;
}
.top-row .container {
  transform: rotate(180deg);
}
.right-row {
  grid-column: 11;
  grid-row: 2 / 11;
}
.right-row .container {
  transform: translate(-50%, -50%) rotate(270deg);
}
.space {
  background: #fafaf8;
  text-align: center;
}
.space .container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  position: relative;
  transform-origin: center;
  height: 125px;
  width: 80px;
}
.space .name,
.space .instructions {
  padding-left: 15px;
  padding-right: 15px;
}
.space .price {
  font-size: 7px;
  font-weight: 400;
  padding-bottom: 5px;
}
.corner .container {
  justify-content: space-around;
  height: 100%;
  width: 100%;
}
.corner .name {
  padding: 0;
}
.property .color-bar {
  height: 25px;
  border-bottom: 2px solid #080808;
}
.property .name {
  padding-bottom: 50px;
}
.railroad .name {
  padding-top: 10px;
}

.utility .name {
  padding-top: 10px;
}

.fee .name {
  padding-top: 10px;
  font-size: 14px;
}
.fee .instructions {
  font-size: 10px;
}
.go {
  grid-column: 11;
  grid-row: 11 / 12;
  position: relative;
}
.go .container {
  justify-content: flex-start;
  transform: rotate(315deg);
}
.go .instructions {
  padding: 0 30px;
}
.go .go-word {
  font-size: 60px;
  color: #f50c2b;
}
.go .arrow {
  font-size: 45px;
  color: #f50c2b;
  position: absolute;
  bottom: -10px;
  left: 5px;
}
.jail {
  grid-column: 1;
  grid-row: 11 / 12;
  display: grid;
  grid-template-columns: repeat(10, 12.5px);
  grid-template-rows: repeat(10, 12.5px);
  justify-content: center;
  align-items: center;
}
.jail .drawing {
  grid-column: 4 / 11;
  grid-row: 1 / 8;
  width: 87.5px;
  height: 87.5px;
  background: #fa811d;
  border-bottom: 2px solid #080808;
  border-left: 2px solid #080808;
}
.jail .just {
  grid-column: 3;
  grid-row: 4;
  transform: rotate(90deg);
  padding-top: 5px;
}
.jail .visiting {
  grid-column: 6;
  grid-row: 8;
  padding-top: 5px;
}
.jail .container {
  align-items: center;
  transform: rotate(45deg);
}
.jail .name {
  font-size: 14px;
}
.jail .window {
  display: flex;
  justify-content: space-around;
  align-items: center;
  position: relative;
  width: 55px;
  height: 55px;
  background: #fafaf8;
  border: 2px solid #080808;
}
.jail .person {
  position: absolute;
  transform: translate(-50%, -50%);
  top: 50%;
  left: 50%;
  font-size: 40px;
}
.jail .bar {
  height: 55px;
  width: 2px;
  background: #080808;
}
.free-parking {
  grid-column: 1;
  grid-row: 1 / 2;
}
.free-parking .container {
  justify-content: center;
  transform: rotate(135deg);
}
.free-parking .name {
  font-size: 16px;
}

.go-to-jail {
  grid-column: 11;
  grid-row: 1 / 1;
}
.go-to-jail .container {
  justify-content: center;
  transform: rotate(225deg);
}
.go-to-jail .name {
  font-size: 16px;
}

.chance .container {
  justify-content: center;
}

.chance .blue {
  color: #5a6dba;
}
.community-chest .container {
  justify-content: space-around;
}

.community-chest .instructions {
  font-size: 8px;
}

.income-tax .container {
  justify-content: center;
  align-items: center;
}
.income-tax .name {
  padding-bottom: 5px;
}
.income-tax .diamond {
  width: 5px;
  height: 5px;
  background: #080808;
  transform: rotate(45deg);
  display: inline-block;
}
.income-tax .instructions {
  padding-top: 5px;
  padding-bottom: 5px;
}

.luxury-tax .instructions {
  padding-bottom: 5px;
}
.long-name {
  padding-left: 0 !important;
  padding-right: 0 !important;
}
.three-line-name {
  position: relative;
  top: 5px;
}
.photo {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 100%;
}
.bigPhoto {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 50%;
}
.player-avatar{
  height: 50%;
  width: 50%;
   border-radius: 50%;
  margin-left: 10px; 
  border: 2px solid #3498db; 
  box-shadow: 0 0 5px rgba(0, 0, 0, 0.2); 
}
.current-player-box {
   min-width: 300px;
   min-height: 300px;
  border: 2px solid #3498db;
  padding: 50px;
  border-radius: 10px; 
  background-color: #f2f2f2;
  display: inline-block;
  margin-bottom: 20px;
  margin: 10px;
}

.current-player-header {
  margin: 0;
  font-size: 18px;
  color: #3498db;
}

.player-info {
  display: flex;
   flex-direction: column;
  align-items: center;
}

.username {
  font-size: 18px;
  margin-left: 10px;
}
.player-avatar-container {
  flex-shrink: 0; /* Stop picture from shrinking */
  margin-right: 10px; /* Space between picture and text */
}

.error-message {
  color: #e74c3c;
  font-size: 15px;
  margin-top: 15px;
  text-align: center;
  border: 2px solid #e74c3c;
  padding: 10px;
  background-color: #ffecec;
  border-radius: 5px;
  box-shadow: 0 0 10px rgba(231, 76, 60, 0.5);
  margin: 20px;
}
.button-container {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

.action-button {
  padding: 10px 20px;
  margin: 0 10px;
  font-size: 16px;
  border: none;
  border-radius: 5px;
  background-color: #3498db;
  color: white;
  cursor: pointer;
  transition: background-color 0.3s, color 0.3s;
}

.action-button:hover {
  background-color: #2980b9;
}

.action-button:disabled {
  background-color: #cccccc;
  cursor: not-allowed;
}
.money-value,
.stock-value{
  font-size: 14px;
}
.money-value {
  color: green;
}

.stock-value {
  color: blue;
}

</style>