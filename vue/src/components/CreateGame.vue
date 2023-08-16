<template>
  <div>
    <form class="form" v-if="!isLoading">
      <div class="form-group" id="formtitle">
        <label for="title">Title</label>
        <input type="text" v-model="NewGame.title" required />
      </div>
      <div class="form-group" id="duration">
        <label for="MaxDuration">Max Turns</label>
        <select v-model="NewGame.MaxTurns" required>
          <option value="15">1 Turn</option>
          <option value="30">5 Turn</option>
          <option value="45">10 Turn</option>
          <option value="60">15 Turn</option>
        </select>
      </div>
      <div class="buttons">
        <button @click="resetForm" type="button" id="cancel">Cancel</button>
        <button @click="createGame" type="button" id="createGame">
          <img v-if="isLoading" src="../img/StockFormLoading.webp"  alt="Loading" class="loading-image pulsate" />
          <span v-else>Create Game</span>
        </button>
      </div>
    </form>
    <img v-if="isLoading" src="../img/StockFormLoading.webp"  alt="Loading" class="loading-image pulsate" />
  </div>
</template>

<script>
export default {
  data() {
    return {
      Game: {
        title: "",
        MaxTurns: "",
        CurrentTurn: 1,
        IsInProgress: true
      },
      isLoading: false, // Initialize loading state
    };
  },
  methods: {
    async createGame() {
      this.isLoading = true; // Set loading state to true
      try {
        // Simulate loading with a timeout (2-3 seconds)
        await new Promise((resolve) => setTimeout(resolve, 2000 + Math.random() * 1000));
        this.$store.commit('CREATE_GAME', this.Game);
        this.$router.push('lobby');
      } finally {
        this.isLoading = false; // Reset loading state
      }
    },
    resetForm() {
      this.Game = {};
      this.$router.push('/');
    },
  },
};
</script>

<style scoped>
.form {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: 100%;
  max-width: 400px;
  margin: 0 auto;
  padding: 20px;
  background-color: #f5f5f5;
  border: 1px solid #ccc;
  border-radius: 10px;
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  transform: scale(1);
  box-shadow: 0 0 0 rgba(0, 0, 0, 0.2);
}

.form:hover {
  transform: scale(1.02);
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
}

.form-group {
  width: 100%;
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  font-weight: bold;
  margin-bottom: 5px;
}

.form-group input,
.form-group select {
  width: 100%;
  padding: 10px;
  border: 1px solid #ccc;
  border-radius: 5px;
}

.buttons {
  display: flex;
  justify-content: center;
  margin-top: 20px;
}

#cancel,
#createGame {
  padding: 10px 20px;
  margin: 0 10px;
  font-size: 16px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 5px;
  cursor: pointer;
  transition: background-color 0.3s ease;
}

#cancel:hover,
#createGame:hover {
  background-color: #0056b3;
}

@keyframes pulsate {
  0% {
    transform: scale(1);
  }
  50% {
    transform: scale(1.1);
  }
  100% {
    transform: scale(1);
  }
}

.pulsate {
  animation: pulsate 1.5s ease-in-out infinite;
}

.loading-image {
  display: block;
  margin: 0 auto;
  margin-top: 50px;
}
</style>