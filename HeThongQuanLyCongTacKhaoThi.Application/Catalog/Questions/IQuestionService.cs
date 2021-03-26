using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Questions
{
    public interface IQuestionService
    {
        Task<ApiResult<int>> Create(QuestionCURequest request);
        Task<ApiResult<bool>> Update(int id, QuestionCURequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<PagedResult<QuestionViewModel>>> GetQuestionPaging(GetQuestionPagingRequest request);
        Task<ApiResult<QuestionViewModel>> GetByID(int id);
        ApiResult<bool> ExistQuestionInExam(int id);
    }
}
