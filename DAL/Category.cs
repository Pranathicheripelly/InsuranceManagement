﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category
    {
        [Key]//[Key] is used to explicitly define or override the primary key property of an entity in Entity Framework
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        // Navigation property to link Category with Policies
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
