using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ProjectManagementApp.Core.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Phone]
        public string ContactPhone { get; set; }

        // Relationships
        public ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
