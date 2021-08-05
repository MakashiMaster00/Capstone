<template>
<div>
    <div class="biggrid">
      <div class="search">
        <img id="logo" src="../assets/images/logo.jpg" alt="logo" />
        <div id="searchbar" class="container">
          <div class="searchimputs">
            <b-field class="inputs">
              <b-input placeholder="City" v-model="filter.city" rounded></b-input>
            </b-field>
            <b-field class="inputs">
              <b-select v-model="filter.state" rounded expanded>
                <option value="State">State</option>
                <option value="AL">AL</option>
                <option value="AK">AK</option>
                <option value="AZ">AZ</option>
                <option value="AR">AR</option>
                <option value="CA">CA</option>
                <option value="CO">CO</option>
                <option value="CT">CT</option>
                <option value="DE">DE</option>
                <option value="DC">DC</option>
                <option value="FL">FL</option>
                <option value="GA">GA</option>
                <option value="HI">HI</option>
                <option value="ID">ID</option>
                <option value="IL">IL</option>
                <option value="IN">IN</option>
                <option value="IA">IA</option>
                <option value="KS">KS</option>
                <option value="KY">KY</option>
                <option value="LA">LA</option>
                <option value="ME">ME</option>
                <option value="MD">MD</option>
                <option value="MA">MA</option>
                <option value="MI">MI</option>
                <option value="MN">MN</option>
                <option value="MS">MS</option>
                <option value="MO">MO</option>
                <option value="MT">MT</option>
                <option value="NE">NE</option>
                <option value="NV">NV</option>
                <option value="NH">NH</option>
                <option value="NJ">NJ</option>
                <option value="NM">NM</option>
                <option value="NY">NY</option>
                <option value="NC">NC</option>
                <option value="ND">ND</option>
                <option value="OH">OH</option>
                <option value="OK">OK</option>
                <option value="OR">OR</option>
                <option value="PA">PA</option>
                <option value="RI">RI</option>
                <option value="SC">SC</option>
                <option value="SD">SD</option>
                <option value="TN">TN</option>
                <option value="TX">TX</option>
                <option value="UT">UT</option>
                <option value="VT">VT</option>
                <option value="VA">VA</option>
                <option value="WA">WA</option>
                <option value="WV">WV</option>
                <option value="WI">WI</option>
                <option value="WY">WY</option>
              </b-select>
            </b-field>
            <b-field class="inputs">
              <b-input v-model="filter.zipCode" placeholder="Zip" rounded></b-input>
            </b-field>
          </div>
          <div class="checkboxes">
            <div id="beds">
              <div class="block">
                Beds
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="1">
                    1
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="2">
                    2
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="3">
                    3
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="4">
                    4+
                </b-checkbox>
              </div>
            </div>
            <div id="baths">
              <div class="block">
                Baths
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="1">
                    1
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="1.5">
                    1.5
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="2">
                    2
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="2.5">
                    2.5
                </b-checkbox>
                <b-checkbox type="is-black" v-model="checkboxGroup"
                    native-value="3">
                    3+
                </b-checkbox>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="results">
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
    </div>
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";
//import propertyCard from '@/components/PropertyCard.vue'

export default {
    
    name: "properties-list",
   // components: {
     //   propertyCard
        
    //},
   data() {
       return {
           filter: {
            addressLineOne: "",
            city: "",
            state: "State",
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
            if (this.filter.state != "State") {
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
</script>

<style scoped>
#plantimage {
  height: auto;
  width: 100%;
}
.search {
  text-align: center;
  width: 100%;
  height: auto;
  background-image: url("../assets/images/background.jpg");
  background-size: 100% 100%;
}
#searchbar {
  padding-top: 50px;
  padding-left: 50px;
  max-width: 100%;
}
#logo {
  padding-top: 5%;
  height: 50%;
  width: auto;
  align-items: center;
}
.inputs {
  padding-bottom: 25px;
}
#baths {
  background-color: white;
  padding-top: 9px;
  height: 18%;
  width: 65%;
  border-radius: 25px;
}
#beds {
  background-color: white;
  padding-top: 9px;
  height: 18%;
  width: 65%;
  border-radius: 25px;
  margin-bottom: 37px;
}
.container {
  display: grid;
  grid-template-columns: 1fr 1fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "searchimputs radiobuttons";
  column-gap: 75px;
}
.biggrid {
 display: grid; 
  grid-template-columns: 1fr; 
  grid-template-rows: .20fr .80fr; 
  gap: 0px 0px; 
  grid-template-areas: 
    "search" 
    "results";
  grid-row-gap: 50px;
}
</style>