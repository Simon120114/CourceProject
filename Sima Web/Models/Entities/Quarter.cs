﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using Sima_Web.Properties;


namespace Sima_Web.Models
{
  public partial class Quarter
  {
    public Quarter() { Swaps = new HashSet<Swap>(); }

    public int Id          { get; set; }
    public int TypeHouseId { get; set; }

    [Display(ResourceType = typeof(Resources), Name = "Quarter_Size_QuarterSize")]
    public string Size { get; set; }

    public int AddressAreaId { get; set; }

    [Display(ResourceType = typeof(Resources), Name = "QuarterStreet")]
    public string AddressStreet { get; set; }

    public int? OwnerId { get; set; }

    [DisplayName("Район")]
    public virtual Area AddressArea { get; set; }

    [DisplayName("Владелец")]
    public virtual Customer Owner { get; set; }

    [DisplayName("Тип дома")]
    public virtual TypeHouse TypeHouse { get; set; }

    public virtual ICollection<Swap> Swaps { get; set; }
  }
}
