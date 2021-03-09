using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Answers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Services
{
    public interface IQuestionApiClient
    {
        Task<ApiResult<PagedResult<QuestionViewModel>>> GetQuestionPaging(GetQuestionPagingRequest request);
        Task<ApiResult<QuestionViewModel>> GetByID(int id);
        Task<ApiResult<int>> Create(QuestionCreateUpdateRequest request, List<AnswerCreateUpdateRequest> answerCreateUpdateRequests);
        Task<ApiResult<bool>> Update(int id, QuestionCreateUpdateRequest request, List<AnswerCreateUpdateRequest> answerCreateUpdateRequests);
        Task<ApiResult<bool>> Delete(int id);
    }
}
