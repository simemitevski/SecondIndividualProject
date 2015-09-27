using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public class Role
    {
        public Guid Id { get; protected set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
