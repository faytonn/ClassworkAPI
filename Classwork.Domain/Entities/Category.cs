﻿using Classwork.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classwork.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; } = new List<Product>();

    }
}