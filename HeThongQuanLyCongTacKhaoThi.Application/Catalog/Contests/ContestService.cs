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

        public async Task<ApiResult<int>> Create(ContestCURequest request)
        {
            var contest = new Contest()
            {
                Name = request.Name,
                SubjectID = request.SubjectID,
                ScoreTypeID = request.ScoreTypeID,
                StartTime = request.StartTime,
                Duration = request.Duration,
                Description = request.Description
            };

            _context.Contests.Add(contest);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<int>("Không thể thêm kỳ kiểm tra");
            }

            return new ApiSuccessResult<int>(contest.ID);
        }

        public async Task<ApiResult<bool>> Update(int id, ContestCURequest request)
        {
            var contest = await _context.Contests.FindAsync(id);
            if (contest == null) return new ApiErrorResult<bool>("Không thể tìm thấy kỳ kiểm tra");

            contest.Name = request.Name;
            contest.SubjectID = request.SubjectID;
            contest.ScoreTypeID = request.ScoreTypeID;
            contest.StartTime = request.StartTime;
            contest.Duration = request.Duration;
            contest.Description = request.Description;

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
                ScoreTypeID = contest.ScoreTypeID,
                Description = contest.Description,
                StartTime = contest.StartTime,
                Duration = contest.Duration
            };

            var allTeachers = await _context.TeacherContests.Where(x => x.ContestID == id).ToListAsync();
            contestViewModel.Teacher1ID = allTeachers[0].TeacherID;
            if (allTeachers.Count > 1)
            {
                contestViewModel.Teacher2ID = allTeachers[1].TeacherID;
            }

            return new ApiSuccessResult<ContestViewModel>(contestViewModel);
        }

        public async Task<ApiResult<List<ContestViewModel>>> GetAll()
        {
            var contests = await _context.Contests.Select(x => new ContestViewModel()
                                                  {
                                                      ID = x.ID,
                                                      Name = x.Name,
                                                      SubjectID = x.SubjectID,
                                                      ScoreTypeID = x.ScoreTypeID,
                                                      Description = x.Description,
                                                      StartTime = x.StartTime,
                                                      Duration = x.Duration
                                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

        public async Task<ApiResult<List<ContestViewModel>>> GetAllContestsBySubjectID(string subjectID)
        {
            var contests = await _context.Contests.Where(x => x.SubjectID == subjectID)
                                                  .Select(x => new ContestViewModel()
                                                  {
                                                      ID = x.ID,
                                                      Name = x.Name,
                                                      Description = x.Description,
                                                      StartTime = x.StartTime,
                                                      Duration = x.Duration
                                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

        public async Task<ApiResult<PagedResult<ContestViewModel>>> GetContestPaging(GetContestPagingRequest request)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var query = _context.Contests.Where(c => c.Name.Contains(""));
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = _context.Contests.Where(c => c.Name.Contains(request.Keyword) || c.Duration.ToString().Contains(request.Keyword) ||
                                                     c.SubjectID.Contains(request.Keyword) || c.StartTime.ToString().Contains(request.Keyword));
            }

            var data = from tc in _context.TeacherContests
                       join c in query on tc.ContestID equals c.ID
                       join a in _context.Accounts on tc.TeacherID equals a.Id
                       join st in _context.ScoreTypes on c.ScoreTypeID equals st.ID
                       group new { tc, c, a, st }
                       by new 
                       { 
                           ID = c.ID,
                           SubjectID = st.SubjectID,
                           Name = c.Name,
                           ScoreTypeID = st.ID,
                           ScoreTypeName = st.Name,
                           Description = c.Description,
                           StartTime = c.StartTime,
                           Duration = c.Duration
                       }
                       into x
                       select new ContestViewModel()
                       {
                           ID = x.Key.ID,
                           SubjectID = x.Key.SubjectID,
                           Name = x.Key.Name,
                           ScoreTypeID = x.Key.ID,
                           ScoreTypeName = x.Key.ScoreTypeName,
                           Description = x.Key.Description,
                           StartTime = x.Key.StartTime,
                           Duration = x.Key.Duration,
                           TeacherNames = string.Join(", ", _context.TeacherContests.Join(_context.Accounts, tc => tc.TeacherID, a => a.Id, (tc, a) => new { tc, a })
                                                            .Where(z => z.tc.ContestID == x.Key.ID)
                                                            .Select(x => x.a.Name)
                                                            .ToList()),
                           Teacher1Name = _context.TeacherContests.Join(_context.Accounts, tc => tc.TeacherID, a => a.Id, (tc, a) => new { tc, a })
                                        .Where(z => z.tc.ContestID == x.Key.ID)
                                        .Select(x => x.a.Name)
                                        .FirstOrDefault(),
                           Teacher2Name = _context.TeacherContests.Join(_context.Accounts, tc => tc.TeacherID, a => a.Id, (tc, a) => new { tc, a })
                                        .Where(z => z.tc.ContestID == x.Key.ID)
                                        .Select(x => x.a.Name)
                                        .Skip(1)
                                        .FirstOrDefault()
                       };

            var items = await data.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .AsNoTracking().ToListAsync();

            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<ContestViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = items
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
                                      Name = c.Name,
                                      Description = c.Description,
                                      StartTime = c.StartTime,
                                      Duration = c.Duration
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
                                      Name = c.Name,
                                      Description = c.Description,
                                      StartTime = c.StartTime,
                                      Duration = c.Duration
                                  }).ToListAsync();

            return new ApiSuccessResult<List<ContestViewModel>>(contests);
        }

    }
}
