using Classwork.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } 
    }
}
