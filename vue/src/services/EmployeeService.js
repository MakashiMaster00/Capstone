import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    
    getEmployees(landlordId){
        return http.get(`/task/${landlordId}/employees`);
    },
    getEmployee(landlordId, employeeId){
        return http.get(`/task/${landlordId}/employee/${employeeId}`);
    },
    addEmployee(landlordId,employee){
        return http.post(`/task/${landlordId}/newemployee`, employee)
    },
    deleteEmployee(landlordId,employeeId){
        return http.delete(`/task/${landlordId}/employee/${employeeId}`)
    }
    

}