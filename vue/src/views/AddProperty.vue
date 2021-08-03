

<template>
  <div>
    <section>
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
        <b-input v-model="property.state"></b-input>
      </b-field>
      <b-field label="Zip Code">
        <b-input maxlength = "5" v-model="property.zipCode"></b-input>
      </b-field>
      <b-field label="Beds">
        <b-input v-model="property.beds"></b-input>
      </b-field>
 
      <b-field label="Baths">
        <b-input v-model="property.baths"> </b-input>
      </b-field>
      <b-field label="Price">
        <b-input v-model="property.price"></b-input>
      </b-field>
      <b-field label="Date Available">
        <b-input type="date" v-model="property.dateAvailable"></b-input>
      </b-field>
        <b-field label="Description">
        <b-input maxlength ="200" type="textarea" v-model="property.description"></b-input>
      </b-field>
      <div class="buttons">
            <b-button style="background-color:powderblue" type="submit" expanded>Submit</b-button>
        </div>
    </section>
  </div>
</template>

<script>
export default {
  data() {
    return {
      property: {
        propertyId: 0,
        landlordId: 0,
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
      },
    };
  },
  
};
</script>

<style>
</style>