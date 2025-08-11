using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.Education
{
    /// <inheritdoc />
    public partial class Update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "TeacherData",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "TeacherData",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "TeacherData",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "TeacherData",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "TeacherData",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "StudentGroups",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "StudentGroups",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "StudentGroups",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "StudentGroups",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "StudentGroups",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "StudentEvaluations",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "StudentEvaluations",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "StudentEvaluations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "StudentEvaluations",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "StudentEvaluations",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "StudentData",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "StudentData",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "StudentData",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "StudentData",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "StudentData",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "StudentContentDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "StudentContentDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "StudentContentDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "StudentContentDetails",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "StudentContentDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "StudentAttends",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "StudentAttends",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "StudentAttends",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "StudentAttends",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "StudentAttends",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "SkillDevelopments",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "SkillDevelopments",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "SkillDevelopments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "SkillDevelopments",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "SkillDevelopments",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "QuestionBankMasters",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "QuestionBankMasters",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "QuestionBankMasters",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "QuestionBankMasters",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "QuestionBankMasters",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "QuestionBankDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "QuestionBankDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "QuestionBankDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "QuestionBankDetails",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "QuestionBankDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ProjectsMasters",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ProjectsMasters",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ProjectsMasters",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ProjectsMasters",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ProjectsMasters",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ProjectsDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ProjectsDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ProjectsDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ProjectsDetails",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ProjectsDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ProgramsDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ProgramsDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ProgramsDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ProgramsDetails",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ProgramsDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ProgramsContentMasters",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ProgramsContentMasters",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ProgramsContentMasters",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ProgramsContentMasters",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ProgramsContentMasters",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ProgramsContentDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ProgramsContentDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ProgramsContentDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ProgramsContentDetails",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ProgramsContentDetails",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "PermissionUsers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "PermissionUsers",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "PermissionUsers",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "PermissionUsers",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "PermissionUsers",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "GovernorateCodes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "GovernorateCodes",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "GovernorateCodes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "GovernorateCodes",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "GovernorateCodes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "EduContactResults",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "EduContactResults",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "EduContactResults",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "EduContactResults",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "EduContactResults",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "CountryCodes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "CountryCodes",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "CountryCodes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "CountryCodes",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "CountryCodes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ComplaintsTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ComplaintsTypes",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ComplaintsTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ComplaintsTypes",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ComplaintsTypes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ComplaintsStudents",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ComplaintsStudents",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ComplaintsStudents",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ComplaintsStudents",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ComplaintsStudents",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ComplaintsStatuses",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ComplaintsStatuses",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ComplaintsStatuses",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ComplaintsStatuses",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ComplaintsStatuses",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "CityCodes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "CityCodes",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "CityCodes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "CityCodes",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "CityCodes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "ChatMessages",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "ChatMessages",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "ChatMessages",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "ChatMessages",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "ChatMessages",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "BranchesData",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "BranchesData",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "BranchesData",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "BranchesData",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "BranchesData",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "AcademyJobs",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "AcademyJobs",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "AcademyJobs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "AcademyJobs",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "AcademyJobs",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "AcademyData",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "AcademyData",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "AcademyData",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "AcademyData",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "AcademyData",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "AcademyClaseTypes",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "AcademyClaseTypes",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "AcademyClaseTypes",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "AcademyClaseTypes",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "AcademyClaseTypes",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "AcademyClaseMasters",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "AcademyClaseMasters",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "AcademyClaseMasters",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "AcademyClaseMasters",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "AcademyClaseMasters",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Modifieddate",
                table: "AcademyClaseDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Modifiedby",
                table: "AcademyClaseDetails",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "Isdeleted",
                table: "AcademyClaseDetails",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsNotactive",
                table: "AcademyClaseDetails",
                newName: "IsNotActive");

            migrationBuilder.RenameColumn(
                name: "Deletedby",
                table: "AcademyClaseDetails",
                newName: "DeletedBy");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "TeacherData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TeacherData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "TeacherData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "TeacherData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "TeacherData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StudentGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StudentGroups",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "StudentGroups",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "StudentGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentGroups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StudentEvaluations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StudentEvaluations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "StudentEvaluations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "StudentEvaluations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentEvaluations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StudentData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StudentData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "StudentData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "StudentData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StudentContentDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StudentContentDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "StudentContentDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "StudentContentDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentContentDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "StudentAttends",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "StudentAttends",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "StudentAttends",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "StudentAttends",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentAttends",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "SkillDevelopments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SkillDevelopments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "SkillDevelopments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "SkillDevelopments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "SkillDevelopments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionBankMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "QuestionBankMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "QuestionBankMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "QuestionBankMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "QuestionBankMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "QuestionBankDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "QuestionBankDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "QuestionBankDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "QuestionBankDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "QuestionBankDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ProjectsMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProjectsMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ProjectsMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProjectsMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProjectsMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ProjectsDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProjectsDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ProjectsDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProjectsDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProjectsDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ProgramsDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProgramsDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ProgramsDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProgramsDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProgramsDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ProgramsContentMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProgramsContentMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ProgramsContentMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProgramsContentMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProgramsContentMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ProgramsContentDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ProgramsContentDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ProgramsContentDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ProgramsContentDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProgramsContentDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "PermissionUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PermissionUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "PermissionUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "PermissionUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "PermissionUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "GovernorateCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "GovernorateCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "GovernorateCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "GovernorateCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "GovernorateCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "EduContactResults",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "EduContactResults",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "EduContactResults",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "EduContactResults",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "EduContactResults",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "CountryCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CountryCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "CountryCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CountryCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "CountryCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ComplaintsTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ComplaintsTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ComplaintsTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ComplaintsTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ComplaintsTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ComplaintsStudents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ComplaintsStudents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ComplaintsStudents",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ComplaintsStudents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ComplaintsStudents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ComplaintsStatuses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ComplaintsStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ComplaintsStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ComplaintsStatuses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ComplaintsStatuses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "CityCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "CityCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "CityCodes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "CityCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "CityCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "ChatMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "ChatMessages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "ChatMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ChatMessages",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "BranchesData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "BranchesData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "BranchesData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "BranchesData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "BranchesData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AcademyJobs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AcademyJobs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "AcademyJobs",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AcademyJobs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyJobs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AcademyData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AcademyData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "AcademyData",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AcademyData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyData",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AcademyClaseTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AcademyClaseTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "AcademyClaseTypes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AcademyClaseTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyClaseTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AcademyClaseMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AcademyClaseMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "AcademyClaseMasters",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AcademyClaseMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyClaseMasters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "AcademyClaseDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "AcademyClaseDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotActive",
                table: "AcademyClaseDetails",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "AcademyClaseDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyClaseDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "TeacherData",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "TeacherData",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "TeacherData",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "TeacherData",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "TeacherData",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "StudentGroups",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "StudentGroups",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "StudentGroups",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StudentGroups",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "StudentGroups",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "StudentEvaluations",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "StudentEvaluations",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "StudentEvaluations",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StudentEvaluations",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "StudentEvaluations",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "StudentData",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "StudentData",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "StudentData",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StudentData",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "StudentData",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "StudentContentDetails",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "StudentContentDetails",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "StudentContentDetails",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StudentContentDetails",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "StudentContentDetails",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "StudentAttends",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "StudentAttends",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "StudentAttends",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "StudentAttends",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "StudentAttends",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "SkillDevelopments",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "SkillDevelopments",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "SkillDevelopments",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "SkillDevelopments",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "SkillDevelopments",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "QuestionBankMasters",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "QuestionBankMasters",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "QuestionBankMasters",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "QuestionBankMasters",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "QuestionBankMasters",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "QuestionBankDetails",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "QuestionBankDetails",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "QuestionBankDetails",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "QuestionBankDetails",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "QuestionBankDetails",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ProjectsMasters",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProjectsMasters",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ProjectsMasters",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProjectsMasters",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProjectsMasters",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ProjectsDetails",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProjectsDetails",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ProjectsDetails",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProjectsDetails",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProjectsDetails",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ProgramsDetails",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProgramsDetails",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ProgramsDetails",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProgramsDetails",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProgramsDetails",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ProgramsContentMasters",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProgramsContentMasters",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ProgramsContentMasters",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProgramsContentMasters",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProgramsContentMasters",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ProgramsContentDetails",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ProgramsContentDetails",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ProgramsContentDetails",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ProgramsContentDetails",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ProgramsContentDetails",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "PermissionUsers",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "PermissionUsers",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "PermissionUsers",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "PermissionUsers",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "PermissionUsers",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "GovernorateCodes",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "GovernorateCodes",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "GovernorateCodes",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "GovernorateCodes",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "GovernorateCodes",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "EduContactResults",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "EduContactResults",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "EduContactResults",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "EduContactResults",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "EduContactResults",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "CountryCodes",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "CountryCodes",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "CountryCodes",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "CountryCodes",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "CountryCodes",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ComplaintsTypes",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ComplaintsTypes",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ComplaintsTypes",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ComplaintsTypes",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ComplaintsTypes",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ComplaintsStudents",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ComplaintsStudents",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ComplaintsStudents",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ComplaintsStudents",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ComplaintsStudents",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ComplaintsStatuses",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ComplaintsStatuses",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ComplaintsStatuses",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ComplaintsStatuses",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ComplaintsStatuses",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "CityCodes",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "CityCodes",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "CityCodes",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "CityCodes",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "CityCodes",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "ChatMessages",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ChatMessages",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "ChatMessages",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ChatMessages",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ChatMessages",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "BranchesData",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "BranchesData",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "BranchesData",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "BranchesData",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "BranchesData",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AcademyJobs",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AcademyJobs",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "AcademyJobs",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AcademyJobs",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "AcademyJobs",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AcademyData",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AcademyData",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "AcademyData",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AcademyData",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "AcademyData",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AcademyClaseTypes",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AcademyClaseTypes",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "AcademyClaseTypes",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AcademyClaseTypes",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "AcademyClaseTypes",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AcademyClaseMasters",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AcademyClaseMasters",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "AcademyClaseMasters",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AcademyClaseMasters",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "AcademyClaseMasters",
                newName: "Deletedby");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AcademyClaseDetails",
                newName: "Modifieddate");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "AcademyClaseDetails",
                newName: "Modifiedby");

            migrationBuilder.RenameColumn(
                name: "IsNotActive",
                table: "AcademyClaseDetails",
                newName: "IsNotactive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "AcademyClaseDetails",
                newName: "Isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "AcademyClaseDetails",
                newName: "Deletedby");

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "TeacherData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "TeacherData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "TeacherData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "TeacherData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "TeacherData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "StudentGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "StudentGroups",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "StudentGroups",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "StudentGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "StudentEvaluations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "StudentEvaluations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "StudentEvaluations",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "StudentEvaluations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentEvaluations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "StudentData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "StudentData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "StudentData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "StudentData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "StudentContentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "StudentContentDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "StudentContentDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "StudentContentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentContentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "StudentAttends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "StudentAttends",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "StudentAttends",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "StudentAttends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "StudentAttends",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "SkillDevelopments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "SkillDevelopments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "SkillDevelopments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "SkillDevelopments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "SkillDevelopments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "QuestionBankMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "QuestionBankMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "QuestionBankMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "QuestionBankMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "QuestionBankMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "QuestionBankDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "QuestionBankDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "QuestionBankDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "QuestionBankDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "QuestionBankDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ProjectsMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ProjectsMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ProjectsMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ProjectsMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProjectsMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ProjectsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ProjectsDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ProjectsDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ProjectsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProjectsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ProgramsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ProgramsDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ProgramsDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ProgramsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProgramsDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ProgramsContentMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ProgramsContentMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ProgramsContentMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ProgramsContentMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProgramsContentMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ProgramsContentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ProgramsContentDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ProgramsContentDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ProgramsContentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ProgramsContentDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "PermissionUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "PermissionUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "PermissionUsers",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "PermissionUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "PermissionUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "GovernorateCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "GovernorateCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "GovernorateCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "GovernorateCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "GovernorateCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "EduContactResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "EduContactResults",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "EduContactResults",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "EduContactResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "EduContactResults",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "CountryCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "CountryCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "CountryCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "CountryCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "CountryCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ComplaintsTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ComplaintsTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ComplaintsTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ComplaintsTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ComplaintsTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ComplaintsStudents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ComplaintsStudents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ComplaintsStudents",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ComplaintsStudents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ComplaintsStudents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ComplaintsStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ComplaintsStatuses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ComplaintsStatuses",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ComplaintsStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ComplaintsStatuses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "CityCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "CityCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "CityCodes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "CityCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "CityCodes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "ChatMessages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "ChatMessages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "ChatMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "BranchesData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "BranchesData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "BranchesData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "BranchesData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "BranchesData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "AcademyJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "AcademyJobs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "AcademyJobs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "AcademyJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyJobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "AcademyData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "AcademyData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "AcademyData",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "AcademyData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "AcademyClaseTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "AcademyClaseTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "AcademyClaseTypes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "AcademyClaseTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyClaseTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "AcademyClaseMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "AcademyClaseMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "AcademyClaseMasters",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "AcademyClaseMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyClaseMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Modifiedby",
                table: "AcademyClaseDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsNotactive",
                table: "AcademyClaseDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Isdeleted",
                table: "AcademyClaseDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Deletedby",
                table: "AcademyClaseDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreateUserName",
                table: "AcademyClaseDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
