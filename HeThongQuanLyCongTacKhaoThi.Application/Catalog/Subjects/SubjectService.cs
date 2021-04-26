using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Subjects;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Subjects
{
    public class SubjectService : ISubjectService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public SubjectService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<SubjectViewModel>>> GetAll()
        {
            var subjects = await _context.Subjects
                .AsNoTracking()
                .Select(x => new SubjectViewModel()
                {
                    ID = x.ID,
                    Name = x.Name
                })
                .ToListAsync();

            return new ApiSuccessResult<List<SubjectViewModel>>(subjects);
        }

        public async Task<ApiResult<PagedResult<SubjectViewModel>>> GetQuestionPaging(GetSubjectPagingRequest request)
        {
            var query = _context.Subjects.Where(q => q.Name.Contains(""));
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = _context.Subjects.Where(q => q.Name.Contains(request.Keyword));
            }
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsNoTracking()
                .Select(x => new SubjectViewModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    LessonCount = x.LessonCount,
                    CreditCount = x.CreditCount
                }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<SubjectViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<SubjectViewModel>>(pagedResult);
        }

        public async Task<ApiResult<SubjectViewModel>> GetByID(string id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return new ApiErrorResult<SubjectViewModel>("Môn học không tồn tại");
            }

            var subjectViewModel = new SubjectViewModel()
            {
                ID = subject.ID,
                Name = subject.Name,
                LessonCount = subject.LessonCount,
                CreditCount = subject.CreditCount
            };

            return new ApiSuccessResult<SubjectViewModel>(subjectViewModel);
        }

        public async Task<ApiResult<bool>> Create(SubjectCURequest request)
        {
            var subject = new Subject()
            {
                ID = request.ID,
                Name = request.Name,
                LessonCount = request.LessonCount,
                CreditCount = request.CreditCount
            };

            _context.Subjects.Add(subject);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm môn học");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Update(string id, SubjectCURequest request)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return new ApiErrorResult<bool>("Không thể tìm thấy môn học");

            subject.Name = request.Name;
            subject.LessonCount = request.LessonCount;
            subject.CreditCount = request.CreditCount;

            _context.Entry(subject).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể sửa môn học");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(string id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null) return new ApiErrorResult<bool>("Không thể tìm thấy môn học");
            _context.Subjects.Remove(subject);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể xoá môn học");
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<List<SubjectViewModel>>> GetSubjectsByAccountID(Guid accountID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var subjects = await (from sa in _context.SubjectAccounts
                                  join s in _context.Subjects on sa.SubjectID equals s.ID
                                  where sa.UserID.ToString() == accountID.ToString()
                                  select new SubjectViewModel()
                                  {
                                      ID = s.ID,
                                      Name = s.Name,
                                      LessonCount = s.LessonCount,
                                      CreditCount = s.CreditCount
                                  })
                                  .ToListAsync();

            return new ApiSuccessResult<List<SubjectViewModel>>(subjects);
        }

        public async Task<ApiResult<bool>> SubjectAssign(string subjectID, SubjectAssignRequest request)
        {
            var subjectAccount = new SubjectAccount()
            {
                UserID = request.AccountID,
                SubjectID = subjectID,
                ClassID = request.ClassID
            };
            _context.SubjectAccounts.Add(subjectAccount);
            _context.Entry(subjectAccount).State = EntityState.Added;
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể gán môn học cho người dùng");
            }

            return new ApiSuccessResult<bool>();
        }
    }
}