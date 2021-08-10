<template>
  <div>
      <h2>
      Task Id: {{ task.taskId }}
      </h2>
      <p>Employee Name: {{ employee.username }}</p>
      <p>Property Id: {{ task.propertyId }}</p>
      <p>Is Urgent: {{ task.isUrgent }}</p>
      <p>Task Description: {{ task.taskDescription }}</p>
      <p>Date Entered: {{ task.dateEntered }}</p>
      <p>Date Scheduled: {{ task.dateScheduled }}</p>
      <p>Task Status: {{ task.taskStatus }}</p>

      <b-button tag="router-link" :to="{ name: 'editrequest' }" type="is-primary">
            Edit Request
        </b-button>
  </div>
</template>

<script>
import taskService from "@/services/TaskService.js";
import employeeService from "@/services/EmployeeService.js";

export default {
  name: "landlord-task",
  data() {
    return {
      task: {},
      employee: {}
    }
  },
  methods: {
    retrieveTask() {
      taskService
        .getTask(this.$route.params.taskId)
        .then((response) => {
          this.$store.commit("SET_TASK", response.data);
          this.task = this.$store.state.task;
          this.retrieveEmployee();
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert(
              "The task is not available. It may have been deleted or you have entered an invalid Id."
            );
            this.$router.push("/myMaintenance");
          }
        });
    },
    retrieveEmployee() {
      employeeService
        .getEmployee(this.$store.state.user.userId, this.$store.state.task.employeeId)
        .then((response) => {
          this.employee = response.data;
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            this.employee.username = "No employee scheduled."
          }
        });
    },
},
// computed: {
//     task() {
//       return this.$store.state.task;
//     }
// },
created() {
    this.retrieveTask();
    //this.retrieveEmployee();
},
}
</script>

<style>

</style>