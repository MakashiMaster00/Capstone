

<template>
  <div>
    <form>
      <b-field label="Street Address">
        <b-input v-model="property.addressLineOne"></b-input>
      </b-field>

      <b-field label="Address Line 2 (Optional)">
        <b-input v-model="property.addressLineTwo"> </b-input>
      </b-field>
      <b-field label="City">
        <b-input v-model="property.city"></b-input>
      </b-field>
      <b-field label="State">
        <b-input maxlength = '2' v-model="property.state"></b-input>
      </b-field>
      <b-field label="Zip Code">
        <b-input maxlength = "5" v-model="property.zipCode"></b-input>
      </b-field>
      <b-field label="Beds">
        <b-input v-model.number="property.beds"></b-input>
      </b-field>
 
      <b-field label="Baths">
        <b-input v-model.number="property.baths"> </b-input>
      </b-field>
      <b-field label="Price">
        <b-input v-model.number="property.price"></b-input>
      </b-field>
      <b-field label="Date Available">
        <b-input type="date" v-model="property.dateAvailable"></b-input>
      </b-field>
      <span>
        <b-field  label="Add Thumbnail (Required)">
        <b-input v-model="imageThumbnail.link"></b-input>
      </b-field>
      <b-field  label="Add Image (Optional)">
        <b-input v-model="image.link"></b-input>
      </b-field>
        
      </span>
        <b-field label="Description">
        <b-input maxlength ="200" type="textarea" v-model="property.description"></b-input>
      </b-field>
      <div class="buttons">
            <b-button v-on:click.prevent="addProperty" style="background-color:powderblue" type="submit" expanded>Submit</b-button>
        </div>
    </form>
  </div>
</template>

<script>
import propertyService from '@/services/PropertyService.js'

export default {
  data() {
    return {
      property: {
        propertyId: 0,
        landlordId: 1,
        description: "",
        addressLineOne: "",
        addressLineTwo: "",
        city: "",
        state: "",
        zipCode: "",
        price: 0,
        dateAvailable: "",
        available: true,
        beds: 0,
        baths: 0,
        images: [],
        thumbnail: ""
      },
      imageThumbnail: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: true
      },
      image: {
        imageId: 0,
        propertyId: 0,
        link: "",
        thumbnail: false
      },
    
    };
  },
  methods: {
    addProperty(){
      this.property.thumbnail = this.imageThumbnail.link
      this.property.images.push(this.imageThumbnail);
      if (this.image.link != "") {
        this.property.images.push(this.image);
      }
      
      propertyService.addProperty(this.property)
      .then(response => {
        if (response.status === 200) {
          alert("You successfully added a property!")
          this.$router.push({name: 'login'})
        }
      }
      )
      .catch(error => {
        if (error.response) {
          alert("There was an issue adding your property")
        }
        
      })
    }
  }
  
};
</script>

<style>
</style>