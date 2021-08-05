

<template>
  <div id="app">
    <div id="navbar">
      <b-navbar>
        <template #brand>
          <img
            id="logo"
            src="../src/assets/images/logosingular.jpg"
            alt="Plant With Logo"
          />
        </template>
        <template #start>
          <b-navbar-item id="homepage" tag="router-link" :to="{ path: '/' }">
            Home
          </b-navbar-item>
          <b-navbar-item tag="router-link" :to="{ name: 'addproperty' }">
            Add A Property
          </b-navbar-item>
          <b-navbar-item tag="router-link" :to="{ name: 'properties' }">
            View Listings
          </b-navbar-item>
          <b-navbar-dropdown label="Info">
            <b-navbar-item href="#"> About </b-navbar-item>
            <b-navbar-item href="#"> Contact </b-navbar-item>
          </b-navbar-dropdown>
          <b-navbar-item tag="div">
            <div class="buttons">
              <a class="button is-primary">
                <strong>Sign up</strong>
              </a>
              <a class="button is-light"> Log in </a>
            </div>
          </b-navbar-item>
        </template>
      </b-navbar>
    </div>

    <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"
      >Logout</router-link
    >
    <router-view />
  </div>
</template>

<style>
html,
body {
  padding: 0;
  margin: 0;
  width: 100%;
  height: 100%;
}
#navbar {
  position: fixed;
  margin: 0;
  padding: 0;
  width: 100%;
}
#registration {
  justify-content: right;
}
#logo {
  width: 125px;
}
</style>
