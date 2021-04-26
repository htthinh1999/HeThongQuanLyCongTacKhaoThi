using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Contests
{
    public interface IContestService
    {
        Task<ApiResult<int>> Create(ContestCURequest request);

        Task<ApiResult<bool>> Update(int id, ContestCURequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<List<ContestViewModel>>> GetAllContestsBySubjectID(string subjectID);

        Task<ApiResult<string>> GetSubjectIDByContestID(int contestID);

        Task<ApiResult<List<ContestViewModel>>> GetAll();

        Task<ApiResult<PagedResult<ContestViewModel>>> GetContestPaging(GetContestPagingRequest request);

        Task<ApiResult<ContestViewModel>> GetByID(int id);

        Task<ApiResult<bool>> ContestWasUsedInExam(int id);

        Task<ApiResult<List<ContestViewModel>>> GetAllContestsDidNotJoin(Guid accountID, string subjectID);

        Task<ApiResult<List<ContestViewModel>>> GetAllContestsWasJoined(Guid accountID, string subjectID);
    }
}
