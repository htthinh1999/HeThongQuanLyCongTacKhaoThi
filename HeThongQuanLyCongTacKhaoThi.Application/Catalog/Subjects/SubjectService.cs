using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Subjects
{
    public class SubjectService : ISubjectService
    {
        public Task<ApiResult<bool>> Create(SubjectCURequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<SubjectViewModel>> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<PagedResult<SubjectViewModel>>> GetQuestionPaging(GetSubjectPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<bool>> Update(int id, SubjectCURequest request)
        {
            throw new NotImplementedException();
        }
    }
}
