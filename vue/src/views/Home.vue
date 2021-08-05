<template>
  <div class="home">
    <div class="search">
      <img id="logo" src="../assets/images/logo.jpg" alt="logo" />
      <div id="searchbar" class="container">
        <div class="searchimputs">
          <b-field class="inputs">
            <b-input placeholder="City" rounded></b-input>
          </b-field>
          <b-field class="inputs">
            <b-select placeholder="State" rounded expanded>
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
            <b-input placeholder="Zip" rounded></b-input>
          </b-field>
        </div>
        <div class="radiobuttons">
          <div id="beds">
            Beds
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="1"
            >
              1
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="2"
            >
              2
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="3"
            >
              3
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="4"
            >
              4
            </b-radio>
          </div>
          <div id="baths">
            Baths
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="1"
            >
              1
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="2"
            >
              1.5
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="3"
            >
              2
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="4"
            >
              2.5
            </b-radio>
            <b-radio
              type="is-black"
              size="is-medium"
              v-model="radio"
              name="name"
              native-value="5"
            >
              3+
            </b-radio>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "home",
};
</script>

<style scoped>
#plantimage {
  height: auto;
  width: 100%;
}
.search {
  width: 100%;
  height: 700px;
  background-image: url("../assets/images/background.jpg");
  background-size: 100% 100%;
}
#searchbar {
  padding-top: 50px;
  padding-left: 50px;
  max-width: 100%;
}
#logo {
  padding: 5% 0 0 43%;
  height: 300px;
  width: auto;
  justify-content: center;
}
.inputs {
  padding-bottom: 25px;
}
#baths {
  background-color: white;
  height: 18%;
  width: 100%;
  border-radius: 25px;
}
#beds {
  background-color: white;
  height: 18%;
  width: 100%;
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
</style>
