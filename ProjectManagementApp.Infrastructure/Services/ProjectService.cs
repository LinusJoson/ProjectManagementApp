using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagementApp.Core.Entities;
using ProjectManagementApp.Core.Interfaces;
using ProjectManagementApp.Infrastructure.Repositories;

namespace ProjectManagementApp.Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _projectRepository.GetAllAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetByIdAsync(id);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            await _projectRepository.AddAsync(project);
            return project;
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            return await _projectRepository.UpdateAsync(project);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteAsync(id);
        }
    }
}