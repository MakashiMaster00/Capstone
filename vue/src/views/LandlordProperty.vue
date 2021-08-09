<template>
  <div>
    <b-button tag="router-link" :to="{ name: 'myproperties' }" type="is-primary"
      >Back</b-button
    >
    <b-button tag="router-link" :to="{ name: 'editproperty' }" type="is-primary"
      >Edit Property</b-button
    >
    <b-button v-on:click="deleteProperty" type="is-primary"
      >Delete Property</b-button
    >
    <b-button tag="router-link" :to="{ name:'editimages'}" type="is-primary"
      >Edit/Remove Images</b-button
    >
    <property-card />
  </div>
</template>

<script>
import PropertyCard from "@/components/PropertyCard.vue";
import propertyService from "@/services/PropertyService.js";
export default {
  components: {
    PropertyCard,
  },
  methods: {
    deleteProperty() {
      if (confirm("Are you sure you want to delete this property?")) {
        propertyService
          .deleteProperty(this.$route.params.propertyId)
          .then((response) => {
            if (response.status === 200) {
              alert("Property successfully deleted");
              this.$router.push("/myProperties");
            }
          })
          .catch((error) => {
            if (error.response) {
              alert(
                `Error deleting property. Response received was ${error.response.statusText}`
              );
            }
          });
      }
    },
  },
};
</script>

<style>
</style>