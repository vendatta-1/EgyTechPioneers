using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations.Education
{
    /// <inheritdoc />
    public partial class Update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademyClaseTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassTypeNameId = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyClaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademyData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcademyNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GovernorateCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AcademyAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AcademyMobil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AcademyPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AcademyWhatsapp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AcademyEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AcademyWebSite = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AcademyFacebook = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AcademyInstagram = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AcademyTiktok = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AcademyTwitter = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AcademySnapchat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AcademyYoutube = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TaxRegistrationNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxesErrand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CommercialRegisterNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AttachFiles = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderDisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceiverDisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    MessageType = table.Column<int>(type: "int", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintsStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StatusesNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StatusesNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintsStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplaintsTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TypeNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EduContactResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResultUd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReasonsRejectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateResult = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduContactResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AspNetUsersId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationMenuId = table.Column<long>(type: "bigint", nullable: true),
                    OpenForm = table.Column<bool>(type: "bit", nullable: true),
                    AddForm = table.Column<bool>(type: "bit", nullable: true),
                    EditForm = table.Column<bool>(type: "bit", nullable: true),
                    DeleteForm = table.Column<bool>(type: "bit", nullable: true),
                    ReadForm = table.Column<bool>(type: "bit", nullable: true),
                    SearchForm = table.Column<bool>(type: "bit", nullable: true),
                    FilterForm = table.Column<bool>(type: "bit", nullable: true),
                    PrinterReport = table.Column<bool>(type: "bit", nullable: true),
                    ExportFile = table.Column<bool>(type: "bit", nullable: true),
                    ExportDataGrid = table.Column<bool>(type: "bit", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GovernorateCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GovernorateNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GovernorateNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernorateCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernorateCodes_CountryCodes_CountryCodeId",
                        column: x => x.CountryCodeId,
                        principalTable: "CountryCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CityCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GovernorateCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CityNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityCodes_GovernorateCodes_GovernorateCodeId",
                        column: x => x.GovernorateCodeId,
                        principalTable: "GovernorateCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BranchesData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchesDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BranchNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GovernorateCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BranchMobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BranchPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BranchWhatsapp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BranchEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    BranchManager = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesData_AcademyData_AcademyDataId",
                        column: x => x.AcademyDataId,
                        principalTable: "AcademyData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesData_CityCodes_CityCodeId",
                        column: x => x.CityCodeId,
                        principalTable: "CityCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesData_CountryCodes_CountryCodeId",
                        column: x => x.CountryCodeId,
                        principalTable: "CountryCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BranchesData_GovernorateCodes_GovernorateCodeId",
                        column: x => x.GovernorateCodeId,
                        principalTable: "GovernorateCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademyClaseMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GovernorateCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClaseNameL1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClaseNameL2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClaseAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClaseOwnerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OwnerMobil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CommunicationsOfficer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CommunicationsMobil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmailClase = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailOwner = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ClaseBranchNo = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyClaseMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyClaseMasters_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AcademyClaseMasters_CityCodes_CityCodeId",
                        column: x => x.CityCodeId,
                        principalTable: "CityCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AcademyClaseMasters_GovernorateCodes_GovernorateCodeId",
                        column: x => x.GovernorateCodeId,
                        principalTable: "GovernorateCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademyJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    JobNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    JobLink = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyJobs_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectsMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ProjectNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ProjectStart = table.Column<DateOnly>(type: "date", nullable: true),
                    ProjectEnd = table.Column<DateOnly>(type: "date", nullable: true),
                    ProjectResources = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProjectFile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsMasters_AcademyData_AcademyDataId",
                        column: x => x.AcademyDataId,
                        principalTable: "AcademyData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectsMasters_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SkillDevelopments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SkillNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    SkillNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinkVideo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FilesAttach = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillDevelopments_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GovernorateCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeacherNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    TeacherNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    TeacherAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DateStart = table.Column<DateOnly>(type: "date", nullable: true),
                    TeacherMobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    TeacherPhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    TeacherWhatsapp = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    TeacherEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TeacherCancel = table.Column<DateOnly>(type: "date", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherData_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherData_CityCodes_CityCodeId",
                        column: x => x.CityCodeId,
                        principalTable: "CityCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherData_GovernorateCodes_GovernorateCodeId",
                        column: x => x.GovernorateCodeId,
                        principalTable: "GovernorateCodes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AcademyClaseDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyClaseMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AcademyClaseTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClaseNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyClaseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyClaseDetails_AcademyClaseMasters_AcademyClaseMasterId",
                        column: x => x.AcademyClaseMasterId,
                        principalTable: "AcademyClaseMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectsDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectDetailsNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectsMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ProjectNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectsDetails_ProjectsMasters_ProjectsMasterId",
                        column: x => x.ProjectsMasterId,
                        principalTable: "ProjectsMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    GroupNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    AcademyClaseDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DataFinch = table.Column<DateOnly>(type: "date", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Saturday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineS = table.Column<bool>(type: "bit", nullable: true),
                    OfflineS = table.Column<bool>(type: "bit", nullable: true),
                    Sunday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineSu = table.Column<bool>(type: "bit", nullable: true),
                    OfflineSu = table.Column<bool>(type: "bit", nullable: true),
                    Monday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineM = table.Column<bool>(type: "bit", nullable: true),
                    OfflineM = table.Column<bool>(type: "bit", nullable: true),
                    Tuesday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineT = table.Column<bool>(type: "bit", nullable: true),
                    OfflineT = table.Column<bool>(type: "bit", nullable: true),
                    Wednesday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineW = table.Column<bool>(type: "bit", nullable: true),
                    OfflineW = table.Column<bool>(type: "bit", nullable: true),
                    Thursday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineTh = table.Column<bool>(type: "bit", nullable: true),
                    OfflineTh = table.Column<bool>(type: "bit", nullable: true),
                    Friday = table.Column<bool>(type: "bit", nullable: true),
                    OnlineF = table.Column<bool>(type: "bit", nullable: true),
                    OfflineF = table.Column<bool>(type: "bit", nullable: true),
                    TeacherDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberStudents = table.Column<int>(type: "int", nullable: true),
                    AcademyCourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGroups_AcademyClaseDetails_AcademyClaseDetailsId",
                        column: x => x.AcademyClaseDetailsId,
                        principalTable: "AcademyClaseDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentGroups_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramsDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectsDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProgramNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    ProgramNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramsDetails_ProjectsDetails_ProjectsDetailsId",
                        column: x => x.ProjectsDetailsId,
                        principalTable: "ProjectsDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentData",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentBarCode = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentNameL1 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StudentNameL2 = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CountryCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GovernorateCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StudentPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TrainingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrainingGovernorateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecommendTrack = table.Column<long>(type: "bigint", nullable: true),
                    RecommendJobProfile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GraduationStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Track = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProfileCode = table.Column<int>(type: "int", nullable: true),
                    AcademyClaseDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectsDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrainingProvider = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Language = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CertificateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StudentMobil = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    StudentWhatsapp = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    StudentEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmailAcademy = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    EmailPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcademyClaseDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityCodeId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProjectsDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentGroupId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentData_AcademyClaseDetails_AcademyClaseDetailId",
                        column: x => x.AcademyClaseDetailId,
                        principalTable: "AcademyClaseDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentData_AcademyClaseDetails_AcademyClaseDetailsId",
                        column: x => x.AcademyClaseDetailsId,
                        principalTable: "AcademyClaseDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentData_BranchesData_BranchDataId",
                        column: x => x.BranchDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentData_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentData_CityCodes_CityCodeId",
                        column: x => x.CityCodeId,
                        principalTable: "CityCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentData_CityCodes_CityCodeId1",
                        column: x => x.CityCodeId1,
                        principalTable: "CityCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentData_GovernorateCodes_GovernorateCodeId",
                        column: x => x.GovernorateCodeId,
                        principalTable: "GovernorateCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentData_GovernorateCodes_TrainingGovernorateId",
                        column: x => x.TrainingGovernorateId,
                        principalTable: "GovernorateCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentData_ProjectsDetails_ProjectsDetailId",
                        column: x => x.ProjectsDetailId,
                        principalTable: "ProjectsDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentData_ProjectsDetails_ProjectsDetailsId",
                        column: x => x.ProjectsDetailsId,
                        principalTable: "ProjectsDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentData_StudentGroups_StudentGroupId",
                        column: x => x.StudentGroupId,
                        principalTable: "StudentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_StudentData_StudentGroups_StudentGroupId1",
                        column: x => x.StudentGroupId1,
                        principalTable: "StudentGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramsContentMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramsDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionNameL1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionNameL2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScientificMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsContentMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramsContentMasters_ProgramsDetails_ProgramsDetailsId",
                        column: x => x.ProgramsDetailsId,
                        principalTable: "ProgramsDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionBankMasters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramsDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    QuestionNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBankMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionBankMasters_ProgramsDetails_ProgramsDetailsId",
                        column: x => x.ProgramsDetailsId,
                        principalTable: "ProgramsDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplaintsStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BranchesDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComplaintsNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComplaintsTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComplaintsStatusesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentsDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FilesAttach = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplaintsStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplaintsStudents_BranchesData_BranchesDataId",
                        column: x => x.BranchesDataId,
                        principalTable: "BranchesData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComplaintsStudents_ComplaintsStatuses_ComplaintsStatusesId",
                        column: x => x.ComplaintsStatusesId,
                        principalTable: "ComplaintsStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComplaintsStudents_ComplaintsTypes_ComplaintsTypeId",
                        column: x => x.ComplaintsTypeId,
                        principalTable: "ComplaintsTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComplaintsStudents_StudentData_StudentsDataId",
                        column: x => x.StudentsDataId,
                        principalTable: "StudentData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentAttends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateAttend = table.Column<DateOnly>(type: "date", nullable: true),
                    AttendAccept = table.Column<bool>(type: "bit", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAttends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAttends_StudentData_StudentDataId",
                        column: x => x.StudentDataId,
                        principalTable: "StudentData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentEvaluations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttendanceRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AbsenceRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BrowsingRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContentRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEvaluations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEvaluations_StudentData_StudentDataId",
                        column: x => x.StudentDataId,
                        principalTable: "StudentData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramsContentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramsContentMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionTasks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionProject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScientificMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionVideo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionQuiz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramsContentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramsContentDetails_ProgramsContentMasters_ProgramsContentMasterId",
                        column: x => x.ProgramsContentMasterId,
                        principalTable: "ProgramsContentMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionBankDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionBankMasterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AnswerNameL1 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    AnswerNameL2 = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionBankDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionBankDetails_QuestionBankMasters_QuestionBankMasterId",
                        column: x => x.QuestionBankMasterId,
                        principalTable: "QuestionBankMasters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentContentDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProgramsContentDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentDataId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SessionTasks = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SessionProject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SessionQuiz = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsNotactive = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modifiedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modifieddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Isdeleted = table.Column<bool>(type: "bit", nullable: true),
                    Deletedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentContentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentContentDetails_ProgramsContentDetails_ProgramsContentDetailsId",
                        column: x => x.ProgramsContentDetailsId,
                        principalTable: "ProgramsContentDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentContentDetails_StudentData_StudentDataId",
                        column: x => x.StudentDataId,
                        principalTable: "StudentData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademyClaseDetails_AcademyClaseMasterId",
                table: "AcademyClaseDetails",
                column: "AcademyClaseMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyClaseMasters_BranchesDataId",
                table: "AcademyClaseMasters",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyClaseMasters_CityCodeId",
                table: "AcademyClaseMasters",
                column: "CityCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyClaseMasters_GovernorateCodeId",
                table: "AcademyClaseMasters",
                column: "GovernorateCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademyJobs_BranchesDataId",
                table: "AcademyJobs",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesData_AcademyDataId",
                table: "BranchesData",
                column: "AcademyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesData_CityCodeId",
                table: "BranchesData",
                column: "CityCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesData_CountryCodeId",
                table: "BranchesData",
                column: "CountryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesData_GovernorateCodeId",
                table: "BranchesData",
                column: "GovernorateCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCodes_GovernorateCodeId",
                table: "CityCodes",
                column: "GovernorateCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsStudents_BranchesDataId",
                table: "ComplaintsStudents",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsStudents_ComplaintsStatusesId",
                table: "ComplaintsStudents",
                column: "ComplaintsStatusesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsStudents_ComplaintsTypeId",
                table: "ComplaintsStudents",
                column: "ComplaintsTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplaintsStudents_StudentsDataId",
                table: "ComplaintsStudents",
                column: "StudentsDataId");

            migrationBuilder.CreateIndex(
                name: "IX_GovernorateCodes_CountryCodeId",
                table: "GovernorateCodes",
                column: "CountryCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsContentDetails_ProgramsContentMasterId",
                table: "ProgramsContentDetails",
                column: "ProgramsContentMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsContentMasters_ProgramsDetailsId",
                table: "ProgramsContentMasters",
                column: "ProgramsDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramsDetails_ProjectsDetailsId",
                table: "ProgramsDetails",
                column: "ProjectsDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsDetails_ProjectsMasterId",
                table: "ProjectsDetails",
                column: "ProjectsMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsMasters_AcademyDataId",
                table: "ProjectsMasters",
                column: "AcademyDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsMasters_BranchesDataId",
                table: "ProjectsMasters",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBankDetails_QuestionBankMasterId",
                table: "QuestionBankDetails",
                column: "QuestionBankMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionBankMasters_ProgramsDetailsId",
                table: "QuestionBankMasters",
                column: "ProgramsDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillDevelopments_BranchesDataId",
                table: "SkillDevelopments",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAttends_StudentDataId",
                table: "StudentAttends",
                column: "StudentDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentContentDetails_ProgramsContentDetailsId",
                table: "StudentContentDetails",
                column: "ProgramsContentDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentContentDetails_StudentDataId",
                table: "StudentContentDetails",
                column: "StudentDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_AcademyClaseDetailId",
                table: "StudentData",
                column: "AcademyClaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_AcademyClaseDetailsId",
                table: "StudentData",
                column: "AcademyClaseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_BranchDataId",
                table: "StudentData",
                column: "BranchDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_BranchesDataId",
                table: "StudentData",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_CityCodeId",
                table: "StudentData",
                column: "CityCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_CityCodeId1",
                table: "StudentData",
                column: "CityCodeId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_GovernorateCodeId",
                table: "StudentData",
                column: "GovernorateCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_ProjectsDetailId",
                table: "StudentData",
                column: "ProjectsDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_ProjectsDetailsId",
                table: "StudentData",
                column: "ProjectsDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_StudentGroupId",
                table: "StudentData",
                column: "StudentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_StudentGroupId1",
                table: "StudentData",
                column: "StudentGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentData_TrainingGovernorateId",
                table: "StudentData",
                column: "TrainingGovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEvaluations_StudentDataId",
                table: "StudentEvaluations",
                column: "StudentDataId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_AcademyClaseDetailsId",
                table: "StudentGroups",
                column: "AcademyClaseDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGroups_BranchesDataId",
                table: "StudentGroups",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherData_BranchesDataId",
                table: "TeacherData",
                column: "BranchesDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherData_CityCodeId",
                table: "TeacherData",
                column: "CityCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherData_GovernorateCodeId",
                table: "TeacherData",
                column: "GovernorateCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademyClaseTypes");

            migrationBuilder.DropTable(
                name: "AcademyJobs");

            migrationBuilder.DropTable(
                name: "ChatMessages");

            migrationBuilder.DropTable(
                name: "ComplaintsStudents");

            migrationBuilder.DropTable(
                name: "EduContactResults");

            migrationBuilder.DropTable(
                name: "PermissionUsers");

            migrationBuilder.DropTable(
                name: "QuestionBankDetails");

            migrationBuilder.DropTable(
                name: "SkillDevelopments");

            migrationBuilder.DropTable(
                name: "StudentAttends");

            migrationBuilder.DropTable(
                name: "StudentContentDetails");

            migrationBuilder.DropTable(
                name: "StudentEvaluations");

            migrationBuilder.DropTable(
                name: "TeacherData");

            migrationBuilder.DropTable(
                name: "ComplaintsStatuses");

            migrationBuilder.DropTable(
                name: "ComplaintsTypes");

            migrationBuilder.DropTable(
                name: "QuestionBankMasters");

            migrationBuilder.DropTable(
                name: "ProgramsContentDetails");

            migrationBuilder.DropTable(
                name: "StudentData");

            migrationBuilder.DropTable(
                name: "ProgramsContentMasters");

            migrationBuilder.DropTable(
                name: "StudentGroups");

            migrationBuilder.DropTable(
                name: "ProgramsDetails");

            migrationBuilder.DropTable(
                name: "AcademyClaseDetails");

            migrationBuilder.DropTable(
                name: "ProjectsDetails");

            migrationBuilder.DropTable(
                name: "AcademyClaseMasters");

            migrationBuilder.DropTable(
                name: "ProjectsMasters");

            migrationBuilder.DropTable(
                name: "BranchesData");

            migrationBuilder.DropTable(
                name: "AcademyData");

            migrationBuilder.DropTable(
                name: "CityCodes");

            migrationBuilder.DropTable(
                name: "GovernorateCodes");

            migrationBuilder.DropTable(
                name: "CountryCodes");
        }
    }
}
