using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.ScoreType;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.ScoreTypes
{
    public class ScoreTypeService : IScoreTypeService
    {
        HeThongQuanLyCongTacKhaoThiDbContext _context;

        public ScoreTypeService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<ScoreTypeViewModel>>> GetAll()
        {
            var scoreTypes = await _context.ScoreTypes.Select(x => new ScoreTypeViewModel()
            {
                ID = x.ID,
                Name = x.Name,
                SubjectID = x.SubjectID
            }).ToListAsync();

            return new ApiSuccessResult<List<ScoreTypeViewModel>>(scoreTypes);
        }

        public async Task<ApiResult<List<ScoreTypeViewModel>>> GetAllBySubjectID(string subjectID)
        {
            var scoreTypes = await _context.ScoreTypes.Where(x=> x.SubjectID == subjectID)
                                                      .Select(x => new ScoreTypeViewModel()
                                                      {
                                                          ID = x.ID,
                                                          Name = x.Name,
                                                          SubjectID = x.SubjectID
                                                      }).ToListAsync();

            return new ApiSuccessResult<List<ScoreTypeViewModel>>(scoreTypes);
        }
    }
}
