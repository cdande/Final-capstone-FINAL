<template>
  <div class="table">
    <div class="board">
      <div class="center">
        <div class="community-chest-deck">
          <h2 class="label">Community Chest</h2>
          <div class="deck"></div>
        </div>
        <h1 class="title">STOCKOPOLY</h1>
        <button @click="rollDice" v-bind:disabled="disabled">Roll Dice</button>

        <p>{{ dice1 }}</p>
        <p>{{ dice2 }}</p>
        <div class="chance-deck">
          <h2 class="label">Chance</h2>
          <div class="deck"></div>
        </div>
      </div>

      <div class="space corner go">
        <div class="container">
          <div class="instructions">Collect $25000.00 salary as you pass</div>
          <div class="go-word">go</div>
          <img
            class="playerToken"
            v-if="player.position === 0"
            :src="playerImage"
            alt="hello"
          />
        </div>
      </div>

      <div class="row horizontal-row bottom-row">
        <div class="space property">
          <div class="container">
            <img src="../img/nvidia.png" alt="nvidia" />
            <div class="name"></div>
            <div class="price">PRICE $50</div>
            <img
              class="playerToken"
              v-if="player.position === 9"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img
              class="bigPhoto"
              src="../img/meta.png"
              alt="meta"
              width="50%"
            />
            <div class="name"></div>
            <div class="price">Price $25</div>
            <img
              class="playerToken"
              v-if="player.position === 8"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space chance">
          <div class="container">
            <div class="name">Chance</div>
            <img
              class="playerToken"
              v-if="player.position === 7"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src=../img/gamestop.png alt="gamestop" >
            <div class="price">Price $100</div>
            <img
              class="playerToken"
              v-if="player.position === 6"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space railroad">
          <div class="container">
            <img src=../img/apple.jpg alt="apple" >
            <div class="price">Price $200</div>
            <img
              class="playerToken"
              v-if="player.position === 5"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space fee income-tax">
          <div class="container">
            <div class="name">SEC Fine</div>
            <div class="diamond"></div>
            <div class="instructions">Pay 10%<br />or<br />$200,000</div>
            <img
              class="playerToken"
              v-if="player.position === 4"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src=../img/nike.png alt="nike" >
            <div class="price">Price $50</div>
            <img
              class="playerToken"
              v-if="player.position === 3"
              :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Community Chest</div>
            <div class="instructions">Follow instructions on top card</div>
            <img
              class="playerToken"
              v-if="player.position === 2"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="bigPhoto" src=../img/tesla.png alt="tesla" >
            <div class="price">Price $50</div>
            <img
              class="playerToken"
              v-if="player.position === 1"
              :src="playerImage"
              alt="hello"
            />
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
          </div>
        </div>
        <div class="visiting">Visiting</div>
        <img
          class="playerToken"
          v-if="player.position === 10"
            :src="playerImage"
          alt="hello"
        />
      </div>

      <div class="row vertical-row left-row">
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/att.webp" alt="at&t" />
            <div class="price">Price $200</div>
            <img
              class="playerToken"
              v-if="player.position === 19"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/americanairlines.png" alt="american airlines" />
            <div class="price">Price $180</div>
            <img
              class="playerToken"
              v-if="player.position === 18"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Community Chest</div>
            <div class="instructions">Follow instructions on top card</div>
            <img
              class="playerToken"
              v-if="player.position === 17"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/boeing.webp" alt="boeing" />
            <div class="price">Price $180</div>
            <img
              class="playerToken"
              v-if="player.position === 16"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space railroad">
          <div class="container">
            <div class="name long-name">Pennsylvania Railroad</div>
            <div class="price">Price $200</div>
            <img
              class="playerToken"
              v-if="player.position === 15"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/chipotle.png" alt="chiptole" />
            <div class="price">Price $160</div>
            <img
              class="playerToken"
              v-if="player.position === 14"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/cigna.png" alt="cigna" />
            <div class="price">Price $140</div>
            <img
              class="playerToken"
              v-if="player.position === 13"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space utility electric-company">
          <div class="container">
            <div class="name">Electric Company</div>
            <div class="price">Price $150</div>
            <img
              class="playerToken"
              v-if="player.position === 12"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/dollartree.png" alt="dollar tree" />
            <div class="price">Price $140</div>
            <img
              class="playerToken"
              v-if="player.position === 11"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
      </div>

      <div class="space corner free-parking">
        <div class="container">
          <div class="name">Holiday</div>
          <div class="name">Season</div>
          <img
            class="playerToken"
            v-if="player.position === 20"
              :src="playerImage"
            alt="hello"
          />
        </div>
      </div>

      <div class="row horizontal-row top-row">
        <div class="space property">
          <div class="container">
            <img src="../img/fedex.png" alt="fedex" />
            <div class="price">Price $220</div>
            <img
              class="playerToken"
              v-if="player.position === 21"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space chance">
          <div class="container">
            <div class="name">Chance</div>
            <img
              class="playerToken"
              v-if="player.position === 22"
              :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/fidelity.jpg" alt="fidelity" />
            <div class="price">Price $220</div>
            <img
              class="playerToken"
              v-if="player.position === 23"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/garmin.png" alt="garmin" />
            <div class="price">Price $200</div>
            <img
              class="playerToken"
              v-if="player.position === 24"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space railroad">
          <div class="container">
            <div class="name">B & O Railroad</div>
            <div class="price">Price $200</div>
            <img
              class="playerToken"
              v-if="player.position === 25"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/generalmills.jpg" alt="general mills" />
            <div class="price">Price $260</div>
            <img
              class="playerToken"
              v-if="player.position === 26"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/google.png" alt="google" />
            <div class="price">Price $260</div>
            <img
              class="playerToken"
              v-if="player.position === 27"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space utility waterworks">
          <div class="container">
            <div class="name">Waterworks</div>
            <div class="price">Price $120</div>
            <img
              class="playerToken"
              v-if="player.position === 28"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/heinz.png" alt="heinz" />
            <div class="price">Price $280</div>
            <img
              class="playerToken"
              v-if="player.position === 29"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
      </div>

      <div class="space corner go-to-jail">
        <div class="container">
          <div class="name">Go To</div>
          <div class="name">Jail</div>
          <img
            class="playerToken"
            v-if="player.position === 30"
              :src="playerImage"
            alt="hello"
          />
        </div>
      </div>

      <div class="row vertical-row right-row">
        <div class="space property">
          <div class="container">
            <img src="../img/hershey.png" alt="hershey" />
            <div class="price">Price $300</div>
            <img
              class="playerToken"
              v-if="player.position === 31"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img class="photo" src="../img/homedepot.png" alt="home depot" />
            <div class="price">Price $300</div>
            <img
              class="playerToken"
              v-if="player.position === 32"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space community-chest">
          <div class="container">
            <div class="name">Community Chest</div>
            <div class="instructions">Follow instructions on top card</div>
            <img
              class="playerToken"
              v-if="player.position === 33"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/intel.png" alt="intel" />
            <div class="price">Price $320</div>
            <img
              class="playerToken"
              v-if="player.position === 34"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space railroad">
          <div class="container">
            <div class="name">Short Line</div>
            <div class="price">Price $200</div>
            <img
              class="playerToken"
              v-if="player.position === 35"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space chance">
          <div class="container">
            <div class="name">Chance</div>
            <img
              class="playerToken"
              v-if="player.position === 36"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/johndeere.jpg" alt="john deere" />
            <div class="price">Price $350</div>
            <img
              class="playerToken"
              v-if="player.position === 37"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space fee luxury-tax">
          <div class="container">
            <div class="name">Luxury Tax</div>
            <div class="drawing fa fa-diamond"></div>
            <div class="instructions">Pay $75.00</div>
            <img
              class="playerToken"
              v-if="player.position === 38"
               :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
        <div class="space property">
          <div class="container">
            <img src="../img/waltdisney.jpg" alt="walt disney" />
            <div class="price">Price $400</div>
            <img
              class="playerToken"
              v-if="player.position === 39"
                :src="playerImage"
              alt="hello"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      dice1: 0,
      dice2: 0,
      player: {
        img: "bull",
        //img: this.$store.state.users[0].img,
        position: 0,
        isRolled: false,
        money: 1000000,
        stocksOwned: [],
      },
    };
  },
  created() {
    this.playerImage();
  },
  methods: {
    rollDice() {
      this.dice1 = Math.floor(Math.random() * 6) + 1;
      this.dice2 = Math.floor(Math.random() * 6) + 1;
      for (let i = 0; i < this.dice1 + this.dice2; i++) {
        if (this.player.position === 39) {
          this.player.position = 0;
        } else {
          this.player.position++;
        }
      }
      //   if (this.dice1 === 1 && this.dice2 === 1) {
      //     this.player.isRolled = false;
      //   } else {
      //     this.player.isRolled = true;
      //   }
    }
  },
  computed: {
    disabled() {
      if (this.player.isRolled === false) {
        return false;
      } else {
        return true;
      }
    },
    playerImage() {
      if (this.player.img === "bull") {
        return require("../img/apple.jpg");
      }
      if (this.player.img === "bull") {
        return require("../img/apple.jpg");
      }
      if (this.player.img === "bull") {
       return require("../img/apple.jpg");
      }
      if (this.player.img === "bull") {
        return require("../img/apple.jpg");
      }
      if (this.player.img === "bull") {
        return require("../img/apple.jpg");
      } else {
        return require("../img/apple.jpg");
      }
    },
  },
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
.playerToken {
	
  width: 30px;
  height: 30px;
  z-index: 100;
  position: absolute;
  border: 2px solid black;
  border-radius: 5px;
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
.community-chest-deck {
  grid-column: 2 / 4;
  grid-row: 2 / 4;
  transform: rotate(135deg);
  margin-bottom: 60px;
  margin-right: 60px;
}
.chance-deck {
  grid-column: 5 / 7;
  grid-row: 5 / 7;
  transform: rotate(315deg);
  margin-top: 60px;
  margin-left: 60px;
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
.railroad .drawing {
  font-size: 60px;
  color: #080808;
}
.utility .name {
  padding-top: 10px;
}
.utility .drawing {
  font-size: 70px;
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
.free-parking .drawing {
  font-size: 60px;
  color: #f50c2b;
  padding-top: 5px;
  padding-bottom: 5px;
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
.go-to-jail .drawing {
  font-size: 60px;
  color: #640303;
  padding-top: 5px;
  padding-bottom: 5px;
}
.chance .container {
  justify-content: center;
}
.chance .drawing {
  font-size: 90px;
  color: #f50c2b;
}
.chance .blue {
  color: #5a6dba;
}
.community-chest .container {
  justify-content: space-around;
}
.community-chest .drawing {
  font-size: 50px;
  color: #d2eaf5;
}
.community-chest .instructions {
  font-size: 8px;
}
.electric-company .drawing {
  color: #ffed20;
}
.waterworks .drawing {
  color: #5a6dba;
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
.luxury-tax .drawing {
  font-size: 50px;
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
  width: 70%;
}
.bigPhoto {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 50%;
}
</style>