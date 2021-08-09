<template>
  <div id="landlord">
      <div id="pending">
        <h1 class="title">Pending</h1>
          <div v-for="task in tasks" v-bind:key="task.taskId">
            <router-link v-bind:to="{name: 'landlord-task', 
            params: { taskId: task.taskId }}">
            <h2>
                {{ task.taskId }}
                {{ task.taskStatus }}
            </h2>
            </router-link>
          </div>
      </div>
      <div id="scheduled">
        <h1 class="title">Scheduled</h1>
        <div></div>
      </div>
      <div id="completed">
        <h1 class="title">Completed</h1>
        <div></div>
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
        filtedredTasks: [],
        pendingTasks: [],
        scheduledTasks: [],
        completedTasks: [],
        employees: []
      };
  },

  methods: {
    retrieveTasks() {
      taskService
        .getTasks()
        .then((response) => {
          this.filtedredTasks = response.data.filter((task) => task.landlordId == this.$store.state.user)
         this.$store.commit("SET_TASKS", this.filtedredTasks);
          console.log(this.$store.state.tasks);
          
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert("Tasks not found");
          }
          this.$router.push("/");
        });
       console.log(this.filtedredTasks)
    },
    filterTasks() {
      
      this.pendingTasks = this.tasks.filter(
            (task) => task.status == 'Pending'
          );
      this.scheduledTasks = this.tasks.filter(
            (task) => task.status == 'Scheduled'
          );
      this.completedTasks = this.tasks.filter(
            (task) => task.status == 'Completed'
          );
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
  computed: {
    tasks() {
      return this.$store.state.tasks;
    }
  },
  created() {
    this.retrieveTasks();
    this.filterTasks();
    //this.retrieveEmployees();
  },
}

</script>

<style scoped>
#landlord {
  padding-top: 50px;
  display: grid; 
  grid-template-columns: 1fr 1fr 1fr; 
  grid-template-rows: 1fr 1fr; 
  gap: 0px 0px; 
  grid-template-areas: 
    "pending scheduled completed"
    ". . .";
}
#pending {
  grid-area: pending;
  border-right: solid 1px #031926;
}
#scheduled {
  grid-area: scheduled;
  border-right: solid 1px #031926;
}
#completed {
  grid-area: completed;
}
.title {
  color: #468189;
  font-size: 2vw;
  text-align: center;
  text-decoration: underline #031926;
}
</style>