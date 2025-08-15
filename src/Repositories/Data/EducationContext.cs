using System;
using System.Collections.Generic;
using System.Reflection;
using Common;
using Common.Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Entities.Models.BasicInformation;
using Entities.Models.Chat;
using Entities.Models.Complaints;
using Entities.Models.System;

namespace Repositories.Data;

public class EducationContext(DbContextOptions<EducationContext> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EducationContext).Assembly);

        modelBuilder.Entity<ChatMessage>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<AcademyClaseDetail>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<AcademyClaseMaster>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<AcademyClaseType>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<AcademyData>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<AcademyJob>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<BranchData>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<CityCode>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ComplaintsStatus>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ComplaintsStudent>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ComplaintsType>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<CountryCode>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<EduContactResult>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<GovernorateCode>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<PermissionUser>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ProgramsContentDetail>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ProgramsContentMaster>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ProgramsDetail>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ProjectsDetail>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<ProjectsMaster>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<QuestionBankDetail>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<QuestionBankMaster>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<SkillDevelopment>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<StudentAttend>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<StudentContentDetail>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<StudentData>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<StudentEvaluation>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<StudentGroup>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.Entity<TeacherData>().HasQueryFilter(e => !e.IsDeleted && e.IsNotActive == false);
        modelBuilder.HasSequence<int>("AcademyClaseNo_Seq")
            .StartsAt(1)
            .IncrementsBy(1);

        modelBuilder.Entity<AcademyClaseMaster>()
            .Property(b => b.ClaseBranchNo)
            .HasDefaultValueSql("NEXT VALUE FOR AcademyClaseNo_Seq");
        
        modelBuilder.HasSequence<int>("StudentProfileCode")
            .StartsAt(1)
            .IncrementsBy(1);
        
        modelBuilder.Entity<StudentData>()
            .Property(x=>x.ProfileCode)
            .HasDefaultValueSql("NEXT VALUE FOR StudentProfileCode");
    }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }
    public virtual DbSet<AcademyClaseDetail> AcademyClaseDetails { get; set; }

    public virtual DbSet<AcademyClaseMaster> AcademyClaseMasters { get; set; }

    public virtual DbSet<AcademyClaseType> AcademyClaseTypes { get; set; }

    public virtual DbSet<AcademyData> AcademyData { get; set; }

    public virtual DbSet<AcademyJob> AcademyJobs { get; set; }

    public virtual DbSet<BranchData> BranchesData { get; set; }

    public virtual DbSet<CityCode> CityCodes { get; set; }

    public virtual DbSet<ComplaintsStatus> ComplaintsStatuses { get; set; }

    public virtual DbSet<ComplaintsStudent> ComplaintsStudents { get; set; }

    public virtual DbSet<ComplaintsType> ComplaintsTypes { get; set; }

    public virtual DbSet<CountryCode> CountryCodes { get; set; }

    public virtual DbSet<EduContactResult> EduContactResults { get; set; }

    public virtual DbSet<GovernorateCode> GovernorateCodes { get; set; }

    public virtual DbSet<PermissionUser> PermissionUsers { get; set; }

    public virtual DbSet<ProgramsContentDetail> ProgramsContentDetails { get; set; }

    public virtual DbSet<ProgramsContentMaster> ProgramsContentMasters { get; set; }

    public virtual DbSet<ProgramsDetail> ProgramsDetails { get; set; }

    public virtual DbSet<ProjectsDetail> ProjectsDetails { get; set; }

    public virtual DbSet<ProjectsMaster> ProjectsMasters { get; set; }

    public virtual DbSet<QuestionBankDetail> QuestionBankDetails { get; set; }

    public virtual DbSet<QuestionBankMaster> QuestionBankMasters { get; set; }

    public virtual DbSet<SkillDevelopment> SkillDevelopments { get; set; }

    public virtual DbSet<StudentAttend> StudentAttends { get; set; }

    public virtual DbSet<StudentContentDetail> StudentContentDetails { get; set; }

    public virtual DbSet<StudentData> StudentData { get; set; }

    public virtual DbSet<StudentEvaluation> StudentEvaluations { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<TeacherData> TeacherData { get; set; }
}