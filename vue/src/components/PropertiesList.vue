<template>
<<<<<<< HEAD
  <div>
    <div v-for="prop in properties" v-bind:key="prop.propertyId">
      <router-link
        v-bind:to="{ name: 'Card', params: { propertyId: prop.propertyId } }"
      >
=======
<div>
    <div>
        <h2>Search Properties by Location</h2>
        <b-field label="Enter street address: ">
            <b-input id="streetFilter" v-model="filter.addressLineOne"></b-input>
        </b-field>
        <b-field label="Enter city: ">
            <b-input id="cityFilter" v-model="filter.city"></b-input>
        </b-field>
        <b-field label="Enter state (use abbreviation): ">
            <b-input maxlength = '2' id="stateFilter" v-model="filter.state"></b-input>
        </b-field>
        <b-field label="Enter zip code: ">
            <b-input id="zipCodeFilter" v-model="filter.zipCode"></b-input>
        </b-field>
    </div>
    <div>
        <h2>Search Properties by Specifications</h2>
        <b-field label="Enter number of beds: ">
            <b-input id="bedFilter" v-model="filter.beds"></b-input>
        </b-field>
        <b-field label="Enter number of baths: ">
            <b-input id="bathFilter" v-model="filter.baths"></b-input>
        </b-field>
    </div>
    <div v-for="prop in filteredProperties" v-bind:key="prop.propertyId" >
          <router-link v-bind:to="{name: 'Card', params: {propertyId: prop.propertyId}}">
>>>>>>> 654ee1c6f73a3c13454b10a97f39b52054d9a4a5
        <div>
          <div>
            <img v-bind:src="prop.thumbnail" alt="Property Thumbnail Image" />
          </div>
          <h2>
            {{ prop.addressLineOne }}
            {{ prop.addressLineTwo }}
            {{ prop.city }}
            {{ prop.state }}
            {{ prop.zipCode }}
          </h2>
          {{ prop.description }}
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";
//import propertyCard from '@/components/PropertyCard.vue'

export default {
<<<<<<< HEAD
  name: "properties-list",
  // components: {
  //   propertyCard

  //},
  data() {
    return {
      properties: [],
    };
  },

  methods: {
    retrieveProperties() {
      propertyService
        .getProperties()
        .then((response) => {
          this.properties = response.data;
          console.log(this.properties);
          
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert("Properties not found");
          }
          this.$router.push("/");
        });
    },
  },
  created() {
    this.retrieveProperties();
  },
};
=======
    
    name: "properties-list",
   // components: {
     //   propertyCard
        
    //},
   data() {
       return {
           filter: {
            addressLineOne: "",
            city: "",
            state: "",
            zipCode: "",
            beds: "",
            baths: ""
        },
           properties: [],
       }
   },
    
    methods: {
        retrieveProperties(){
            propertyService.getProperties()
            .then(response => {
                this.properties = response.data
            })
            .catch(error => {
                if (error.response && error.response.status === 404) {
                    alert("Properties not found")
                }
                this.$router.push("/")
                
            }
            )
        }
    },
    computed: {
        filteredProperties(){
            let filteredProperties = this.properties;
            if (this.filter.addressLineOne != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.addressLineOne.toLowerCase().includes(this.filter.addressLineOne.toLowerCase())
                );
            }
            if (this.filter.city != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.city.toLowerCase().includes(this.filter.city.toLowerCase())
                );
            }
            if (this.filter.state != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.state.toUpperCase().includes(this.filter.state.toUpperCase())
                );
            }
            if (this.filter.zipCode != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.zipCode.toUpperCase().includes(this.filter.zipCode.toUpperCase())
                );
            }
            if (this.filter.beds != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.beds == this.filter.beds);
            }
            if (this.filter.baths != "") {
                filteredProperties = filteredProperties.filter((prop) =>
                    prop.baths == this.filter.baths);
            }
            return filteredProperties;
        }
    },
    created(){
        this.retrieveProperties();
    }
}
>>>>>>> 654ee1c6f73a3c13454b10a97f39b52054d9a4a5
</script>

<style>
</style>