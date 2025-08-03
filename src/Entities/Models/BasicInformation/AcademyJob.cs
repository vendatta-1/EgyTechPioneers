
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public  class AcademyJob : Entity
{ 

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int JobNo { get; set; }

    public Guid? AcademyDataId { get; set; }

    public Guid? BranchesDataId { get; set; }

    [MaxLength(70)]
    public string JobNameL1 { get; set; }
    [MaxLength(70)]
    public string? JobNameL2 { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(255)]
    public string? JobLink { get; set; }

    public virtual BranchData BranchesData { get; set; }
}