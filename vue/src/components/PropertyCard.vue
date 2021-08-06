<template>
  <div id="card" class="container">
    <div
      class="slideshow"
      v-for="image in property.images"
      v-bind:key="image.imageId"
    >
      <img v-bind:src="image.link" alt="Property Image" />
    </div>
    <div class="info details">
      <h2 id="address" class="address">
        {{ property.addressLineOne }}
        {{ property.addressLineTwo }}
        {{ property.city }}
        {{ property.state }}
        {{ property.zipCode }}
      </h2>
      <div class="specifics">
        <p id="beds">
          Beds:
          {{ property.beds }}
        </p>
        <p id="baths">
          Baths:
          {{ property.baths }}
        </p>
        <p id="cost">
          Cost per month:
          {{ property.price }}
        </p>
        <p id="date">
          Date available:
          {{ property.dateAvailable }}
        </p>
        <p id="description">
          {{ property.description }}
        </p>
      </div>
      <div class="contact">
        <img src="../assets/images/homepage.jpg"/>
        <div id="contactinfo">
            Contact:
            {{ property.contact }}
        </div>
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
    retrieveProperty() {
      propertyService
        .getProperty(this.$route.params.propertyId)
        .then((response) => {
          this.$store.commit("SET_PROPERTY", response.data);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert(
              "The property is not available. It may have been deleted or you have entered an invalid Id."
            );
            this.$router.push("/");
          }
        });
    },
  },
  created() {
    this.retrieveProperty();
  },
  computed: {
    property() {
      return this.$store.state.property;
    },
  },
};
</script>

<style>
#card {
  padding-top: 50px;
  padding-left: 10px;
  max-width: 100%;
}
.container {
  display: grid;
  grid-template-columns: 0.4fr 0.6fr;
  grid-template-rows: 1fr;
  gap: 0px 0px;
  grid-template-areas: "slideshow info";
}
.details {
  display: grid;
  grid-template-columns: .4fr .6fr;
  grid-template-rows: .1fr .9fr;
  grid-template-areas:
    "address address"
    "specifics contact";
}
#address {
  color: #468189;
  font-size: 2vw;
  border-bottom: solid 2px #031926;
  grid-area: address;
  margin-bottom: 15px;
}
.specifics {
    grid-area: specifics;
}
.contact {
    grid-area: contact;
    height: 750px;
    background-size: cover;
}
#contactinfo {
    transform: rotate(-35deg);
    float: initial;
    text-align: center;
    position: absolute;
    bottom: 58%;
    left: 72%;
}
#description {
  padding-top: 10px;
  padding-right: 25px;
  color: #9dbebb;
}
#beds {
  color: #468189;
  font-size: 1vw;
}
#baths {
  color: #468189;
  font-size: 1vw;
}
#cost {
  color: #468189;
  font-size: 1vw;
}
#date {
  color: #468189;
  font-size: 1vw;
}
</style>