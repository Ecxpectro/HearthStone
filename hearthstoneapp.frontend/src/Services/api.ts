import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:7113/api',
});

export default api;
