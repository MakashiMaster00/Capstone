<template>
  <div>
      Hi there!
      <div id="serviceRequests">
          <div v-for="task in tasks" v-bind:key="task.taskId">
            <router-link v-bind:to="{name: 'landlordTask', 
            params: { taskId: task.taskId },}">
            <h2>
                {{ task.taskId }}
                {{ task.status }}
            </h2>
            </router-link>
          </div>
      </div>
      <div id=Employees>
            <b-button tag="router-link" :to="{ name: 'addemployee' }" type="is-primary">
                Add a New Employee
            </b-button>
            <b-button tag="router-link" :to="{ name: 'removeemployee' }" type="is-primary">
                Remove an Employee
            </b-button>
          <div v-for="employee in employees" v-bind:key="employee.userId">
            <h2>
                {{ employee.username }}
            </h2>
          </div>
      </div>
  </div>
</template>

<script>
import taskService from "@/services/TaskService.js";
import employeeService from "@/services/EmployeeService.js";

export default {
    name: "maintance-landlord",
      data() {
    return {
      tasks: [],
      employees: []
    };
  },

  methods: {
    retrieveTasks() {
      taskService
        .getTasks()
        .then((response) => {
          this.tasks = response.data;

          console.log(this.$store.state.user.userId);
          this.tasks = this.tasks.filter(
            (task) => task.landlordId == this.$store.state.user.userId
          );
          console.log(this.tasks);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert("Tasks not found");
          }
          this.$router.push("/");
        });
    },
    retrieveEmployees() {
      employeeService
        .getEmployees(this.$store.state.user.userId)
        .then((response) => {
          this.employees = response.data;
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert("Employees not found");
          }
          this.$router.push("/");
        });
    },
  },
  created() {
    this.retrieveTasks();
    this.retrieveEmployees();
  },
}

</script>

<style>

</style>