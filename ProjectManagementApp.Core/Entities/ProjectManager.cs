using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagementApp.Core.Entities
{
    public class ProjectManager
    { 
    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // This is to make sure that the Id is auto-generated. This is because of the error message regarding the primary key not being set. Should hopefully fix the issue and make the migration work? Inshallah. 
        public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

        // Relationships
        public ICollection<Project> Projects { get; set; } = new List<Project>();

    }
}


