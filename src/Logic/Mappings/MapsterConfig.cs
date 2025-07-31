using Dtos.BasicInformation;
using Dtos.System;
using Entities.Models;
using Mapster;
namespace Logic.Mappings;

public class MapsterConfig :IRegister
{


    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<StudentAttend, StudentAttendDto>().TwoWays();
        config.NewConfig<StudentEvaluation, StudentEvaluationDto>().TwoWays();
        config.NewConfig<StudentGroup, StudentGroupDto>().TwoWays();
        config.NewConfig<TeacherData, TeacherDataDto>().TwoWays();
        config.NewConfig<SkillDevelopment, SkillDevelopmentDto>()
            .Ignore(dest => dest.FilesAttach);
        config.NewConfig<SkillDevelopmentDto, SkillDevelopment>()
            .Ignore(dest => dest.FilesAttach);
        
        config.NewConfig<StudentData, StudentDataDto>().TwoWays(); 
        config.NewConfig<QuestionBankDetail, QuestionBankDetailDto>().TwoWays();
        config.NewConfig<QuestionBankMaster, QuestionBankMasterDto>().TwoWays();
        config.NewConfig<AcademyClaseMaster, AcademyClaseMasterDto>().TwoWays();
        config.NewConfig<AcademyClaseType, AcademyClaseTypeDto>().TwoWays();
        config.NewConfig<AcademyClaseDetail, AcademyClaseDetailDto>().TwoWays();
        config.NewConfig<AcademyData, AcademyDataDto>().Ignore(x=>x.Image).Ignore(x=>x.Attachments);
        config.NewConfig<AcademyDataDto, AcademyData>()
            .Ignore(x => x.ImageUrl)
            .Ignore(x => x.AttachFiles);

    }
}