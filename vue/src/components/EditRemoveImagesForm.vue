<template>
  <div>
    
    <b-field label="Add new Image Link">
      
        <b-input v-model="newImage.link"></b-input>
      </b-field>
      <b-button v-on:click="addImage()">Add Image</b-button>
    <div v-for="image in images" v-bind:key="image.imageId">
      <img v-bind:src="image.link" alt="" />
      <div>
        <b-button v-on:click="deleteImage(image.imageId, image.propertyId, image.thumbnail)">Delete Image</b-button>
        <b-button v-on:click="setThumbnail(image.thumbnail, image.propertyId, image.imageId, image.link)">Set as Thumbnail</b-button>
      </div>
    </div>
  </div>
</template>

<script>
import imageService from '@/services/ImageService.js'

export default {
  name: "EditRemoveImages",
  data() {
    return {
      images: [],
      image: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: false,
      },
      newImage: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: false,
      }
    };
  },
  methods: {
    retrieveImages() {
      imageService.getImages(this.$route.params.propertyId)
      .then(response => {
        this.images = response.data
        
      })
      
    },
    setThumbnail(thumbnail, propertyId, imageId, link){
      this.image.imageId = imageId;
      this.image.propertyId = propertyId;
      this.image.link = link;
      this.image.thumbnail = thumbnail;
      if (thumbnail) {
        return alert("This is already set as your thumbnail.")
      }
      imageService.setThumbnail(propertyId, imageId, this.image)
      .then(response => {
        if (response.status === 200) {
          alert("You successfully updated your thumbnail!");
          this.retrieveImages();
        }
      }
      )
      .catch(error => {
        if (error.response) {
          alert("There was an issue updating your thumbnail");
        }
        
      })

    },
    deleteImage(imageId, propertyId, thumbnail){
      if (thumbnail) {
        return alert("You must set another thumbnail before deleting this image")
      }
      if (confirm("Are you sure you want to delete this image?")) {
        imageService.deleteImage(propertyId, imageId)
          .then((response) => {
            if (response.status === 200) {
              alert("Image successfully deleted");
              this.retrieveImages();
            }
          })
          .catch((error) => {
            if (error.response) {
              alert(
                `Error deleting Image. Response received was ${error.response.statusText}`
              );
            }
          });
      }
    },
    addImage(){
      this.newImage.propertyId = Number(this.$route.params.propertyId);
      if (this.newImage.link == "") {
        return alert("Enter a link for an image")
      }
      imageService.addImage(this.$route.params.propertyId, this.newImage)
      .then(response => {
        if (response.status === 200) {
          alert("You successfully added an image!")
          this.retrieveImages();
          this.newImage.link = "";
        }
      }
      )
      .catch(error => {
        if (error.response) {
          alert("There was an issue adding your image")
        }
        
      })
    }
  },
  created() {
    this.retrieveImages();
  },
};
</script>

<style>
</style>