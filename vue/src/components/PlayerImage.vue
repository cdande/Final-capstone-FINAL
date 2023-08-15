<template>
  <div class ="root">
    <div v-for="(player, index) in this.$store.state.players" v-bind:key="player.id">
      <img
        class="playerToken"
        v-if="player.position === position"
        :src="player.imageSource"
        alt="hello"
        :style="{left:`${index*10}px`}"
      />
    </div>
  </div>
</template>

<script>
export default {
    props:{
        position:{}
    }
};
</script>

<style>
.playerToken{
 width: 30px;
  height: 30px;
  border: 2px solid black;
  border-radius: 5px;
position:absolute;
 z-index: 100;
 top: 45px
}
</style>