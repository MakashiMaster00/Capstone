<template>
    <div>
        <div>
            {{property.propertyId}}
            
        </div>
    </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";


export default {
    name: "property-detail",
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