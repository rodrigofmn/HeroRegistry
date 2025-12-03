import axios from "axios";

const api = axios.create({
  baseURL: "http://localhost:5253/api",
});

export default api;
