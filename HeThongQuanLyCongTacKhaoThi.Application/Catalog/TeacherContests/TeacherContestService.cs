using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.TeacherContests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.TeacherContests
{
    public class TeacherContestService : ITeacherContestService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public TeacherContestService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(TeacherContestCURequest request)
        {
            var teacherContest = new TeacherContest()
            {
                ContestID = request.ContestID,
                TeacherID = request.TeacherID
            };

            _context.TeacherContests.Add(teacherContest);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm giáo viên chấm thi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int contestID)
        {
            var teacherContests = await _context.TeacherContests.Where(x => x.ContestID == contestID).ToListAsync();

            foreach(var teacherContest in teacherContests)
            {
                _context.TeacherContests.Remove(teacherContest);
            }
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá giáo viên chấm thi");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<List<string>>> GetAllTeacherIDsInContest(int contestID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var teacherIDs = await _context.TeacherContests.Where(x => x.ContestID == contestID).Select(x => x.TeacherID.ToString().ToLower()).ToListAsync();

            return new ApiSuccessResult<List<string>>(teacherIDs);
        }
    }
}
