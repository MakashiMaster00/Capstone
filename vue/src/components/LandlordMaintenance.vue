<template>
  <div id="landlord">
      <div id="pending">
        <h1 class="title">Pending</h1>
          <div v-for="task in pendingTasks" v-bind:key="task.taskId">
            <router-link v-bind:to="{name: 'landlord-task', params: {taskId: task.taskId}}">
              <div class="propID">
                {{task.propertyId}}: 
                {{task.dateEntered}}
                {{task.isUrgent}}
              </div>
              <div class="desc">
                {{task.taskDescription}}
              </div>
            </router-link>
          </div>
      </div>
      <div id="scheduled">
        <h1 class="title">Scheduled</h1>
        <div v-for="task in scheduledTasks" v-bind:key="task.taskId">
            <router-link v-bind:to="{name: 'landlord-task', params: {taskId: task.taskId}}">
              <div class="propID">
                {{task.propertyId}}: 
                {{task.dateEntered}}
                {{task.isUrgent}}
              </div>
              <div class="desc">
                {{task.taskDescription}}
              </div>
            </router-link>
          </div>
      </div>
      <div id="completed">
        <h1 class="title">Completed</h1>
        <div v-for="task in completedTasks" v-bind:key="task.taskId">
            <router-link v-bind:to="{name: 'landlord-task', params: {taskId: task.taskId}}">
              <div class="propID">
                {{task.propertyId}}: 
                {{task.dateEntered}}
                {{task.isUrgent}}
              </div>
              <div class="desc">
                {{task.taskDescription}}
              </div>
            </router-link>
          </div>
      </div>
  </div>
</template>

<script>
import taskService from "@/services/TaskService.js";


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
          this.filtedredTasks = response.data.filter((task) => task.landlordId == this.$store.state.user.userId)
          this.filterTasks(this.filtedredTasks);
        })
        .catch((error) => {
          if (error.response && error.response.status === 404) {
            alert("Tasks not found");
          }
          this.$router.push("/");
        })
    },
    filterTasks(tasks) {
      console.log(tasks)
      this.pendingTasks = tasks.filter(
            (task) => task.taskStatus == "Pending"
          );
      this.scheduledTasks = tasks.filter(
            (task) => task.taskStatus == 'Scheduled'
          );
      this.completedTasks = tasks.filter(
            (task) => task.taskStatus == 'Completed'
          );
    },
    
  },
  computed: {
    tasks() {
      return this.$store.state.tasks;
    }
  },
  created() {
    this.retrieveTasks();
    
    //this.retrieveEmployees();
  },
}

</script>

<style scoped>
#landlord {
  padding-top: 50px;
  display: grid; 
  grid-template-columns: 1fr 1fr 1fr; 
  grid-template-rows: 1fr; 
  gap: 0px 0px; 
  grid-template-areas: 
    "pending scheduled completed";
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
.propID {
  font-size: 1.5vw;
  color: #468189;
  display: inline;
}
.desc {
  font-size: 1.2vw;
  color: #468189
}
</style>