﻿using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.TeacherContests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface ITeacherContestApiClient
    {
        Task<ApiResult<bool>> Create(TeacherContestCURequest request);

        Task<ApiResult<bool>> Delete(int contestID);
    }
}
