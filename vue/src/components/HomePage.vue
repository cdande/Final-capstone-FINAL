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
      </div>
    </section>
    <h2 class="description" id="DescTitle">Description</h2>
    <p class="description" id="Descdesc">
      Players take turns rolling dice and moving around the board buying and
      selling stock, trying to accrue the most amount of money before the game's
      end. The game ends when the preselected timer hits zero, or all but one
      player lose their money. The winner of the game is the player with the
      most amount of money at the end.
    </p>
    <section class="stock-market-section">
      <div class="stock-data">
        <!-- Display dynamic stock market data and charts here -->
      </div>
    </section>

    <section class="monopoly-integration-section">
      <div class="monopoly-content">
        <!-- Integrate Monopoly-themed elements here -->
      </div>
    </section>

    <section class="cta-section">
      <div class="cta-content">
        <h2>Ready to Play?</h2>
        <p>
          Join the fun and experience the ultimate Monopoly Stock Game today!
        </p>
        <button class="cta-button" @click="signInPage" >Start Playing</button>
      </div>
    </section>

    <footer class="footer">
      <div class="footer-content">
        <p>&copy; 2023 STOCKOPOLY Game. All rights reserved.</p>
        <ul class="social-icons">
          <li>
            <a href="#"><i class="fab fa-facebook"></i></a>
          </li>
          <li>
            <a href="#"><i class="fab fa-twitter"></i></a>
          </li>
          <li>
            <a href="#"><i class="fab fa-instagram"></i></a>
          </li>
        </ul>
      </div>
    </footer>
  </div>
</template>

<script>
export default {
  name: "HomePage",
  methods: {
    signInPage(){
      this.$router.push("login")
    }
  }
};
</script>

<style scoped>
/* Add global styles here */
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
  grid-area: description;
  text-align: center;
  padding-block: 20px;
  margin: 1 em aut0;
  line-height: 25px;
  font-size: 25px;
}
#DescTitle {
  padding-bottom: 20px;
  margin: 1 em auto;
}
.cta-button {
  background-color: #ff9800;
  color: white;
  border: none;
  padding: 1rem 3rem;
  font-size: 1.2rem;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

.cta-button:hover {
  background-color: #f57c00;
}

.stock-market-section {
  background-color: #f7f7f7;
  padding: 5rem 0;
  text-align: center;
}

.stock-data {
  max-width: 1200px;
  margin: 0 auto;
}

.monopoly-integration-section {
  padding: 5rem 0;
  text-align: center;
}

.monopoly-content {
  max-width: 1200px;
  margin: 0 auto;
}

.cta-section {
  background-color: #333;
  color: white;
  padding: 5rem 0;
  text-align: center;
}

.cta-content {
  max-width: 800px;
  margin: 0 auto;
}

.social-icons {
  list-style: none;
  display: flex;
  gap: 1rem;
  margin-top: 2rem;
}

.social-icons a {
  color: white;
  font-size: 1.5rem;
  transition: color 0.3s ease;
}

.social-icons a:hover {
  color: #ff9800;
}
</style>