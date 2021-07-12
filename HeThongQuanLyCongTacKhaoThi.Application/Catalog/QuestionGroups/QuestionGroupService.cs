using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.QuestionGroups;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.QuestionGroups
{
    public class QuestionGroupService : IQuestionGroupService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public QuestionGroupService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<QuestionGroupViewModel>>> GetAll()
        {
            var questionGroups = await _context.QuestionGroups
                                .AsNoTracking()
                                .Select(x => new QuestionGroupViewModel()
                                {
                                    ID = x.ID,
                                    Name = x.Name
                                }).ToListAsync();
            return new ApiSuccessResult<List<QuestionGroupViewModel>>(questionGroups);
        }

        public async Task<ApiResult<QuestionGroupViewModel>> GetByID(int id)
        {
            var questionGroup = await _context.QuestionGroups.FindAsync(id);

            var questionGroupViewModel = new QuestionGroupViewModel()
            {
                ID = questionGroup.ID,
                Name = questionGroup.Name
            };

            if (questionGroup == null)
            {
                return new ApiErrorResult<QuestionGroupViewModel>("Nhóm câu hỏi không tồn tại");
            }
            return new ApiSuccessResult<QuestionGroupViewModel>(questionGroupViewModel);
        }
    }
}