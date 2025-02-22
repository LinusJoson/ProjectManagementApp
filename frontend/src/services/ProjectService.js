import axios from "axios";
import API_BASE_URL from "../config";

const getProjects = async () => {
    const response = await axios.get(`${API_BASE_URL}/project`);
    return response.data;
};

const createProject = async (project) => {
    const response = await axios.post(`${API_BASE_URL}/project`, project);
    return response.data;
};

export { getProjects, createProject };
