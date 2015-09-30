using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSurveys.Core.Models
{
    public class BaseModel
    {
        public Guid Id { get; protected set; }
    }
}
