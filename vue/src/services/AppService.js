import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default{

    getApplications(appId){
        return http.get(`/application/${appId}`);
    },
    addApplication(app) {
        return http.post('/application', app)
    },
    approveApplication(app) {
        return http.put(`/application/${appId}/approve`, app)
    },
    rejectApplication() {
        return http.put(`/application/${appId}/reject`)
    }
}