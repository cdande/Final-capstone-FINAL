<template>
  <div class="congratulations-box">
    <router-link class="back-button" :to="{ name: 'home' }">Back</router-link>
    <div class="congratulations-message">
      <h1 class="big-text">Congratulations!</h1>
      <p class="small-text">You have completed the game.</p>
      <p class="small-text">Press "Back" to return to the Home Screen.</p>
      <h2 class="thank-you-text">Thank you for playing STOCKOPOLY</h2>
    </div>
  </div>
</template>

<script>
export default {

}
</script>

<style>
.congratulations-box {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 50px;
}

.back-button {
  text-decoration: none;
  color: #333;
  margin: 10px;
  padding: 5px 10px;
  border: 1px solid #333;
  border-radius: 4px;
  transition: background-color 0.3s, color 0.3s;
}

.back-button:hover {
  background-color: #333;
  color: white;
}

.congratulations-message {
  text-align: center;
  margin-top: 20px;
}

.big-text {
  font-size: 28px;
  margin: 5px 0;
}

.small-text {
  font-size: 18px;
  margin: 5px 0;
  color: #666;
}

.thank-you-text {
  font-size: 24px;
  margin: 10px 0;
  color: #333;
}
</style>
