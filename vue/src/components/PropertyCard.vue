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
             {{property.propertyId}}
            {{property.landlordId}}
            </h3>
           <p>
            {{property.description}}
           </p>
           <div>
             {{property.beds}}
            {{property.baths}}
           </div>
            {{property.price}}
            {{property.dateAvailable}}
            {{property.available}}
            <div>
                 {{property.thumbnail}}
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