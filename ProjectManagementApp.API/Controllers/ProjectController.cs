using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApp.Core.Entities;
using ProjectManagementApp.Infrastructure.Data;

namespace ProjectManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Project

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects
                .AsNoTracking()
                .ToListAsync();
        }


        /* Old code for GET api/Project: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProject()
        {
            return await _context.Projects.ToListAsync();
        }
        */

        // GET: api/Project/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.Customer)
                .Include(p => p.ProjectManager)
                .Include(p => p.ServiceType)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // Old Code for GET api/Project/{id}:
        /*
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        */

        // POST: api/

        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            // Koppla relationer genom ID, undvik att skapa nya objekt
            var customer = await _context.Customers.FindAsync(project.CustomerId);
            var projectManager = await _context.ProjectManagers.FindAsync(project.ProjectManagerId);
            var serviceType = await _context.ServiceTypes.FindAsync(project.ServiceTypeId);

            if (customer == null || projectManager == null || serviceType == null)
            {
                return BadRequest("Invalid CustomerId, ProjectManagerId, or ServiceTypeId");
            }

            // Koppla entiteterna
            project.Customer = customer;
            project.ProjectManager = projectManager;
            project.ServiceType = serviceType;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }


        /* Old code for POST api/Project:
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject(Project project)
        {
            // Koppla relationer genom ID, undvik att skapa nya objekt
            
        var Customer = await _context.Customers.FindAsync(project.CustomerId);
            var ProjectManager = await _context.ProjectManagers.FindAsync(project.ProjectManagerId);
            var ServiceType = await _context.ServiceTypes.FindAsync(project.ServiceTypeId);

            if (Customer == null || ProjectManager == null || ServiceType == null)
            {
                return BadRequest("Invalid CustomerId, ProjectManagerId, or ServiceTypeId");
            }

            // Koppla entiteterna:
            project.Customer = Customer;
            project.ProjectManager = ProjectManager;
            project.ServiceType = ServiceType;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }
        */

        // PUT: api/Project/{id}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            var existingProject = await _context.Projects.FindAsync(id);
            if (existingProject == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(project.CustomerId);
            var projectManager = await _context.ProjectManagers.FindAsync(project.ProjectManagerId);
            var serviceType = await _context.ServiceTypes.FindAsync(project.ServiceTypeId);

            if (customer == null || projectManager == null || serviceType == null)
            {
                return BadRequest("Invalid CustomerId, ProjectManagerId, or ServiceTypeId");
            }

            // Uppdatera fält
            existingProject.Name = project.Name;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            existingProject.Status = project.Status;
            existingProject.TotalPrice = project.TotalPrice;
            existingProject.CustomerId = project.CustomerId;
            existingProject.ProjectManagerId = project.ProjectManagerId;
            existingProject.ServiceTypeId = project.ServiceTypeId;

            _context.Entry(existingProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Old code for PUT api/Project/{id}:
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }
            _context.Entry(project).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Projects.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    {
                        throw;
                    }
                }
            }
            return NoContent();
        }
        */
        // DELETE: api/Project/{id}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Old code for DELETE api/Project/{id}:
        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
    }
}

/* What this code does:
/* Controller for the API managing projects in the database.
 * (Should fix the API...?)
 * GET: GetProjects() – Retrieves all projects without tracking them in EF Core.
 * GET: GetProject(int id) – Retrieves a specific project along with its related entities (Customer, ProjectManager, ServiceType).
 * POST: CreateProject(Project project) – Creates a new project and associates it with existing related entities using their IDs.
 * PUT: UpdateProject(int id, Project project) – Updates an existing project. Only specified fields are updated, and relationships are assigned via IDs.
 * DELETE: DeleteProject(int id) – Deletes a project from the database if it exists.
 */
