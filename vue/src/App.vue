

<template>
  <div id="app">
    <div id="nav">
      <div id="app" class="container">
        <b-navbar>
          <template #brand>
            <b-navbar-item tag="router-link" :to="{ path: '/' }">
              <img
                src="https://thumbs.dreamstime.com/b/apartment-building-logo-design-inspiration-vector-template-apartment-logo-icon-design-vector-template-158106696.jpg"
                alt="Lightweight UI components for Vue.js based on Bulma"
              />
            </b-navbar-item>
          </template>
          <template #start>
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
          </template>

          <template #end>
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

      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        >Logout</router-link
      >
    </div>
    <router-view />
  </div>
</template>
