<template>
    <div>
        <div>
            <h2>
                {{property.addressLineOne}}
                {{property.addressLineTwo}}
                {{property.city}}
                {{property.state}}
                {{property.zipCode}}
            </h2>
            <h3>
                Property Id Number:
                {{property.propertyId}}
                Landlord Id Number:
                {{property.landlordId}}
            </h3>
           <p>
            {{property.description}}
           </p>
           <div>
                Beds: 
                {{property.beds}}
            </div>
            <div>
                Baths: 
                {{property.baths}}
           </div>
           <div>
                Cost per month: 
                {{property.price}}
            </div>
            <div>
                Date available: 
                {{property.dateAvailable}}
            </div>
            <div v-for="image in property.images" v-bind:key="image.imageId">
                <img v-bind:src = "image.link" alt="Property Image"> 
            </div>           
        </div>
    </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";


export default {
    name: "property-detail",
    props: ["prop"],
    methods: {
        retrieveProperty(){
            propertyService.getProperty(this.$route.params.propertyId)
            .then(response => {
                this.$store.commit("SET_PROPERTY", response.data);
            })
            .catch(error =>{
                if (error.response && error.response.status === 404) {
                    alert("The property is not availalbe. It may have been deleted or you have entered an invalid Id.");
                    this.$router.push("/");
                }
            });
        }
    },
    created(){
        this.retrieveProperty();
    },
    computed: {
        property(){
            return this.$store.state.property;
        }
    }
}
</script>

<style>

</style>