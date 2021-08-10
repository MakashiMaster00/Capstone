<template>
  <div>
    <b-field label="Is the request urgent?">
      <b-checkbox v-on:click="this.task.isUrgent = !this.task.isUrgent"></b-checkbox>
    </b-field>
    <b-field label="Date Scheduled">
      <b-input type="date" v-model="task.dateScheduled"></b-input>
    </b-field>

    <b-field label="Description">
      <b-input
        maxlength="200"
        type="textarea"
        v-model="task.taskDescription"
      ></b-input>
    </b-field>
    <b-button
      v-on:click.prevent="addTask"
      style="background-color: powderblue"
      type="submit"
      expanded
      >Submit</b-button
    >
  </div>
</template>

<script>
import propertyService from "@/services/PropertyService.js";
import taskService from '@/services/TaskService.js'
export default {
  data() {
    return {
      task: {
        taskId: 0,
        employeeId: 0,
        propertyId: 0,
        isUrgent: false,
        taskDescription: "",
        dateEntered: "",
        dateScheduled: "",
        taskStatus: "",
      },
      
    };
  },
  methods: {
    getPropertyId() {
        
      propertyService
        .getPropertyByRenterId(this.$store.state.user.userId)
        .then((response) => {
          this.task.propertyId = response.data.propertyId;
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert("Property not found");
          }
          //this.$router.push("/");
        });
        console.log(this.task.propertyId);
    },
    addTask(){
        this.getPropertyId();
        this.getPropertyId();
        taskService.addTask(this.task)
        .then(response => {
        if (response.status === 200) {
          alert("You successfully submitted a request!")
          //this.$router.push({name: 'home'})
        }
      }
      )
      .catch(error => {
        if (error.response) {
          alert("There was an issue submitting your request")
        }
        
      })
    }
  },
};
</script>

<style>
</style>