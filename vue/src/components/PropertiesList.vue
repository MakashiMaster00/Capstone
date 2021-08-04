<template>
<div>
    <div v-for="prop in properties" v-bind:key="prop.propertyId" >
          <router-link v-bind:to="{name: 'Card', params: {propertyId: prop.propertyId}}">
        <div>
            <div>
                <img v-bind:src = "prop.thumbnail" alt="Property Thumbnail Image"> 
            </div>
            <h2>
                {{prop.addressLineOne}}
                {{prop.addressLineTwo}}
                {{prop.city}}
                {{prop.state}}
                {{prop.zipCode}}
            </h2>
              {{prop.description}}
        </div>

        </router-link>
    </div> 
</div>
</template>

<script>
import propertyService from '@/services/PropertyService.js'
//import propertyCard from '@/components/PropertyCard.vue'

export default {
    
    name: "properties-list",
   // components: {
     //   propertyCard
        
    //},
   data() {
       return {
           properties: []
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
    created(){
        this.retrieveProperties();
    }
}
</script>

<style>

</style>