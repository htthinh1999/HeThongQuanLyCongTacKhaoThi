using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Subjects
{
    public interface ISubjectService
    {
        Task<ApiResult<bool>> Create(SubjectCURequest request);

        Task<ApiResult<bool>> Update(string id, SubjectCURequest request);

        Task<ApiResult<bool>> Delete(string id);

        Task<ApiResult<PagedResult<SubjectViewModel>>> GetQuestionPaging(GetSubjectPagingRequest request);

        Task<ApiResult<SubjectViewModel>> GetByID(string id);

        Task<ApiResult<List<SubjectViewModel>>> GetAll();

        Task<ApiResult<List<SubjectViewModel>>> GetSubjectsByAccountID(Guid accountID);

        Task<ApiResult<List<SubjectViewModel>>> GetSubjectsNotJoinedByAccountID(Guid accountID);

        Task<ApiResult<bool>> SubjectAssign(string subjectID, Guid accountID);

        Task<ApiResult<bool>> EditTeacherSubjects(Guid teacherID, List<string> subjectIDs);
    }
}