<template>
  <div class="dice">
    <img :src="getImagePath()" alt="Dice" />
  </div>
</template>

<script>
export default {
  props: {
    value: {
      type: Number,
      required: true,
    },
  },
  methods: {
    getImagePath() {
      const imageMap = {
        1: "dice-1.svg",
        2: "dice-2.svg",
        3: "dice-3.svg",
        4: "dice-4.svg",
        5: "dice-5.svg",
        6: "dice-6.svg",
      };
      return require(`@/img/${imageMap[this.value]}`);
    },
  },
};
</script>

<style scoped>
.dice {
  width: 50px;
  height: 50px;
}
</style>