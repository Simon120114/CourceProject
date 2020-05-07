﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sima_Web.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Quarters = new HashSet<Quarter>();
            Swaps = new HashSet<Swap>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int AddressAreaId { get; set; }
        public string AddressStreet { get; set; }

        public virtual ICollection<Quarter> Quarters { get; set; }
        public virtual ICollection<Swap> Swaps { get; set; }


    [NotMapped]
    public string FullName => $"{MiddleName} {FirstName[0]}.{LastName[0]}.";

  }
}
