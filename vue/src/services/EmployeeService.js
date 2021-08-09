import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    
    getEmployees(landlordId){
        return http.get(`/task/${landlordId}/employees`);
    },

}