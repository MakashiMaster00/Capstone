import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    
    getTasks(){
        return http.get('/task');
    },

    getTask(taskId){
        return http.get(`/task/${taskId}`);
    },

    addTask(task) {
        return http.post('/task', task)
    },

    updateTask(task) {
        return http.put(`/task/${task.taskId}`, task)
    },

    deleteTask(taskId){
        return http.delete(`/task/${taskId}`)
    }

}