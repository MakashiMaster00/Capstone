

<template>
  <div id="app">
    <div id="navbar">
      <b-navbar fixed-top>
        <template #brand>
          <router-link :to="{ name: 'home'}">
          <img
            id="logo"
            src="../src/assets/images/logosingular.jpg"
            alt="Plant With Logo"
            
          />
          </router-link>
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
              <a v-if="$store.state.token == ''" class="button is-light">
                <router-link :to="{ name: 'register' }"> Sign up </router-link>
              </a>
              <a v-if="$store.state.token == ''" class="button is-light">
                <router-link :to="{ name: 'login' }">Login</router-link>
              </a>
              <a v-if="$store.state.token != ''" class="button is-light">
                <router-link :to="{ name: 'logout' }">Logout</router-link>
              </a>
            </div>
          </b-navbar-item>
        </template>
      </b-navbar>
    </div>

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
