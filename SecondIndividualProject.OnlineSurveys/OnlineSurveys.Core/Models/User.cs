using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string FirstName { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
