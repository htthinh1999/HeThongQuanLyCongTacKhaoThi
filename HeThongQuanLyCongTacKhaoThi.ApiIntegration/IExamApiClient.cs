﻿using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface IExamApiClient
    {
        Task<ApiResult<PagedResult<ExamViewModel>>> GetExamPaging(GetExamPagingRequest request);

        Task<ApiResult<ExamViewModel>> GetByID(int id);

        Task<ApiResult<int>> Create(ExamCreateRequest request);

        Task<ApiResult<int>> Update(int id, ExamUpdateRequest request);

        Task<ApiResult<bool>> Delete(int id);

        Task<ApiResult<List<ExamViewModel>>> GetAllExamsByContestID(int contestID);

        Task<ApiResult<bool>> AddMaxQuestionMark(int examID, List<ExamDetailCURequest> examDetails);

    }
}