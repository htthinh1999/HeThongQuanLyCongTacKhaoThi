using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Results;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Exams;
using Microsoft.EntityFrameworkCore;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.StudentAnswers;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Questions;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Answers;
using Microsoft.AspNetCore.Identity;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Results
{
    public class ResultService : IResultService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;
        private readonly UserManager<Account> _userManager;

        public ResultService(HeThongQuanLyCongTacKhaoThiDbContext context, UserManager<Account> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<ApiResult<bool>> Create(ResultCURequest request)
        {
            var mResult = _context.Results.FirstOrDefault(x => x.UserID == request.UserID && x.ContestID == request.ContestID);

            _context.Results.Add(new Result()
            {
                UserID = request.UserID,
                ContestID = request.ContestID,
                ExamID = request.ExamID,
                SubjectID = request.SubjectID,
                StudentAnswerID = request.StudentAnswerID,
                Time = (mResult == null) ? 1 : 2
            });

            var result = await _context.SaveChangesAsync();
            if(result == 0)
            {
                return new ApiErrorResult<bool>("Không thể tạo kết quả");
            }
            return new ApiSuccessResult<bool>();
        }


        public async Task<ApiResult<PagedResult<ExamResultViewModel>>> GetExamResultPaging(GetExamResultPagingRequest request)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            request.Keyword = (string.IsNullOrEmpty(request.Keyword)) ? "" : request.Keyword;

            var teacher = await _userManager.FindByIdAsync(request.TeacherID.ToString());
            var teacherRole = await _userManager.GetRolesAsync(teacher);

            var query = from rs in _context.Results
                        join c in _context.Contests on rs.ContestID equals c.ID
                        join tc in _context.TeacherContests on c.ID equals tc.ContestID
                        join e in _context.Exams on rs.ExamID equals e.ID
                        join ed in _context.ExamDetails on e.ID equals ed.ExamID
                        join q in _context.Questions on ed.QuestionID equals q.ID
                        where ((teacherRole[0] != "Admin") ? tc.TeacherID == request.TeacherID : true) &&
                                (e.Name.Contains(request.Keyword) ||
                                rs.StudentAnswerID.ToString().Contains(request.Keyword) ||
                                c.Name.Contains(request.Keyword) ||
                                rs.Mark1.ToString().Contains(request.Keyword) ||
                                rs.Mark2.ToString().Contains(request.Keyword) ||
                                rs.Mark.ToString().Contains(request.Keyword))
                        group new { rs, e, q, c } by new { rs.StudentAnswerID, e.Name, ContestName = c.Name, Mark1 = rs.Mark1, Mark2 = rs.Mark2, Mark = rs.Mark } into exam
                        select new ExamResultViewModel()
                        {
                            Name = exam.Key.Name,
                            ContestName = exam.Key.ContestName,
                            MultipleChoiceQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                            EssayQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 0 : 1),
                            StudentAnswerID = exam.Key.StudentAnswerID,
                            Mark1 = exam.Key.Mark1,
                            Mark2 = exam.Key.Mark2,
                            Mark = exam.Key.Mark,
                            studentAnswerDetails = new List<StudentAnswerDetailViewModel>()
                        };

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .AsNoTracking()
                .Select(x => new ExamResultViewModel()
                {
                    StudentAnswerID = x.StudentAnswerID,
                    Name = x.Name,
                    ContestName = x.ContestName,
                    MultipleChoiceQuestionCount = x.MultipleChoiceQuestionCount,
                    EssayQuestionCount = x.EssayQuestionCount,
                    Mark1 = x.Mark1,
                    Mark2 = x.Mark2,
                    Mark = x.Mark,
                    studentAnswerDetails = x.studentAnswerDetails
                }).ToListAsync();

            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<ExamResultViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<ExamResultViewModel>>(pagedResult);
        }

        public async Task<ApiResult<int>> GetTeacherNumber(Guid studentAnswerID, Guid teacherID)
        {
            var contest = await (from r in _context.Results
                                 where r.StudentAnswerID == studentAnswerID
                                 select r).FirstOrDefaultAsync();
            int contestID = contest.ContestID;
            List<Guid> teacherIDs = await (from tc in _context.TeacherContests
                                           where tc.ContestID == contestID
                                           orderby tc.TeacherID
                                           select tc.TeacherID).ToListAsync();

            return new ApiSuccessResult<int>((teacherIDs[0] == teacherID) ? 1 : 2);
        }

        public async Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid accountID, int contestID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var examResult = await (from rs in _context.Results
                              join e in _context.Exams on rs.ExamID equals e.ID
                              join ed in _context.ExamDetails on e.ID equals ed.ExamID
                              join q in _context.Questions on ed.QuestionID equals q.ID
                              where e.ContestID == contestID && rs.UserID == accountID
                              group new { rs, e, q } by new { rs.StudentAnswerID, e.Name, rs.Mark1, rs.Mark2, rs.Mark } into exam
                              select new ExamResultViewModel()
                              {
                                  Name = exam.Key.Name,
                                  MultipleChoiceQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                  EssayQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                  Mark1 = exam.Key.Mark1,
                                  Mark2 = exam.Key.Mark2,
                                  Mark = exam.Key.Mark,
                                  StudentAnswerID = exam.Key.StudentAnswerID,
                                  studentAnswerDetails = new List<StudentAnswerDetailViewModel>()
                              }).FirstOrDefaultAsync();

            if(examResult == null)
            {
                return new ApiErrorResult<ExamResultViewModel>("Không thể lấy kết quả đề thi");
            }

            var studentAnswerDetails = await (from stad in _context.StudentAnswerDetails
                                             join q in _context.Questions on stad.QuestionID equals q.ID
                                             where stad.StudentAnswerID == examResult.StudentAnswerID
                                             orderby q.IsMultipleChoice
                                             select new StudentAnswerDetailViewModel()
                                             {
                                                 AnswerID = stad.AnswerID,
                                                 QuestionID = q.ID,
                                                 EssayPath = stad.EssayPath,
                                                 StudentAnswerContent = stad.StudentAnswerContent,
                                                 Teacher1Comment = stad.Teacher1Comment,
                                                 Teacher2Comment = stad.Teacher2Comment,
                                                 Mark1 = stad.Mark1,
                                                 Mark2 = stad.Mark2,
                                                 Mark = stad.Mark,
                                                 Question = new QuestionViewModel()
                                                 {
                                                     ID = q.ID,
                                                     Content = q.Content,
                                                     IsMultipleChoice = q.IsMultipleChoice,
                                                     Answers = new List<AnswerCURequest>()
                                                 }
                                             }).ToListAsync();

            foreach(var studentAnswerDetail in studentAnswerDetails)
            {
                // Get all answers of question
                var answers = await (from a in _context.Answers
                                      where a.QuestionID == studentAnswerDetail.QuestionID
                                      select new AnswerCURequest()
                                      {
                                          ID = a.ID,
                                          QuestionID = a.QuestionID,
                                          Content = a.Content,
                                          IsCorrect = a.IsCorrect
                                      }).ToListAsync();

                studentAnswerDetail.Question.Answers = answers.ToList();
            }
            

            examResult.studentAnswerDetails = studentAnswerDetails.ToList();

            return new ApiSuccessResult<ExamResultViewModel>(examResult);
        }

        public async Task<ApiResult<ExamResultViewModel>> GetExamResult(Guid studentAnswerID, Guid teacherID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var teacher = await _userManager.FindByIdAsync(teacherID.ToString());
            var teacherRole = await _userManager.GetRolesAsync(teacher);

            if(teacherRole[0] != "Admin")
            {
                var teacherExistInContest = await (from rs in _context.Results
                                                   join c in _context.Contests on rs.ContestID equals c.ID
                                                   join tc in _context.TeacherContests on c.ID equals tc.ContestID
                                                   where tc.TeacherID == teacherID && rs.StudentAnswerID == studentAnswerID
                                                   select tc.TeacherID).FirstOrDefaultAsync();
                if (teacherExistInContest == Guid.Empty)
                {
                    return new ApiErrorResult<ExamResultViewModel>("Bạn không phải là giảng viên coi thi");
                }
            }

            var examResult = await (from rs in _context.Results
                                    join c in _context.Contests on rs.ContestID equals c.ID
                                    join tc in _context.TeacherContests on c.ID equals tc.ContestID
                                    join e in _context.Exams on rs.ExamID equals e.ID
                                    join ed in _context.ExamDetails on e.ID equals ed.ExamID
                                    join q in _context.Questions on ed.QuestionID equals q.ID
                                    where rs.StudentAnswerID == studentAnswerID
                                    group new { rs, e, q, c } by new 
                                    {
                                        rs.StudentAnswerID,
                                        e.Name,
                                        ContestName = c.Name,
                                        Mark1 = rs.Mark1,
                                        Mark2 = rs.Mark2,
                                        Mark = rs.Mark
                                    } into exam
                                    select new ExamResultViewModel()
                                    {
                                        Name = exam.Key.Name,
                                        ContestName = exam.Key.ContestName,
                                        MultipleChoiceQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                        EssayQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                        StudentAnswerID = exam.Key.StudentAnswerID,
                                        Mark1 = exam.Key.Mark1,
                                        Mark2 = exam.Key.Mark2,
                                        Mark = exam.Key.Mark,
                                        studentAnswerDetails = new List<StudentAnswerDetailViewModel>()
                                    }).FirstOrDefaultAsync();

            if (examResult == null)
            {
                return new ApiErrorResult<ExamResultViewModel>("Không thể lấy kết quả đề thi");
            }

            var studentAnswerDetails = await (from stad in _context.StudentAnswerDetails
                                              join q in _context.Questions on stad.QuestionID equals q.ID
                                              where stad.StudentAnswerID == examResult.StudentAnswerID
                                              orderby q.IsMultipleChoice
                                              select new StudentAnswerDetailViewModel()
                                              {
                                                  AnswerID = stad.AnswerID,
                                                  QuestionID = q.ID,
                                                  EssayPath = stad.EssayPath,
                                                  StudentAnswerContent = stad.StudentAnswerContent,
                                                  Teacher1Comment = stad.Teacher1Comment,
                                                  Teacher2Comment = stad.Teacher2Comment,
                                                  Mark1 = stad.Mark1,
                                                  Mark2 = stad.Mark2,
                                                  Mark = stad.Mark,
                                                  Question = new QuestionViewModel()
                                                  {
                                                      ID = q.ID,
                                                      Content = q.Content,
                                                      IsMultipleChoice = q.IsMultipleChoice,
                                                      Answers = new List<AnswerCURequest>()
                                                  }
                                              }).ToListAsync();

            foreach (var studentAnswerDetail in studentAnswerDetails)
            {
                // Get all answers of question
                var answers = await (from a in _context.Answers
                                     where a.QuestionID == studentAnswerDetail.QuestionID
                                     select new AnswerCURequest()
                                     {
                                         ID = a.ID,
                                         QuestionID = a.QuestionID,
                                         Content = a.Content,
                                         IsCorrect = a.IsCorrect
                                     }).ToListAsync();

                studentAnswerDetail.Question.Answers = answers.ToList();
            }


            examResult.studentAnswerDetails = studentAnswerDetails.ToList();

            return new ApiSuccessResult<ExamResultViewModel>(examResult);
        }

        public async Task<ApiResult<ExamResultViewModel>> GetExamResultToMark(Guid studentAnswerID, Guid teacherID)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;


            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var teacherExistInContest = await (from rs in _context.Results
                                               join c in _context.Contests on rs.ContestID equals c.ID
                                               join tc in _context.TeacherContests on c.ID equals tc.ContestID
                                               where tc.TeacherID == teacherID && rs.StudentAnswerID == studentAnswerID
                                               select tc.TeacherID).FirstOrDefaultAsync();
            if (teacherExistInContest == Guid.Empty)
            {
                return new ApiErrorResult<ExamResultViewModel>("Bạn không phải là giảng viên coi thi");
            }

            var examResult = await (from rs in _context.Results
                                    join e in _context.Exams on rs.ExamID equals e.ID
                                    join ed in _context.ExamDetails on e.ID equals ed.ExamID
                                    join q in _context.Questions on ed.QuestionID equals q.ID
                                    where rs.StudentAnswerID == studentAnswerID
                                    group new { rs, e, q } by new { rs.StudentAnswerID, e.Name } into exam
                                    select new ExamResultViewModel()
                                    {
                                        Name = exam.Key.Name,
                                        MultipleChoiceQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                        EssayQuestionCount = exam.Sum(x => (x.q.IsMultipleChoice) ? 1 : 0),
                                        StudentAnswerID = exam.Key.StudentAnswerID,
                                        studentAnswerDetails = new List<StudentAnswerDetailViewModel>()
                                    }).FirstOrDefaultAsync();

            if (examResult == null)
            {
                return new ApiErrorResult<ExamResultViewModel>("Không thể lấy kết quả đề thi");
            }

            var studentAnswerDetails = await (from stad in _context.StudentAnswerDetails
                                              join q in _context.Questions on stad.QuestionID equals q.ID
                                              where stad.StudentAnswerID == examResult.StudentAnswerID
                                              orderby q.IsMultipleChoice
                                              select new StudentAnswerDetailViewModel()
                                              {
                                                  AnswerID = stad.AnswerID,
                                                  QuestionID = q.ID,
                                                  EssayPath = stad.EssayPath,
                                                  StudentAnswerContent = stad.StudentAnswerContent,
                                                  Teacher1Comment = stad.Teacher1Comment,
                                                  Teacher2Comment = stad.Teacher2Comment,
                                                  Mark1 = stad.Mark1,
                                                  Mark2 = stad.Mark2,
                                                  Mark = stad.Mark,
                                                  Question = new QuestionViewModel()
                                                  {
                                                      ID = q.ID,
                                                      Content = q.Content,
                                                      IsMultipleChoice = q.IsMultipleChoice,
                                                      Answers = new List<AnswerCURequest>()
                                                  }
                                              }).ToListAsync();

            // Check teacher marked the exam
            var contest = await (from r in _context.Results
                                 where r.StudentAnswerID == studentAnswerID
                                 select r).FirstOrDefaultAsync();
            int contestID = contest.ContestID;
            List<Guid> teacherIDs = await (from tc in _context.TeacherContests
                                           where tc.ContestID == contestID
                                           orderby tc.TeacherID
                                           select tc.TeacherID).ToListAsync();

            int teacherNumber = (teacherIDs[0] == teacherID) ? 1 : 2;

            if ((teacherNumber == 1 && studentAnswerDetails[0].Mark1 != null)
                || (teacherIDs.Count == 2 && teacherNumber == 2 && studentAnswerDetails[0].Mark2 != null))
            {
                return new ApiErrorResult<ExamResultViewModel>("Bạn đã chấm điểm bài thi này!");
            }

            foreach (var studentAnswerDetail in studentAnswerDetails)
            {
                // Get all answers of question
                var answers = await (from a in _context.Answers
                                     where a.QuestionID == studentAnswerDetail.QuestionID
                                     select new AnswerCURequest()
                                     {
                                         ID = a.ID,
                                         QuestionID = a.QuestionID,
                                         Content = a.Content,
                                         IsCorrect = a.IsCorrect
                                     }).ToListAsync();

                studentAnswerDetail.Question.Answers = answers.ToList();
            }


            examResult.studentAnswerDetails = studentAnswerDetails.ToList();

            return new ApiSuccessResult<ExamResultViewModel>(examResult);
        }

        public async Task<ApiResult<bool>> MarkExam(Guid teacherID, Guid studentAnswerID,
            Dictionary<int, float> questionMarked, Dictionary<int, string> questionCommented)
        {
            var studentAnswerDetailsToMark = await (from sad in _context.StudentAnswerDetails
                                              where sad.StudentAnswerID == studentAnswerID 
                                              && questionMarked.Keys.Any(x => x == sad.QuestionID)
                                              select sad).ToListAsync();

            var examResult = await (from r in _context.Results
                          where r.StudentAnswerID == studentAnswerID
                          select r).FirstOrDefaultAsync();
            int contestID = examResult.ContestID;

            List<Guid> teacherIDs = await (from tc in _context.TeacherContests
                                           where tc.ContestID == contestID
                                           orderby tc.TeacherID
                                           select tc.TeacherID).ToListAsync();

            foreach(var questionID in questionMarked.Keys)
            {
                var markLargerMaxMark = await _context.ExamDetails.AsNoTracking()
                                            .Where(x => x.QuestionID == questionID && x.MaxQuestionMark < questionMarked[questionID])
                                            .FirstOrDefaultAsync();

                if (markLargerMaxMark != null)
                {
                    return new ApiErrorResult<bool>("Không thể chấm điểm cao hơn điểm cho phép!");
                }
            }

            int teacherNumber = (teacherIDs[0] == teacherID) ? 1 : 2;

            if(teacherNumber == 1)
            {
                examResult.Mark1 = 0;
            }
            else
            {
                examResult.Mark2 = 0;
            }

            foreach (var item in studentAnswerDetailsToMark)
            {
                if(teacherNumber == 1)
                {
                    item.Mark1 = questionMarked[item.QuestionID];
                    item.Teacher1Comment = questionCommented[item.QuestionID];
                    examResult.Mark1 += item.Mark1;
                }
                else
                {
                    item.Mark2 = questionMarked[item.QuestionID];
                    item.Teacher2Comment = questionCommented[item.QuestionID];
                    examResult.Mark2 += item.Mark2;
                }

                item.Mark = (teacherIDs.Count == 2 
                            && item.Mark1 != null 
                            && item.Mark2 != null) ? (item.Mark1 + item.Mark2) / 2 : item.Mark1;

                if(item.Mark != null)
                {
                    examResult.Mark = (examResult.Mark == null) ? item.Mark 
                                                                : examResult.Mark + item.Mark;
                }
            }

            // Total mark of multiple choice question
            var studentAnswerDetailsWithMultipleChoice = await (from sad in _context.StudentAnswerDetails
                                                                join q in _context.Questions on sad.QuestionID equals q.ID
                                                                where q.IsMultipleChoice == true && sad.StudentAnswerID == studentAnswerID
                                                                select sad).ToListAsync();

            examResult.Mark1 += studentAnswerDetailsWithMultipleChoice.Sum(x => x.Mark1);
            examResult.Mark2 += studentAnswerDetailsWithMultipleChoice.Sum(x => x.Mark2);
            examResult.Mark += studentAnswerDetailsWithMultipleChoice.Sum(x => x.Mark);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm điểm cho học viên");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<ScoreListViewModel>> GetScoreList(Guid teacherID)
        {
            var result = new ScoreListViewModel();
            var scoreList = await GetScoreListFromDB(teacherID);

            if (scoreList == null)
            {
                return new ApiSuccessResult<ScoreListViewModel>(result);
            }

            var scoreListGroupByStudents = scoreList.GroupBy(x => new { x.StudentID, x.Name })
                             .Select(scores => scores.ToList())
                             .ToList();

            foreach(var scoreListGroupByStudent in scoreListGroupByStudents)
            {
                var scoreListGroupByStudentAndSubjects = scoreListGroupByStudent.GroupBy(x => x.SubjectName)
                                                            .Select(score => score.ToList())
                                                            .ToList();
                var studentResult = new ScoreListViewModel.StudentResult()
                {
                    Name = scoreListGroupByStudent.First().Name,
                    StudentID = scoreListGroupByStudent.First().StudentID
                };

                var subjectResults = new List<ScoreListViewModel.SubjectResult>();

                foreach(var scores in scoreListGroupByStudentAndSubjects)
                {
                    var subjectResult = new ScoreListViewModel.SubjectResult()
                    {
                        Name = scores.First().SubjectName,
                        FinalScore = null,
                        Scores = scores.Select(score => new ScoreListViewModel.ScoreModel()
                        {
                            Name = score.ScoreName,
                            Percent = score.Percent,
                            Score = score.Score
                        }).ToList()
                    };


                    if (subjectResult.Scores.Count >= 4)
                    {
                        subjectResult.FinalScore = subjectResult.Scores.Sum(x => x.Score * x.Percent);
                    }

                    subjectResults.Add(subjectResult);
                }

                studentResult.SubjectResults = subjectResults;

                result.StudentResults.Add(studentResult);
            }


            return new ApiSuccessResult<ScoreListViewModel>(result);
        }

        private async Task<List<ScoreListFromDBModel>> GetScoreListFromDB(Guid teacherID)
        {
            if(teacherID == Guid.Empty)
                return await (from r in _context.Results
                            join c in _context.Contests on r.ContestID equals c.ID
                            join s in _context.Subjects on c.SubjectID equals s.ID
                            join st in _context.ScoreTypes on c.ScoreTypeID equals st.ID
                            join a in _context.Accounts on r.UserID equals a.Id
                            join ur in _context.UserRoles on a.Id equals ur.UserId
                            join role in _context.Roles on ur.RoleId equals role.Id
                            where role.Name == Roles.Student
                            group a by new { StudentID = a.Student_TeacherID, a.Name, SubjectName = s.Name, ScoreName = st.Name, st.Percent, Score = r.Mark } into result
                            select new ScoreListFromDBModel()
                            {
                                StudentID = result.Key.StudentID,
                                Name = result.Key.Name,
                                SubjectName = result.Key.SubjectName,
                                ScoreName = result.Key.ScoreName,
                                Percent = result.Key.Percent,
                                Score = result.Key.Score }).ToListAsync();

            return await (from r in _context.Results
                          join c in _context.Contests on r.ContestID equals c.ID
                          join s in _context.Subjects on c.SubjectID equals s.ID
                          join sa in _context.SubjectAccounts on s.ID equals sa.SubjectID
                          join st in _context.ScoreTypes on c.ScoreTypeID equals st.ID
                          join a in _context.Accounts on r.UserID equals a.Id
                          join ur in _context.UserRoles on a.Id equals ur.UserId
                          join role in _context.Roles on ur.RoleId equals role.Id
                          where role.Name == Roles.Student && sa.UserID == teacherID
                          group a by new { StudentID = a.Student_TeacherID, a.Name, SubjectName = s.Name, ScoreName = st.Name, st.Percent, Score = r.Mark } into result
                          select new ScoreListFromDBModel()
                          {
                              StudentID = result.Key.StudentID,
                              Name = result.Key.Name,
                              SubjectName = result.Key.SubjectName,
                              ScoreName = result.Key.ScoreName,
                              Percent = result.Key.Percent,
                              Score = result.Key.Score
                          }).ToListAsync();
        }

        public async Task<ApiResult<ScoreListViewModel.StudentResult>> GetScoreListByStudentID(Guid studentID) 
        {
            var studentResult = new ScoreListViewModel.StudentResult();
            var scoreList = await GetScoreListFromDBByStudentID(studentID);

            if(scoreList == null)
            {
                return new ApiSuccessResult<ScoreListViewModel.StudentResult>(studentResult);
            }

            var scoreGroupBySubject = scoreList.GroupBy(x => x.SubjectName)
                                                    .Select(score => score.ToList())
                                                    .ToList();
            
            foreach (var scores in scoreGroupBySubject)
            {
                var subjectResult = new ScoreListViewModel.SubjectResult()
                {
                    Name = scores.First().SubjectName,
                    FinalScore = null,
                    Scores = scores.Select(x => new ScoreListViewModel.ScoreModel()
                            {
                                Name = x.ScoreName,
                                Percent = x.Percent,
                                Score = x.Score
                            }).ToList()
                };

                if(subjectResult.Scores.Count >= 4)
                {
                    subjectResult.FinalScore = subjectResult.Scores.Sum(x => x.Percent * x.Score);
                }

                studentResult.SubjectResults.Add(subjectResult);
            }

            return new ApiSuccessResult<ScoreListViewModel.StudentResult>(studentResult);
        }

        private async Task<List<ScoreListFromDBModel>> GetScoreListFromDBByStudentID(Guid StudentID)
        {
            return await (from r in _context.Results
                          join c in _context.Contests on r.ContestID equals c.ID
                          join s in _context.Subjects on c.SubjectID equals s.ID
                          join st in _context.ScoreTypes on c.ScoreTypeID equals st.ID
                          where r.UserID == StudentID
                          group r by new { SubjectName = s.Name, ScoreName = st.Name, st.Percent, Score = r.Mark } into result
                          select new ScoreListFromDBModel()
                          {
                              SubjectName = result.Key.SubjectName,
                              ScoreName = result.Key.ScoreName,
                              Percent = result.Key.Percent,
                              Score = result.Key.Score
                          }).ToListAsync();
        }
    }
}
