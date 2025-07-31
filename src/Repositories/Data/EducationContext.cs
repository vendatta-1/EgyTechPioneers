 
using System;
using System.Collections.Generic;
using Common.Data;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
namespace Repositories.Data;

public class EducationContext : DbContext, IUnitOfWork
{
    public EducationContext()
    {
    }

    public EducationContext(DbContextOptions<EducationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AcademyClaseDetail> AcademyClaseDetails { get; set; }

    public virtual DbSet<AcademyClaseMaster> AcademyClaseMasters { get; set; }

    public virtual DbSet<AcademyClaseType> AcademyClaseTypes { get; set; }

    public virtual DbSet<AcademyData> AcademyData { get; set; }

    public virtual DbSet<AcademyJob> AcademyJobs { get; set; }

    public virtual DbSet<BrancheData> BranchesData { get; set; }

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