using Entities.Models;
using Infrastructure.Communication;
using Logic.Implementations.BasicInformation;
using Logic.Implementations.Chat;
using Logic.Implementations.Complaints;
using Logic.Implementations.Helpers;
using Logic.Implementations.System;
using Logic.Interfaces.BasicInformation;
using Logic.Interfaces.Chat;
using Logic.Interfaces.Complaints;
using Logic.Interfaces.Helpers;
using Logic.Interfaces.Identity;
using Logic.Interfaces.System;
using Logic.Services.Communication;
using Logic.Services.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logic;

public static class LogiInjection
{
    public static IServiceCollection AddLogic(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IChatMessage, ChatMessageLogic>();
        services.AddScoped<IAcademyClaseDetail, AcademyClaseDetailLogic>();
        services.AddScoped<IAcademyClaseMaster, AcademyClaseMasterLogic>();
        services.AddScoped<IAcademyClaseType, AcademyClaseTypeLogic>();
        services.AddScoped<IAcademyData, AcademyDataLogic>();
        services.AddScoped<IAcademyJob, AcademyJobLogic>();
        services.AddScoped<IBranchData, BranchDataLogic>();
        services.AddScoped<ICityCode, CityCodeLogic>();
        services.AddScoped<ICountryCode, CountryCodeLogic>();
        services.AddScoped<IGovernorateCode, GovernorateCodeLogic>();

        services.AddScoped<IComplaintsStatus, ComplaintsStatusLogic>();
        services.AddScoped<IComplaintsStudent, ComplaintsStudentLogic>();
        services.AddScoped<IComplaintsType, ComplaintsTypeLogic>();

        services.AddScoped<IEduContactResult, EduContactResultLogic>();
        services.AddScoped<IProgramsContentDetail, ProgramsContentDetailLogic>();
        services.AddScoped<IProgramsContentMaster, ProgramsContentMasterLogic>();
        services.AddScoped<IProgramsDetail, ProgramsDetailLogic>();
        services.AddScoped<IProjectsDetail, ProjectsDetailLogic>();
        services.AddScoped<IProjectsMaster, ProjectsMasterLogic>();
        services.AddScoped<IQuestionBankDetail, QuestionBankDetailLogic>();
        services.AddScoped<IQuestionBankMaster, QuestionBankMasterLogic>();
        services.AddScoped<ISkillDevelopment, SkillDevelopmentLogic>();
        services.AddScoped<IStudentAttend, StudentAttendLogic>();
        services.AddScoped<IStudentContentDetail, StudentContentDetailLogic>();
        services.AddScoped<IStudentData, StudentDataLogic>();
        services.AddScoped<IStudentEvaluation, StudentEvaluationLogic>();
        services.AddScoped<IStudentGroup, StudentGroupLogic>();
        services.AddScoped<ITeacherData, TeacherDataLogic>();
        services.AddScoped<ITwilioService, TwilioService>();
        services.AddScoped<IAccountService, AccountService>();
        return services;
    }
    
}