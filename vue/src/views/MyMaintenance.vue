<template>
  <div>
    <landlord-maintenance v-if="$store.state.user.role == 'landlord'"/>
    <employee-maintenance v-if="$store.state.user.role == 'employee'"/>
  </div>
</template>

<script>
import EmployeeMaintenance from '../components/EmployeeMaintenance.vue'
import LandlordMaintenance from '../components/LandlordMaintenance.vue'
export default {
    components: {
        LandlordMaintenance,
        EmployeeMaintenance
    }
}
</script>

<style>
html {
  padding-top: 50px;
}
</style>
