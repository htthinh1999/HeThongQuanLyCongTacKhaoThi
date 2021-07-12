using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Classes;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Classes
{
    public class ClassService : IClassService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public ClassService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<string> Create(ClassCreateRequest request)
        {
            var _class = new Class() { ID = request.ID, Name = request.Name };
            _context.Classes.Add(_class);
            await _context.SaveChangesAsync();
            return _class.ID;
        }

        public async Task<int> Delete(string classID)
        {
            var _class = await _context.Classes.FindAsync(classID);
            if (_class == null) throw new Exception($"Cannot find Class with ID = {classID}");
            _context.Classes.Remove(_class);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateName(string classID, string name)
        {
            var _class = await _context.Classes.FindAsync(classID);
            if (_class == null) throw new Exception($"Cannot find Class with ID = {classID}");
            _class.Name = name;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IncreaseStudentCount(string classID, int count)
        {
            var _class = await _context.Classes.FindAsync(classID);
            if (_class == null) throw new Exception($"Cannot find Class with ID = {classID}");
            _class.StudentCount += count;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DecreaseStudentCount(string classID, int count)
        {
            var _class = await _context.Classes.FindAsync(classID);
            if (_class == null) throw new Exception($"Cannot find Class with ID = {classID}");
            _class.StudentCount -= count;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<PagedResult<ClassViewModel>> GetAllPaging(ClassPagingRequest request)
        {
            if (string.IsNullOrEmpty(request.Keyword))
            {
                throw new Exception("Cannot load with empty keyword");
            }
            var query = _context.Classes.Where(c => c.Name.Contains(request.Keyword));
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ClassViewModel()
                {
                    ID = x.ID,
                    Name = x.Name,
                    StudentCount = x.StudentCount
                }).ToListAsync();
            var totalRow = await query.CountAsync();
            var pagedResult = new PagedResult<ClassViewModel>()
            {
                TotalRecords = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<ClassViewModel> GetByID(string classID)
        {
            var _class = await _context.Classes.FindAsync(classID);
            if (_class == null) throw new Exception($"Cannot find Class with ID = {classID}");

            ClassViewModel classViewModel = new ClassViewModel()
            {
                ID = classID,
                Name = _class.Name,
                StudentCount = _class.StudentCount
            };

            return classViewModel;
        }
    }
}