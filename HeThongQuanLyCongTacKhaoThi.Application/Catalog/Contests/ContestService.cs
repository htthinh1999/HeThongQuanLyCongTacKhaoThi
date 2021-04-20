using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Contests;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Contests
{
    public class ContestService : IContestService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public ContestService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(ContestCURequest request)
        {
            var contest = new Contest()
            {
                Name = request.Name,
                SubjectID = request.SubjectID,
                ScoreTypeID = request.ScoreTypeID
            };

            _context.Contests.Add(contest);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm kỳ kiểm tra");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(int id, ContestCURequest request)
        {
            var contest = await _context.Contests.FindAsync(id);
            if (contest == null) return new ApiErrorResult<bool>("Không thể tìm thấy kỳ kiểm tra");

            contest.Name = request.Name;
            contest.SubjectID = request.SubjectID;
            contest.ScoreTypeID = request.ScoreTypeID;

            _context.Entry(contest).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể cập nhật kỳ kiểm tra");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(int id)
        {
            var contest = await _context.Contests.FindAsync(id);
            if (contest == null) return new ApiErrorResult<bool>("Không thể tìm thấy kỳ kiểm tra");

            _context.Remove(contest);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá kỳ kiểm tra");
            }
            return new ApiSuccessResult<bool>();

        }

        public async Task<ApiResult<ContestViewModel>> GetByID(int id)
        {
            var contest = await _context.Contests.FindAsync(id);
            if (contest == null) return new ApiErrorResult<ContestViewModel>("Không thể tìm thấy kỳ kiểm tra");

            var contestViewModel = new ContestViewModel()
            {
                ID = id,
                Name = contest.Name,
                SubjectID = contest.SubjectID,
                ScoreTypeID = contest.ScoreTypeID
            };

            return new ApiSuccessResult<ContestViewModel>(contestViewModel);
        }

        public async Task<ApiResult<List<ContestViewModel>>> GetAll()
        {
            var contests = await _context.Contests.Select(x => new ContestViewModel()
                                                  {
                                                      ID = x.ID,
                                                      Name = x.Name,
                                                      SubjectID = x.SubjectID,
                                                      ScoreTypeID = x.ScoreTypeID
                                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

        public async Task<ApiResult<List<ContestViewModel>>> GetAllContestsBySubjectID(string subjectID)
        {
            var contests = await _context.Contests.Where(x => x.SubjectID == subjectID)
                                                  .Select(x => new ContestViewModel()
                                                  {
                                                      ID = x.ID,
                                                      Name = x.Name
                                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

        public async Task<ApiResult<PagedResult<ContestViewModel>>> GetContestPaging(GetContestPagingRequest request)
        {
            var query = _context.Contests.Where(c => c.Name.Contains(""));
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = _context.Contests.Where(c => c.Name.Contains(request.Keyword));
            }

            var data = await query.Join(_context.ScoreTypes, c=>c.ScoreTypeID, st=>st.ID, (c, st) => new { c, st })
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsNoTracking()
                .Select(x => new ContestViewModel()
                {
                    ID = x.c.ID,
                    Name = x.c.Name,
                    SubjectID = x.c.SubjectID,
                    ScoreTypeID = x.c.ScoreTypeID,
                    ScoreTypeName = x.st.Name
                }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<ContestViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<ContestViewModel>>(pagedResult);
        }

        public async Task<ApiResult<bool>> ContestWasUsedInExam(int id)
        {
            var exam = await _context.Exams.FirstOrDefaultAsync(e => e.ContestID == id);
            if(exam == null)
            {
                return new ApiErrorResult<bool>("Kỳ thi đã được áp dụng trong đề thi");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<string>> GetSubjectIDByContestID(int contestID)
        {
            var result = await _context.Contests.FindAsync(contestID);
            if (result == null)
            {
                return new ApiErrorResult<string>("Không thể tìm thấy kỳ thi");
            }

            return new ApiSuccessResult<string>(result.SubjectID);
        }

        public async Task<ApiResult<List<ContestViewModel>>> GetAllContestsDidNotJoin(Guid accountID, string subjectID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var contests = await (from c in _context.Contests
                                  where !_context.Results.Any(x => x.ContestID == c.ID && x.UserID == accountID) && c.SubjectID == subjectID
                                  select new ContestViewModel()
                                  {
                                      ID = c.ID,
                                      Name = c.Name
                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

        public async Task<ApiResult<List<ContestViewModel>>> GetAllContestsWasJoined(Guid accountID, string subjectID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var contests = await (from rs in _context.Results
                                  join c in _context.Contests on rs.ContestID equals c.ID
                                  where rs.UserID == accountID && rs.SubjectID == subjectID
                                  select new ContestViewModel()
                                  {
                                      ID = c.ID,
                                      Name = c.Name
                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

    }
}
