<template>
  <div class="homepage">
    <header class="header">
      <nav class="navbar">
        <div class="logo">Monopoly Stock Game</div>
        <ul class="nav-links">
          <li><router-link v-bind:to="{ name: 'home' }"> Home</router-link></li>
          <li><router-link v-bind:to="{ name: 'gamerules' }">Game Rules</router-link></li>
          <li><a href="#">Leaderboard</a></li>
          <li><a href="#">About</a></li>
        </ul>
      </nav>
    </header>

    <section class="hero">
      <div class="hero-content">
        <h1>Welcome to the Monopoly Stock Game</h1>
        <p>Experience the thrill of the stock market with a Monopoly twist.</p>
        <button class="cta-button" @click="signInPage" >Play Now</button>
        <!-- <button class="cta-button2" @click="signInPage" :disabled="hasGame" >Continue</button> -->
      </div>
    </section>
    <p class="description" id="Descdesc">
      Players take turns rolling dice and moving around the board buying and
      selling stock, trying to accrue the most amount of money before the game's
      end. The game ends when the preselected timer hits zero, or all but one
      player lose their money. The winner of the game is the player with the
      most amount of money at the end.
    </p>
    <section class="cta-section">
    <button class="cta-button" @click="gameRulesPage" >Game Rules</button>
    </section>

  <section class="cta-section">
      <div class="cta-content">
        <h2>Ready to Play?</h2>
        <p>
          Join the fun and experience the ultimate Monopoly Stock Game today!
        </p>
      </div>
    </section>

    <footer class="footer">
      <div class="footer-content">
        <p>&copy; 2023 STOCKOPOLY Game. All rights reserved.</p>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: "HomePage",
  methods: {
    signInPage(){
      this.$router.push("create")
    },
    gameRulesPage(){
      this.$router.push("gamerules")
    }
  }
};
</script>

<style scoped>
.homepage{
  background-color: #333;
}
body {
  font-family: "Arial", sans-serif;
  margin: 0;
  padding: 0;
}

.header {
  background-color: #333;
  color: white;
  padding: 1rem 0;
}

.logo {
  font-size: 1.5rem;
  font-weight: bold;
}

.nav-links {
  list-style: none;
  display: flex;
  gap: 1rem;
}

.nav-links a {
  color: white;
  text-decoration: none;
  transition: color 0.3s ease;
}

.nav-links a:hover {
  color: #ff9800;
}

.hero {
  background: linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.5)),
    url(https://images.saymedia-content.com/.image/t_share/MTkzNjc2OTcxNTA5NTU2Njc1/kid-friendly-c[…]nies-to-study-in-a-stockmarket-portfolio-simulation.jpg);
  color: white;
  text-align: center;
  padding: 8rem 0;
}

.hero-content {
  max-width: 800px;
  margin: 0 auto;
}

.hero h1 {
  font-size: 3rem;
  margin-bottom: 1rem;
}

.hero p {
  font-size: 1.5rem;
  margin-bottom: 2rem;
}
.description {
  color: white;
  text-align: center;
  padding-block: 20px;
  margin: 1 em aut0;
  line-height: 25px;
  font-size: 25px;
  background-color: #333;
}
#DescTitle {
  padding-bottom: 20px;
  margin: 1 em auto;
}
.cta-button,
.cta-button2 {
  margin: 4px;
  background: linear-gradient(to bottom, #ff9800, #f57c00);
  color: white;
  border: none;
  padding: 1rem 3rem;
  font-size: 1.2rem;
  cursor: pointer;
  transition: background-color 0.3s ease, transform 0.2s ease;
  border-radius: 8px; 
  box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1); 
}

.cta-button2 {
  background-color: #cccccc;
  cursor: not-allowed;
  border-radius: 8px; 
  box-shadow: none;
}

.cta-button:hover {
  background: linear-gradient(to bottom, #f57c00, #ff9800);
  transform: translateY(-2px); 
  box-shadow: 0px 6px 8px rgba(0, 0, 0, 0.15);
}

.cta-section {
  background-color: #333;
  color: white;
  padding: 3rem 0;
  text-align: center;
}

.cta-content {
  max-width: 800px;
  margin: 0 auto;
}
.footer-content{
  color:white;
}

</style>