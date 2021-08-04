

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
        <b-button tag="router-link" :to="{ name: 'images' }"  type="is-primary" style="background-color:powderblue">Add {{this.$store.state.showButton ? 'Thumbnail' : 'Image'}}</b-button>
        
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
      }
    };
  },
  methods: {
    addProperty(){
      this.property.images = this.$store.state.property.images;
      this.property.thumbnail = this.$store.state.property.thumbnail;
      console.log(this.property.images[0]);
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