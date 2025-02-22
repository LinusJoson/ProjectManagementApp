// import { useEffect, useState } from "react";
// import axios from "axios";
/*
//#region Gammal kod
const ProjectList = () => {
    const [projects, setProjects] = useState([]);

    useEffect(() => {
        axios.get("http://localhost:5000/api/project")
            .then(response => setProjects(response.data))
            .catch(error => console.error("Error fetching projects:", error));
    }, []);

    return (
        <div>
            <h1>Project List</h1>
            <ul>
                {projects.map(project => (
                    <li key={project.id}>{project.name}</li>
                ))}
            </ul>
        </div>
    );
};

export default ProjectList;

//#endregion
*/

//#region Ny kod

import { useEffect, useState } from "react";
import { getProjects } from "../services/ProjectService";

const ProjectList = () => {
    const [projects, setProjects] = useState([]);

    useEffect(() => {
        getProjects()
            .then(setProjects)
            .catch(error => console.error("Error fetching projects:", error));
    }, []);

    return (
        <div>
            <h1>Project List</h1>
            <ul>
                {projects.length > 0 ? (
                    projects.map(project => (
                        <li key={project.id}>{project.name}</li>
                    ))
                ) : (
                    <p>No projects available.</p>
                )}
            </ul>
        </div>
    );
};

export default ProjectList;
//#endregion 
