<template>
  <div>
    <form>
      <b-field v-show="this.$store.state.showButton" label="Add Thumbnail">
        <b-input v-model="imageThumbnail.link"></b-input>
      </b-field>
      <b-field v-show="!this.$store.state.showButton" label="Add Image">
        <b-input v-model="image.link"></b-input>
      </b-field>
    </form>
  </div>
</template>

<script>
export default {
  data() {
    return {
      imageThumbnail: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: 1,
      },
      image: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: 1,
      },
    };
  },
  methods() {
      if(this.$store.state.showButton == true) {
          this.$store.commit("ADD_PROPERTIES_IMAGE", this.imageThumbnail)
      }
      else{
          this.$store.commit("ADD_PROPERTIES_IMAGE", this.image)
      }
  }
};
</script>

<style>
</style>