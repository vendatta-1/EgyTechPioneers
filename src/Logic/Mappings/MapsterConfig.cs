using Dtos.BasicInformation;
using Dtos.Complaints;
using Dtos.Security;
using Dtos.System;
using Entities.Models;
using Entities.Models.BasicInformation;
using Entities.Models.Complaints;
using Entities.Models.Security;
using Entities.Models.System;
using Mapster;

namespace Logic.Mappings;

public class MapsterConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.Default.IgnoreMember((member, side) =>
        {
            // Ignore collections
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(member.Type)
                && member.Type != typeof(string))
                return true;

            // Ignore single navigation references (class but not string), in future if there'll be any refs between classes and it needed can enhance that configurations
            if (member.Type.IsClass && member.Type != typeof(string))
                return true;

            return false;
        });

        #region Basic Information

        config.NewConfig<AcademyClaseMaster, AcademyClaseMasterDto>();
        config.NewConfig<AcademyClaseMasterDto, AcademyClaseMaster>()
            .Ignore(x => x.ClaseBranchNo);
        
        config.NewConfig<AcademyClaseType, AcademyClaseTypeDto>().TwoWays();
        config.NewConfig<AcademyClaseDetail, AcademyClaseDetailDto>();
        config.NewConfig<AcademyClaseDetailDto, AcademyClaseDetail>()
            .Ignore(x => x.ClaseNumber);
        
        config.NewConfig<AcademyData, AcademyDataDto>().Ignore(x => x.Image).Ignore(x => x.Attachments);
        config.NewConfig<AcademyDataDto, AcademyData>();
        config.NewConfig<AcademyJob, AcademyJobDto>();
        config.NewConfig<AcademyJobDto, AcademyJob>()
            .Ignore(x => x.JobNo);
        
        config.NewConfig<BranchData, BranchDataDto>().TwoWays();
        config.NewConfig<CityCode, CityCodeDto>().TwoWays();
        config.NewConfig<CountryCode, CountryCodeDto>().TwoWays();
        config.NewConfig<GovernorateCode, GovernorateCodeDto>().TwoWays();

        #endregion

        config.NewConfig<StudentAttend, StudentAttendDto>().TwoWays();
        config.NewConfig<StudentEvaluation, StudentEvaluationDto>().TwoWays();
        config.NewConfig<StudentGroup, StudentGroupDto>();
        config.NewConfig<StudentGroupDto, StudentGroup>()
            .Ignore(x => x.GroupNo);
        config.NewConfig<TeacherData, TeacherDataDto>().TwoWays();
        config.NewConfig<SkillDevelopment, SkillDevelopmentDto>()
            .Ignore(dest => dest.AttachedFiles);
        config.NewConfig<SkillDevelopmentDto, SkillDevelopment>()
            .Ignore(dest => dest.FilesAttach);

        config.NewConfig<StudentData, StudentDataDto>();
        config.NewConfig<StudentDataDto, StudentData>()
            .Ignore(x => x.StudentCode)
            .Ignore(x => x.ProfileCode);
        
        config.NewConfig<QuestionBankDetail, QuestionBankDetailDto>().TwoWays();
        
        config.NewConfig<QuestionBankMaster, QuestionBankMasterDto>();
        config.NewConfig<QuestionBankMasterDto, QuestionBankMaster>()
            .Ignore(x => x.QuestionNo);
        
        config.NewConfig<ComplaintsStatus, ComplaintsStatusDto>().TwoWays();

        config.NewConfig<StudentContentDetailDto, StudentContentDetail>()
            .Ignore(x => x.SessionTasks)
            .Ignore(x => x.SessionProject)
            .Ignore(x => x.SessionQuiz);

        config.NewConfig<StudentContentDetail, StudentContentDetailDto>()
            .Ignore(x => x.SessionTasks)
            .Ignore(x => x.SessionProject)
            .Ignore(x => x.SessionQuiz);
        config.NewConfig<ComplaintsStudent, ComplaintsStudentDto>()
            .Ignore(dest => dest.FilesAttach);

        config.NewConfig<ComplaintsStudentDto, ComplaintsStudent>()
            .Ignore(dest => dest.FilesAttach)
            .Ignore(x => x.ComplaintsNo);

        config.NewConfig<ComplaintsType, ComplaintsTypeDto>().TwoWays();
        config.NewConfig<ProgramsContentDetail, ProgramsContentDetailDto>()
            .Ignore(dest => dest.SessionTasksFile)
            .Ignore(dest => dest.SessionProjectFile)
            .Ignore(dest => dest.ScientificMaterialFile)
            .Ignore(dest => dest.SessionQuiz);

        config.NewConfig<ProgramsContentDetailDto, ProgramsContentDetail>()
            .Ignore(dest => dest.SessionTasks)
            .Ignore(dest => dest.SessionProject)
            .Ignore(dest => dest.ScientificMaterial)
            .Ignore(dest => dest.SessionQuiz);

        config.NewConfig<ProgramsContentMaster, ProgramsContentMasterDto>()
            .Ignore(dest => dest.ScientificMaterial);


        config.NewConfig<ProgramsContentMasterDto, ProgramsContentMaster>()
            .Ignore(dest => dest.ScientificMaterial)
            .Ignore(x => x.SessionNo);

        config.NewConfig<ProgramsDetail, ProgramsDetailDto>();
        config.NewConfig<ProgramsDetailDto, ProgramsDetail>()
            .Ignore(x => x.ProgramNo);

        config.NewConfig<ProjectsMaster, ProjectsMasterDto>()
            .Ignore(dest => dest.ProjectResources);

        config.NewConfig<ProjectsMasterDto, ProjectsMaster>()
            .Ignore(x => x.ProjectResources)
            .Ignore(x => x.ProjectNo);


        config.NewConfig<ProjectsDetail, ProjectsDetailDto>();
        config.NewConfig<ProjectsDetailDto, ProjectsDetail>()
            .Ignore(x => x.ProjectDetailsNo);

            
        config.NewConfig<EduContactResult, EduContactResultDto>()
            .Ignore(dest => dest.Attachment);

        config.NewConfig<EduContactResultDto, EduContactResult>()
            .Ignore(x => x.Attachment)
            .Ignore(x => x.ResultUd);

        config.NewConfig<AppUser, RegisterDto>().TwoWays();
    }
}