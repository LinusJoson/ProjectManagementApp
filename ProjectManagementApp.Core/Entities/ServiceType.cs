using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Core.Entities
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal HourlyRate { get; set; }

        // Relationships
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
