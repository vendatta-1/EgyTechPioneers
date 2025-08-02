using Entities.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Configurations;

public class StudentDataConfigurations : IEntityTypeConfiguration<StudentData>
{
    public void Configure(EntityTypeBuilder<StudentData> builder)
    {
       
        builder.HasKey(e => e.Id);

      
        builder.HasOne(e => e.GovernorateCode)
               .WithMany(g => g.StudentDataGovernorateCodes)
               .HasForeignKey(e => e.GovernorateCodeId)
               .OnDelete(DeleteBehavior.Restrict);

        
        builder.HasOne(e => e.TrainingGovernorate)
               .WithMany(g => g.StudentDataTrainingGovernorates)
               .HasForeignKey(e => e.TrainingGovernorateId)
               .OnDelete(DeleteBehavior.Restrict);

       
        builder.HasOne(e => e.CityCode)
               .WithMany()
               .HasForeignKey(e => e.CityCodeId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.AcademyClaseDetails)
               .WithMany()
               .HasForeignKey(e => e.AcademyClaseDetailsId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.BranchesData)
               .WithMany()
               .HasForeignKey(e => e.BranchesDataId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ProjectsDetails)
               .WithMany()
               .HasForeignKey(e => e.ProjectsDetailsId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.StudentGroup)
               .WithMany()
               .HasForeignKey(e => e.StudentGroupId)
               .OnDelete(DeleteBehavior.SetNull);
 
        builder.Property(e => e.StudentNameL1).IsRequired().HasMaxLength(150);
        builder.Property(e => e.StudentNameL2).HasMaxLength(150);
        builder.Property(e => e.StudentPhone).IsRequired().HasMaxLength(20);
        builder.Property(e => e.StudentAddress).IsRequired().HasMaxLength(200);
  
        
    }
}
